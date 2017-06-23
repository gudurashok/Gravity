using System.Globalization;

namespace Scalable.SpellChecker.Dictionary.Phonetic
{
    public static class PhoneticUtility
    {
        public static void EncodeRule(string ruleText, ref PhoneticRule rule)
        {
            // clear the conditions array
            for (var i = 0; i < rule.Condition.Length; i++)
                rule.Condition[i] = 0;

            var group = false;  /* group indicator */
            var end = false;   /* end condition indicator */

            var memberChars = new char[200];
            var numMember = 0;   /* number of member in group */

            foreach (var cond in ruleText)
            {
                switch (cond)
                {
                    case '(':
                        group = true;
                        break;
                    case ')':
                        end = true;
                        break;
                    case '^':
                        rule.BeginningOnly = true;
                        break;
                    case '$':
                        rule.EndOnly = true;
                        break;
                    case '-':
                        rule.ConsumeCount++;
                        break;
                    case '<':
                        rule.ReplaceMode = true;
                        break;
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        rule.Priority = int.Parse(cond.ToString(CultureInfo.CurrentUICulture));
                        break;
                    default:
                        if (group)
                        {
                            // add chars to group
                            memberChars[numMember] = cond;
                            numMember++;
                        }
                        else
                        {
                            end = true;
                        }
                        break;
                } // switch

                if (!end) 
                    continue;

                if (group)
                {
                    // turn on chars in member group
                    for (var j = 0; j < numMember; j++)
                    {
                        var charCode = (int)memberChars[j];
                        rule.Condition[charCode] = rule.Condition[charCode] | (1 << rule.ConditionCount);
                    }

                    group = false;
                    numMember = 0;
                }
                else
                {
                    // turn on char
                    var charCode = (int)cond;
                    rule.Condition[charCode] = rule.Condition[charCode] | (1 << rule.ConditionCount);
                }
                end = false;
                rule.ConditionCount++;
            } // for each
        }
    }
}
