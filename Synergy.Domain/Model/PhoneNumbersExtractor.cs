using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Synergy.Domain.Model
{
    public static class PhoneNumbersExtractor
    {
        public static IList<string> GetNumbers(string recipients)
        {
            if (string.IsNullOrWhiteSpace(recipients))
                throw new ValidationException("Recipient(s) has no numbers set to send SMS");

            var data = recipients.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(n => n.Trim()).ToArray();

            foreach (var nr in data.Where(nr => !IsValidNumber(nr)))
                throw new ValidationException(string.Format("Invalid Number \"{0}\"", nr));

            return data;
        }

        public static bool IsValidNumber(string nr)
        {
            var copy = nr.Replace("+", "");

            long result;
            if (!long.TryParse(copy, out result))
                return false;

            if (nr.Length < 10)
                return false;

            if (nr.Substring(nr.Length - 10, 10)[0] == '0')
                return false;

            if (nr.Length == 10)
                return true;

            var prefix = nr.Substring(0, nr.Length - 10);
            return string.IsNullOrWhiteSpace(prefix) || prefix == "0" || prefix == "+91";
        }
    }
}
