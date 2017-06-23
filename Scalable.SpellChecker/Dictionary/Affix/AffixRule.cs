namespace Scalable.SpellChecker.Dictionary.Affix
{
	public class AffixRule
	{
		private bool _allowCombine;
		private readonly AffixEntryCollection _affixEntries = new AffixEntryCollection();
		private string _name = "";

		public bool AllowCombine
		{
			get {return _allowCombine;}
			set {_allowCombine = value;}
		}

		public AffixEntryCollection AffixEntries
		{
			get {return _affixEntries;}
		}

		public string Name
		{
			get {return _name;}
			set {_name = value;}
		}
	}
}
