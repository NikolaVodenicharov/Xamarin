using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Core
{
    public static class PhonewordTranslator
    {
        private const string UnchangedCharacters = " -0123456789";

        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
            {
                return String.Empty;
            }

            raw = raw.ToUpperInvariant();

            var builder = new StringBuilder();
            foreach (var character in raw)
            {           
                if (UnchangedCharacters.Contains(character))
                {
                    builder.Append(character);
                }
                else
                {
                    var translatedChar = TranslateToNumber(character);
                    if (translatedChar != null)
                    {
                        builder.Append(translatedChar);
                    }
                }
            }

            return builder.ToString();
        }
        private static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }

        private static int? TranslateToNumber(char c)
        {
            if ("ABC".Contains(c))
                return 2;
            else if ("DEF".Contains(c))
                return 3;
            else if ("GHI".Contains(c))
                return 4;
            else if ("JKL".Contains(c))
                return 5;
            else if ("MNO".Contains(c))
                return 6;
            else if ("PQRS".Contains(c))
                return 7;
            else if ("TUV".Contains(c))
                return 8;
            else if ("WXYZ".Contains(c))
                return 9;
            return null;
        }
    }
}