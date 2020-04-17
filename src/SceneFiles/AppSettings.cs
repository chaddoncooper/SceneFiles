using System.Collections.Generic;

namespace SceneFiles
{
    public class AppSettings
    {
        public IEnumerable<string> RemoveSpecifiedWordsFromEnd { get; set; } = new string[] { };
        public IEnumerable<char> ReplaceSpecifiedCharsWithWhitespace { get; set; } = new char[] { };
        public bool ToTitleCase { get; set; } = false;
        public IEnumerable<string> LowerCaseSpecifiedWords { get; set; } = new string[] { };
        public IEnumerable<string> UpperCaseSpecifiedWords { get; set; } = new string[] { };
        public bool UpperCaseFirstLetter { get; set; } = false;
        public bool PutLastOccurenceOfAYearInParentheses { get; set; } = false;
        public bool FormatEditionsToLowerCase { get; set; } = false;
    }
}
