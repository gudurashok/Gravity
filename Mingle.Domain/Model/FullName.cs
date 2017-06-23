using System.ComponentModel.DataAnnotations;
using System.Text;
using Mingle.Domain.Enums;
using System;
using Mingle.Domain.Properties;

namespace Mingle.Domain.Model
{
    public class FullName
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "PersonFirstNameCannotBeEmpty")]
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }

        #region Constructor

        public FullName()
        {
        }

        public FullName(string givenName)
        {
            First = givenName;
        }

        #endregion

        #region Full Name ToString in different types

        public string[] GetAllNames()
        {
            var result = new string[3];
            result[0] = ToString(FullNameStyle.FirstMiddleLast);
            result[1] = ToString(FullNameStyle.LastFirstMiddle);
            result[2] = ToString(FullNameStyle.LastCommaFirstMiddle);
            return result;
        }

        public override string ToString()
        {
            return getFirstMiddleLastToString();
        }

        public string ToString(FullNameStyle fullNameType)
        {
            switch (fullNameType)
            {
                case FullNameStyle.FirstMiddleLast:
                    return getFirstMiddleLastToString();
                case FullNameStyle.LastFirstMiddle:
                    return getLastFirstMiddleToString();
                case FullNameStyle.LastCommaFirstMiddle:
                    return getLastCommaFirstMiddleToString();
                default:
                    throw new ArgumentOutOfRangeException("fullNameType", fullNameType, @"Invalid full name type");
            }
        }

        private string getFirstMiddleLastToString()
        {
            var sb = new StringBuilder()
            .Append(string.IsNullOrWhiteSpace(First) ? "" : First.Trim())
            .Append(" ")
            .Append(string.IsNullOrWhiteSpace(Middle) ? "" : Middle.Trim())
            .Append(" ")
            .Append(string.IsNullOrWhiteSpace(Last) ? "" : Last.Trim());
            return sb.ToString().Trim();
        }

        private string getLastFirstMiddleToString()
        {
            var sb = new StringBuilder()
            .Append(string.IsNullOrWhiteSpace(Last) ? "" : Last.Trim())
            .Append(" ")
            .Append(string.IsNullOrWhiteSpace(First) ? "" : First.Trim())
            .Append(" ")
            .Append(string.IsNullOrWhiteSpace(Middle) ? "" : Middle.Trim());
            return sb.ToString().Trim();
        }

        private string getLastCommaFirstMiddleToString()
        {
            var sb = new StringBuilder()
            .Append(string.IsNullOrWhiteSpace(Last) ? "" : Last.Trim())
            .Append(", ")
            .Append(string.IsNullOrWhiteSpace(First) ? "" : First.Trim())
            .Append(" ")
            .Append(string.IsNullOrWhiteSpace(Middle) ? "" : Middle.Trim());
            return sb.ToString().Trim();
        }

        #endregion
    }
}
