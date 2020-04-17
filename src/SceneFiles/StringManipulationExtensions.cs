using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SceneFiles
{
    public static class StringManipulationExtensions
    {
        /// <summary>
        /// Replaces  specified chars with whitespace.
        /// </summary>
        /// <param name="str">A string, usually a sentence.</param>
        /// <param name="charsToReplace">Characters to be replaced with a space.</param>
        /// <returns>The string with specified characters replaced with whitespace.</returns>
        public static string ReplaceSpecifiedCharsWithWhitespace(this string str, IEnumerable<char> charsToReplace)
        {
            return charsToReplace.Aggregate(str, (current, whitespaceChar) => current.Replace(whitespaceChar, ' '));
        }

        /// <summary>
        /// Converts specified words within a string into lowercase.
        /// </summary>
        /// <param name="str">A string, usually a sentence.</param>
        /// <param name="wordsToLowerCase">Words which you wish to convert to lowercase.</param>
        /// <returns>The string with specified words converted to lowercase.</returns>
        public static string LowerCaseSpecifiedWords(this string str, IEnumerable<string> wordsToLowerCase)
        {
            foreach (var wordToLowerCase in wordsToLowerCase)
            {
                var pattern = string.Format(@"(?<!\S){0}(?!\S)", wordToLowerCase);
                str = Regex.Replace(str, pattern, wordToLowerCase.ToLower(), RegexOptions.IgnoreCase);
            }

            return str;
        }

        /// <summary>
        /// Converts specified words within a string into Uppercase.
        /// </summary>
        /// <param name="str">A string, usually a sentence.</param>
        /// <param name="wordsToUpperCase">Words which you wish to convert to Uppercase.</param>
        /// <returns>The string with specified words converted to Uppercase.</returns>
        public static string UpperCaseSpecifiedWords(this string str, IEnumerable<string> wordsToUpperCase)
        {
            foreach (var wordToUpperCase in wordsToUpperCase)
            {
                var pattern = string.Format(@"(?<!\S){0}(?!\S)", wordToUpperCase);
                str = Regex.Replace(str, pattern, wordToUpperCase.ToUpper(), RegexOptions.IgnoreCase);
            }

            return str;
        }

        /// <summary>
        /// Converts a string into title case.
        /// </summary>
        /// <param name="str">A string, usually a sentence.</param>
        /// <returns>The string in title case.</returns>
        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        /// <summary>
        /// Puts the last occurence of a year (YYYY) within a string in parentheses.
        /// </summary>
        /// <param name="str">A string, usually a sentence containing a year in YYYY format.</param>
        /// <returns>String with the last occurence of a year in parentheses.</returns>
        public static string PutLastOccurenceOfAYearInParentheses(this string str)
        {
            const string pattern = @"(?<=\s|^)\d{4}(?=\s|$)";
            var match = Regex.Match(str, pattern, RegexOptions.RightToLeft);
            if (match.Success)
            {
                str = str.Replace(match.Value, $"({match.Value})");
            }

            return str;
        }

        /// <summary>
        /// Convert the very first letter of the string to uppercase
        /// </summary>
        /// <param name="str">A string, usually a sentence.</param>
        /// <returns>String with the first letter converted to uppercase.</returns>
        public static string UpperCaseFirstLetter(this string str)
        {
            return str.First().ToString().ToUpper() + str.Substring(1);
        }

        /// <summary>
        /// Ensure that any editions within a string are formatted to lowercase
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string FormatEditionsToLowerCase(this string str)
        {
            var pattern = "\\D(\\d+)(st|nd|rd|th)";
            var regex = new Regex(pattern);
      
            var matches = Regex.Matches(str, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    str = str.Replace(match.Value, match.Value.ToLower());
                }
            }
            
            return str;
        }

        /// <summary>
        /// Remove specified words from a string.
        /// </summary>
        /// <param name="str">A string, usually a sentence.</param>
        /// <param name="wordsToRemove">An enumeration of words to remove. Case sensitive.</param>
        /// <returns></returns>
        public static string RemoveSpecifiedWordsFromEnd(this string str, IEnumerable<string> wordsToRemove)
        {
            foreach (var wordToRemove in wordsToRemove)
            {
                var pattern = string.Format(@"(?<!\s){0}$", wordToRemove);
                str = Regex.Replace(str, pattern, "");
            }

            return str;
        }
    }
}
