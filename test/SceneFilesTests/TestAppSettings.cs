using SceneFiles;

namespace SceneFilesTests
{
    internal class TestAppSettings : AppSettings
    {
        public TestAppSettings()
        {
            PutLastOccurenceOfAYearInParentheses = false;
            RemoveSpecifiedWordsFromEnd =  new string[] {};
            ReplaceSpecifiedCharsWithWhitespace = new char[] { '.', '_' };
            ToTitleCase = true;
            LowerCaseSpecifiedWords = new string[] { "the", "of", "and", "at", "vs", "a", "an", "but", "nor", "for", "on", "so", "yet", "to", "is" };
            UpperCaseSpecifiedWords = new string[] { "ai", "usa", "uk", "pal", "ntsc", "html", "ui", "dns", "xml", "php", "ux", "usb", "uwp", "sql", "tfs", "css", "api", "OS" };
            UpperCaseFirstLetter =  true;
            PutLastOccurenceOfAYearInParentheses = true;
            FormatEditionsToLowerCase = true;
        }
    }
}
