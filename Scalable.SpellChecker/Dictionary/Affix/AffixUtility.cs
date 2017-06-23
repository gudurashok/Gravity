namespace Scalable.SpellChecker.Dictionary.Affix
{
	public sealed class AffixUtility
	{
		public static string AddPrefix(string word, AffixRule rule)
		{
			foreach (var entry in rule.AffixEntries)
			{
				// check that this entry is valid
				if (word.Length < entry.ConditionCount)
					continue;

				var passCount = 0;
				for (var i = 0; i < entry.ConditionCount; i++)
				{
					var charCode = (int)word[i];

					if ((entry.Condition[charCode] & (1 << i)) == (1 << i))
						passCount++;
					else
						break;
				}

				if (passCount != entry.ConditionCount)
					continue;

				var tempWord = word.Substring(entry.StripCharacters.Length);
				tempWord = entry.AddCharacters + tempWord;
				return tempWord;
			}
			return word;
		}

		public static string AddSuffix(string word, AffixRule rule)
		{
			foreach (var entry in rule.AffixEntries)
			{
				// check that this entry is valid
				if (word.Length < entry.ConditionCount)
					continue;

				var passCount = 0;
				for (var i = 0; i < entry.ConditionCount; i++)
				{
					var charCode = (int)word[word.Length - (entry.ConditionCount - i)];

					if ((entry.Condition[charCode] & (1 << i)) == (1 << i))
						passCount++;
					else
						break;
				}

				if (passCount != entry.ConditionCount)
					continue;

				var tempLen = word.Length - entry.StripCharacters.Length;
				var tempWord = word.Substring(0, tempLen);
				tempWord += entry.AddCharacters;
				return tempWord;
			}
			return word;
		}

		public static void EncodeConditions(string conditionText, AffixEntry entry)
		{
			// clear the conditions array
			for (var i = 0; i < entry.Condition.Length; i++)
				entry.Condition[i] = 0;

			// if no condition just return
			if (conditionText == ".")
			{
				entry.ConditionCount = 0;
				return;
			}

			var neg = false;  /* complement indicator */
			var group = false;  /* group indicator */
			var end = false;   /* end condition indicator */
			var num = 0;    /* number of conditions */

			var memberChars = new char[200];
			var numMember = 0;   /* number of member in group */

			foreach (var cond in conditionText)
			{
				// parse member group
				if (cond == '[')
					group = true;  // start a group
				else if (cond == '^' && group)
					neg = true; // negative group
				else if (cond == ']')
					end = true; // end of a group
				else if (group)
				{
					// add chars to group
					memberChars[numMember] = cond;
					numMember++;
				}
				else
					end = true;  // no group

				// set condition
				if (!end) 
					continue;

				if (group)
				{
					if (neg)
					{
						// turn all chars on
						for (var j = 0; j < entry.Condition.Length; j++)
							entry.Condition[j] = entry.Condition[j] | (1 << num);

						// turn off chars in member group
						for (var j = 0; j < numMember; j++)
						{
							var charCode = (int)memberChars[j];
							entry.Condition[charCode] = entry.Condition[charCode] & ~(1 << num);
						}
					}
					else
					{
						// turn on chars in member group
						for (var j = 0; j < numMember; j++)
						{
							var charCode = (int)memberChars[j];
							entry.Condition[charCode] = entry.Condition[charCode] | (1 << num);
						}
					}
					group = false;
					neg = false;
					numMember = 0;
				} // if group
				else
				{
					if (cond == '.')
					{
						// wild card character, turn all chars on
						for (var j = 0; j < entry.Condition.Length; j++)
							entry.Condition[j] = entry.Condition[j] | (1 << num);
					}
					else
					{
						// turn on char
						var charCode = (int)cond;
						entry.Condition[charCode] = entry.Condition[charCode] | (1 << num);
					}
				} // not group

				end = false;
				num++;
			} // foreach char

			entry.ConditionCount = num;
			return;
		}

		public static string RemovePrefix(string word, AffixEntry entry)
		{

			var tempLength = word.Length - entry.AddCharacters.Length;
			if ((tempLength > 0)
				&& (tempLength + entry.StripCharacters.Length >= entry.ConditionCount)
				&& (word.StartsWith(entry.AddCharacters)))
			{
				// word with out affix
				var tempWord = word.Substring(entry.AddCharacters.Length);
				// add back strip chars
				tempWord = entry.StripCharacters + tempWord;
				// check that this is valid
				var passCount = 0;
				for (var i = 0; i < entry.ConditionCount; i++)
				{
					var charCode = (int)tempWord[i];

					if ((entry.Condition[charCode] & (1 << i)) == (1 << i))
						passCount++;
				}

				if (passCount == entry.ConditionCount)
					return tempWord;

			}
			return word;
		}

		public static string RemoveSuffix(string word, AffixEntry entry)
		{
			var tempLength = word.Length - entry.AddCharacters.Length;
			if ((tempLength > 0)
				&& (tempLength + entry.StripCharacters.Length >= entry.ConditionCount)
				&& (word.EndsWith(entry.AddCharacters)))
			{
				// word with out affix
				var tempWord = word.Substring(0, tempLength);
				// add back strip chars
				tempWord += entry.StripCharacters;
				// check that this is valid
				var passCount = 0;
				for (var i = 0; i < entry.ConditionCount; i++)
				{
					var charCode = (int)tempWord[tempWord.Length - (entry.ConditionCount - i)];

					if ((entry.Condition[charCode] & (1 << i)) == (1 << i))
						passCount++;
				}

				if (passCount == entry.ConditionCount)
					return tempWord;
			}
			return word;
		}
	}
}
