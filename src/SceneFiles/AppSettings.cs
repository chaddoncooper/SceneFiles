using System;

namespace SceneFiles
{
    public class AppSettings
    {
        public string[] RemoveSpecifiedWordsFromEnd { get; set; } = new string[] { };
        public char[] ReplaceSpecifiedCharsWithWhitespace { get; set; } = new char[] { };
        public bool ToTitleCase { get; set; } = false;
        public string[] LowerCaseSpecifiedWords { get; set; } = new string[] { };
        public string[] UpperCaseSpecifiedWords { get; set; } = new string[] { };
        public bool UpperCaseFirstLetter { get; set; } = false;
        public bool PutLastOccurenceOfAYearInParentheses { get; set; } = false;
        public bool FormatEditionsToLowerCase { get; set; } = false;

        public override string ToString()
        {
            return
                $"RemoveSpecifiedWordsFromEnd: {string.Join(",", RemoveSpecifiedWordsFromEnd)}" +
                Environment.NewLine + $"ReplaceSpecifiedCharsWithWhitespace: {string.Join(",", ReplaceSpecifiedCharsWithWhitespace)}" +
                Environment.NewLine + $"ToTitleCase: {ToTitleCase}" +
                Environment.NewLine + $"LowerCaseSpecifiedWords: {string.Join(",", LowerCaseSpecifiedWords)}" +
                Environment.NewLine + $"UpperCaseSpecifiedWords: {string.Join(",", UpperCaseSpecifiedWords)}" +
                Environment.NewLine + $"UpperCaseFirstLetter: {UpperCaseFirstLetter}" +
                Environment.NewLine + $"PutLastOccurenceOfAYearInParentheses: {PutLastOccurenceOfAYearInParentheses}" +
                Environment.NewLine + $"FormatEditionsToLowerCase: {FormatEditionsToLowerCase}";
        }
    }
}
