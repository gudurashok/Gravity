namespace Scalable.SpellChecker.Dictionary.Phonetic
{
    public class PhoneticRule
    {
        public bool BeginningOnly { get; set; }
        public int[] Condition { get; private set; }
        public int ConditionCount { get; set; }
        public int ConsumeCount { get; set; }
        public bool EndOnly { get; set; }
        public int Priority { private get; set; }
        public bool ReplaceMode { get; set; }
        public string ReplaceString { get; set; }

        public PhoneticRule()
        {
            Condition = new int[256];
        }
    }
}
