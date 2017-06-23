using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using Scalable.SpellChecker.Dictionary.Affix;
using Scalable.SpellChecker.Dictionary.Phonetic;

namespace Scalable.SpellChecker.Dictionary
{
	[ToolboxBitmap(typeof(WordDictionary), "Dictionary.bmp")]
	public class WordDictionary : Component
	{
		private readonly Hashtable _baseWords = new Hashtable();
		private string _copyright = "";
		private string _dictionaryFile = Thread.CurrentThread.CurrentCulture.Name + ".dic";
		private string _dictionaryFolder = "";
	    private const bool _enableUserFile = true;
	    private bool _initialized;
		private readonly PhoneticRuleCollection _phoneticRules = new PhoneticRuleCollection();
		private readonly ArrayList _possibleBaseWords = new ArrayList();
		private readonly AffixRuleCollection _prefixRules = new AffixRuleCollection();
		private readonly ArrayList _replaceCharacters = new ArrayList();
		private readonly AffixRuleCollection _suffixRules = new AffixRuleCollection();
		private string _tryCharacters = "";
		private string _userFile = "user.dic";
		private readonly Hashtable _userWords = new Hashtable();
		private Container _components;

		public WordDictionary()
		{
			InitializeComponent();
		}

		public WordDictionary(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		private void LoadUserFile()
		{
			// load user words
			_userWords.Clear();

			// quit if user file is disabled
			if (!EnableUserFile) return;

			var userPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "NetSpell");
			var filePath = Path.Combine(userPath, _userFile);

			if (!File.Exists(filePath))
				return;

			TraceWriter.TraceInfo("Loading User Dictionary:{0}", filePath);

			//IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForAssembly();
			//fs = new IsolatedStorageFileStream(_UserFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, isf);
			var fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			var sr = new StreamReader(fs, Encoding.UTF8);

			// read line by line
			while (sr.Peek() >= 0)
			{
				var readLine = sr.ReadLine();
				if (readLine == null)
					continue;

				var tempLine = readLine.Trim();
				if (tempLine.Length > 0)
					_userWords.Add(tempLine, tempLine);
			}

			fs.Close();
			sr.Close();
			//isf.Close();

			TraceWriter.TraceInfo("Loaded User Dictionary; Words:{0}", _userWords.Count);
		}

		private void SaveUserFile()
		{
			// quit if user file is disabled
			if (!EnableUserFile)
				return;

			var userPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "NetSpell");
			if (!Directory.Exists(userPath))
				Directory.CreateDirectory(userPath);

			var filePath = Path.Combine(userPath, _userFile);
			TraceWriter.TraceInfo("Saving User Dictionary:{0}", filePath);

			//IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForAssembly();
			//FileStream fs = new IsolatedStorageFileStream(_UserFile, FileMode.Create, FileAccess.Write, isf);
			var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			var sw = new StreamWriter(fs, Encoding.UTF8);
			sw.NewLine = "\n";

			foreach (string tempWord in _userWords.Keys)
				sw.WriteLine(tempWord);

			sw.Close();
			fs.Close();
			//isf.Close();

			TraceWriter.TraceInfo("Saved User Dictionary; Words:{0}", _userWords.Count);
		}

		private bool VerifyAffixKey(string word, char affixKey)
		{
			// make sure base word has this affix key
			var baseWord = (Word)BaseWords[word];
			var keys = new ArrayList(baseWord.AffixKeys.ToCharArray());
			return keys.Contains(affixKey);
		}

		public void Add(string word)
		{
			_userWords.Add(word, word);
			SaveUserFile();
		}

		public void Clear()
		{
			_userWords.Clear();
			SaveUserFile();
		}

		public bool Contains(string word)
		{
			// clean up possible base word list
			_possibleBaseWords.Clear();

			// Step 1 Search UserWords
			if (_userWords.Contains(word))
			{
				TraceWriter.TraceVerbose("Word Found in User Dictionary: {0}", word);
				return true;  // word found
			}

			// Step 2 Search BaseWords
			if (_baseWords.Contains(word))
			{
				TraceWriter.TraceVerbose("Word Found in Base Words: {0}", word);
				return true; // word found
			}

			// Step 3 Remove suffix, Search BaseWords

			// save suffixed words for use when removing prefix
			var suffixWords = new ArrayList();
			// Add word to suffix word list
			suffixWords.Add(word);

			foreach (AffixRule rule in SuffixRules.Values)
			{
				foreach (var tempWord in rule.AffixEntries.Cast<AffixEntry>()
											.Select(entry => AffixUtility.RemoveSuffix(word, entry))
											.Where(tempWord => tempWord != word))
				{
					if (_baseWords.Contains(tempWord))
					{
						if (VerifyAffixKey(tempWord, rule.Name[0]))
						{
							TraceWriter.TraceVerbose("Word Found With Base Words: {0}; Suffix Key: {1}", tempWord, rule.Name[0]);
							return true; // word found
						}
					}

					if (rule.AllowCombine)
					{
						// saving word to check if it is a word after prefix is removed
						suffixWords.Add(tempWord);
					}
					else
					{
						// saving possible base words for use in generating suggestions
						_possibleBaseWords.Add(tempWord);
					}
				}
			}
			// saving possible base words for use in generating suggestions
			_possibleBaseWords.AddRange(suffixWords);

			// Step 4 Remove Prefix, Search BaseWords
			foreach (AffixRule rule in PrefixRules.Values)
			{
				foreach (var tempWord in from AffixEntry entry in rule.AffixEntries from string suffixWord in suffixWords let tempWord = AffixUtility.RemovePrefix(suffixWord, entry) where tempWord != suffixWord select tempWord)
				{
					if (_baseWords.Contains(tempWord))
					{
						if (VerifyAffixKey(tempWord, rule.Name[0]))
						{
							TraceWriter.TraceVerbose("Word Found With Base Words: {0}; Prefix Key: {1}", tempWord, rule.Name[0]);
							return true; // word found
						}
					}

					// saving possible base words for use in generating suggestions
					_possibleBaseWords.Add(tempWord);
				}
			} // prefix rule
			// word not found 
			TraceWriter.TraceVerbose("Possible Base Words: {0}", _possibleBaseWords.Count);
			return false;
		}

		public ArrayList ExpandWord(Word word)
		{
			var suffixWords = new ArrayList();
			var words = new ArrayList();

			suffixWords.Add(word.Text);
			var prefixKeys = "";

			// check suffix keys first
			foreach (var key in word.AffixKeys)
			{
				if (_suffixRules.ContainsKey(key.ToString(CultureInfo.CurrentUICulture)))
				{
					var rule = _suffixRules[key.ToString(CultureInfo.CurrentUICulture)];
					var tempWord = AffixUtility.AddSuffix(word.Text, rule);
					if (tempWord != word.Text)
					{
						if (rule.AllowCombine)
							suffixWords.Add(tempWord);
						else
							words.Add(tempWord);
					}
				}
				else if (_prefixRules.ContainsKey(key.ToString(CultureInfo.CurrentUICulture)))
				{
					prefixKeys += key.ToString(CultureInfo.CurrentUICulture);
				}
			}

			// apply prefixes
			foreach (var tempWord in from key in prefixKeys select _prefixRules[key.ToString(CultureInfo.CurrentUICulture)] into rule from string suffixWord in suffixWords let tempWord = AffixUtility.AddPrefix(suffixWord, rule) where tempWord != suffixWord select tempWord)
				words.Add(tempWord);

			words.AddRange(suffixWords);

			TraceWriter.TraceVerbose("Word Expanded: {0}; Child Words: {1}", word.Text, words.Count);
			return words;
		}

		public void Initialize()
		{
			// clean up data first
			_baseWords.Clear();
			_replaceCharacters.Clear();
			_prefixRules.Clear();
			_suffixRules.Clear();
			_phoneticRules.Clear();
			_tryCharacters = "";

			// the following is used to split a line by white space
			var spaceRegx = new Regex(@"[^\s]+", RegexOptions.Compiled);
			var currentSection = "";
			AffixRule currentRule = null;
			var dictionaryPath = Path.Combine(_dictionaryFolder, _dictionaryFile);

			TraceWriter.TraceInfo("Loading Dictionary:{0}", dictionaryPath);

			// open dictionary file
			var fs = new FileStream(dictionaryPath, FileMode.Open, FileAccess.Read, FileShare.Read);
			var sr = new StreamReader(fs, Encoding.UTF8);

			// read line by line
			while (sr.Peek() >= 0)
			{
				var readLine = sr.ReadLine();
				if (readLine == null)
					continue;

				var tempLine = readLine.Trim();
				if (tempLine.Length <= 0)
					continue;

				// check for section flag
				switch (tempLine)
				{
					case "[Copyright]":
					case "[Try]":
					case "[Replace]":
					case "[Prefix]":
					case "[Suffix]":
					case "[Phonetic]":
					case "[Words]":
						// set current section that is being parsed
						currentSection = tempLine;
						break;
					default:
						// parse line and place in correct object
						MatchCollection partMatches;
						switch (currentSection)
						{
							case "[Copyright]":
								Copyright += tempLine + "\r\n";
								break;
							case "[Try]": // ISpell try chars
								TryCharacters += tempLine;
								break;
							case "[Replace]": // ISpell replace chars
								ReplaceCharacters.Add(tempLine);
								break;
							case "[Prefix]": // MySpell prefix rules
							case "[Suffix]": // MySpell suffix rules

								// split line by white space
								partMatches = spaceRegx.Matches(tempLine);

								// if 3 parts, then new rule  
								switch (partMatches.Count)
								{
									case 3:
										currentRule = new AffixRule();
										currentRule.Name = partMatches[0].Value;

										if (partMatches[1].Value == "Y")
											currentRule.AllowCombine = true;

										if (currentSection == "[Prefix]")
											PrefixRules.Add(currentRule.Name, currentRule);
										else
											SuffixRules.Add(currentRule.Name, currentRule);

										break;
									case 4:
										if (currentRule.Name == partMatches[0].Value)
										{
											var entry = new AffixEntry();

											// part 2 = strip char
											if (partMatches[1].Value != "0")
												entry.StripCharacters = partMatches[1].Value;

											// part 3 = add chars
											entry.AddCharacters = partMatches[2].Value;

											// part 4 = conditions
											AffixUtility.EncodeConditions(partMatches[3].Value, entry);

											currentRule.AffixEntries.Add(entry);
										}
										break;
								}
								break;
							case "[Phonetic]": // ASpell phonetic rules
								// split line by white space
								partMatches = spaceRegx.Matches(tempLine);
								if (partMatches.Count >= 2)
								{
									var rule = new PhoneticRule();
									PhoneticUtility.EncodeRule(partMatches[0].Value, ref rule);
									rule.ReplaceString = partMatches[1].Value;
									_phoneticRules.Add(rule);
								}
								break;
							case "[Words]": // dictionary word list
								// splits word into its parts
								var parts = tempLine.Split('/');
								var tempWord = new Word();
								// part 1 = base word
								tempWord.Text = parts[0];
								// part 2 = affix keys
								if (parts.Length >= 2)
									tempWord.AffixKeys = parts[1];

								// part 3 = phonetic code
								if (parts.Length >= 3)
									tempWord.PhoneticCode = parts[2];

								BaseWords.Add(tempWord.Text, tempWord);
								break;
						} // currentSection swith
						break;
				} //tempLine switch
			} // read line
			// close files
			sr.Close();
			fs.Close();

			TraceWriter.TraceInfo("Dictionary Loaded BaseWords:{0}; PrefixRules:{1}; SuffixRules:{2}; PhoneticRules:{3}",
												BaseWords.Count, PrefixRules.Count, SuffixRules.Count, PhoneticRules.Count);

			LoadUserFile();
			_initialized = true;
		}

		public string PhoneticCode(string word)
		{
			var tempWord = word.ToUpper();
			var code = new StringBuilder();

			while (tempWord.Length > 0)
			{
				// save previous word
				var prevWord = tempWord;
				foreach (var rule in _phoneticRules)
				{
					var begining = tempWord.Length == word.Length;
					var ending = rule.ConditionCount == tempWord.Length;

					if ((rule.BeginningOnly != begining && rule.BeginningOnly) 
							|| (rule.EndOnly != ending && rule.EndOnly) 
							|| rule.ConditionCount > tempWord.Length) 
						continue;
					
					var passCount = 0;
					// loop through conditions
					for (var i = 0; i < rule.ConditionCount; i++)
					{
						var charCode = (int)tempWord[i];

						if ((rule.Condition[charCode] & (1 << i)) == (1 << i))
							passCount++; // condition passed
						else
							break; // rule fails if one condition fails
					}
					// if all condtions passed
					if (passCount != rule.ConditionCount) 
						continue;

					if (rule.ReplaceMode)
						tempWord = rule.ReplaceString + tempWord.Substring(rule.ConditionCount - rule.ConsumeCount);
					else
					{
						if (rule.ReplaceString != "_")
							code.Append(rule.ReplaceString);

						tempWord = tempWord.Substring(rule.ConditionCount - rule.ConsumeCount);
					}
					break;
				} // for each

				// if no match consume one char
				if (prevWord.Length == tempWord.Length)
					tempWord = tempWord.Substring(1);

			}// while

			return code.ToString();
		}

		public void Remove(string word)
		{
			_userWords.Remove(word);
			SaveUserFile();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_components != null)
				{
					_components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Hashtable BaseWords
		{
			get { return _baseWords; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string Copyright
		{
			get { return _copyright; }
			private set { _copyright = value; }
		}

		[DefaultValue("en-US.dic")]
		[CategoryAttribute("Dictionary")]
		[Description("The file name for the main dictionary")]
		[NotifyParentProperty(true)]
		public string DictionaryFile
		{
			get { return _dictionaryFile; }
			set
			{
				_dictionaryFile = value;
				if (_dictionaryFile.Length == 0)
					_dictionaryFile = Thread.CurrentThread.CurrentCulture.Name + ".dic";
			}
		}

		[DefaultValue("")]
		[CategoryAttribute("Dictionary")]
		[Description("The folder containing dictionaries")]
		[Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
		[NotifyParentProperty(true)]
		public string DictionaryFolder 
		{
			get { return _dictionaryFolder; }
			set { _dictionaryFolder = value; }
		}

		[DefaultValue(true)]
		[CategoryAttribute("Options")]
		[Description("Set this to true to automaticly create a user dictionary")]
		[NotifyParentProperty(true)]
		public bool EnableUserFile
		{
			get { return _enableUserFile; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Initialized
		{
			get { return _initialized; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PhoneticRuleCollection PhoneticRules
		{
			get { return _phoneticRules; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AffixRuleCollection PrefixRules
		{
			get { return _prefixRules; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ArrayList ReplaceCharacters
		{
			get { return _replaceCharacters; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public AffixRuleCollection SuffixRules
		{
			get { return _suffixRules; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string TryCharacters
		{
			get { return _tryCharacters; }
			private set { _tryCharacters = value; }
		}

		[DefaultValue("user.dic")]
		[CategoryAttribute("Dictionary")]
		[Description("The file name for the user word list for this dictionary")]
		[NotifyParentProperty(true)]
		public string UserFile
		{
			get { return _userFile; }
			set { _userFile = value; }
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Hashtable UserWords
		{
			get { return _userWords; }
		}

		internal ArrayList PossibleBaseWords
		{
			get { return _possibleBaseWords; }
		}

		#region Component Designer generated code

		private void InitializeComponent()
		{
			_components = new Container();
		}
		
		#endregion
	}
}
