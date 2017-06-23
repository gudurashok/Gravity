namespace Scalable.SpellChecker.Dictionary.Affix
{
	public class AffixEntry
	{
		private int _conditionCount;
		private string _addCharacters = "";
		private readonly int[] _condition = new int[256] ;
		private string _stripCharacters = "";

		public string AddCharacters
		{
			get {return _addCharacters;}
			set {_addCharacters = value;}
		}

		public int[] Condition
		{
			get {return _condition;}
		}

		public string StripCharacters
		{
			get {return _stripCharacters;}
			set {_stripCharacters = value;}
		}

		public int ConditionCount
		{
			get {return _conditionCount;}
			set {_conditionCount = value;}
		}
	}
}
