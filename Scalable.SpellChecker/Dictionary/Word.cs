using System;

namespace Scalable.SpellChecker.Dictionary
{
	public class Word  : IComparable
	{
	    public Word()
		{
		    Text = "";
		    PhoneticCode = "";
		    AffixKeys = "";
		}

	    public Word(string text, string affixKeys, string phoneticCode)
		{
			Text = text;
			AffixKeys = affixKeys;
			PhoneticCode = phoneticCode;
		}

		public Word(string text, string affixKeys)
		{
		    PhoneticCode = "";
		    Text = text;
			AffixKeys = affixKeys;
		}

		public Word(string text)
		{
		    PhoneticCode = "";
		    AffixKeys = "";
		    Text = text;
		}

	    internal Word(string text, int index, int height)
		{
	        PhoneticCode = "";
	        AffixKeys = "";
	        Text = text;
			Index = index;
			Height = height;
		}

		internal Word(string text, int editDistance)
		{
		    PhoneticCode = "";
		    AffixKeys = "";
		    Text = text;
			EditDistance = editDistance;
		}

		public int CompareTo(object obj)
		{
			var result = EditDistance.CompareTo(((Word)obj).EditDistance);
			return result; // * -1; // sorts desc order
		}

	    public string AffixKeys { get; set; }
	    public int Index { get; set; }
	    public string PhoneticCode { get; set; }
	    public string Text { get; set; }
	    internal int EditDistance { private get; set; }
	    internal int Height { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}
