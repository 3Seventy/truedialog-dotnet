using System;
using System.Text;

namespace TrueDialog.Helpers
{
    public static class Utils
    {
        internal static string SoftReadPhoneNumber(string phoneNumber)
        {
            var rval = RemoveSpecialCharacters(phoneNumber);

            if (string.IsNullOrEmpty(rval))
                throw new ArgumentException("Phone number is empty.");

            if (rval[0] == '1' && rval.Length == 11)
                return rval;
            else if (rval[0] != '1' && rval.Length == 10)
                rval = "1" + rval;
            else
                throw new ArgumentException("Wrong phone number format. Please follow E.164 format (+1xxxxxxxxxx).");

            return rval;
        }

        internal static string ReadPhoneNumber(string phoneNumber)
        {
            var rval = RemoveSpecialCharacters(phoneNumber);

            if (string.IsNullOrEmpty(rval))
                throw new ArgumentException("Phone number is empty.");

            if (rval[0] == '1' && rval.Length == 11)
                rval = "+" + rval;
            else if (rval[0] != '1' && rval.Length == 10)
                rval = "+1" + rval;
            else
                throw new ArgumentException("Wrong phone number format. Please follow E.164 format (+1xxxxxxxxxx).");

            return rval;
        }

        internal static string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
