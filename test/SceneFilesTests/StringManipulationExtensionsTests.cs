using SceneFiles;
using Xunit;

namespace SceneFilesTests
{
    public class StringManipulationExtensionsTests
    {
        [Theory]
        [InlineData("this.is.my.string.with.periods.for.spaces", "this is my string with periods for spaces")]
        [InlineData("this_is_my_string_with_underscores_for_spaces", "this is my string with underscores for spaces")]
        public void ReplaceCharsWithWhitespace(string inputString, string expectedOutput)
        {
            var charsToReplace = new[] {'.', '_'};

            var output = inputString.ReplaceSpecifiedCharsWithWhitespace(charsToReplace);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("THIS IS A LOVELY TEST OF THE METHOD", "THIS IS a LOVELY TEST of the METHOD")]
        [InlineData("THE words at the start and the end should still lowercase. BUT", "the words at the start and the end should still lowercase. but")]
        [InlineData("THERE SHOULD BE NO MATCHES", "THERE SHOULD BE NO MATCHES")]
        public void LowercaseCertainWords(string inputString, string expectedOutput)
        {
            var wordsToLowercase = new[]
                {"the", "of", "and", "at", "vs", "a", "an", "BUT", "nor", "for", "on", "so", "yet"};

            var output = inputString.LowerCaseSpecifiedWords(wordsToLowercase);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("ai is the future", "AI is the future")]
        [InlineData("Born in the usa", "Born in the USA")]
        public void UppercaseCertainWords(string inputString, string expectedOutput)
        {
            var wordsToUppercase = new[]
                {"ai", "usa", "uk", "pal", "ntsc", "html", "ui", "dns", "html", "xml", "php", "ux", "usb", "uwp", "sql", "tfs", "css", "api" };

            var output = inputString.UpperCaseSpecifiedWords(wordsToUppercase);

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("this is a test string", "This Is A Test String")]
        [InlineData("THIS IS A TEST STRING", "This Is A Test String")]
        public void ToTitleCase(string inputString, string expectedOutput)
        {
            var output = inputString.ToTitleCase();

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData("This is a year 1999", "This is a year (1999)")]
        [InlineData("This is a year 2010", "This is a year (2010)")]
        [InlineData("This is a year 2050", "This is a year (2050)")]
        [InlineData("Ignore this year 2000. This is a year 2050", "Ignore this year 2000. This is a year (2050)")]
        [InlineData("20022 This isn't a year", "20022 This isn't a year")]
        [InlineData("This isn't a year 19992", "This isn't a year 19992")]
        public void PutLastOccurenceOfAYearInParentheses(string inputString, string expectedOutput)
        {
            var output = inputString.PutLastOccurenceOfAYearInParentheses();

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(@"This is a 6Th Edition (2019)", "This is a 6th Edition (2019)")]
        [InlineData(@"This is a 6TH Edition (2019)", "This is a 6th Edition (2019)")]
        [InlineData(@"This is a 6th Edition (2019)", "This is a 6th Edition (2019)")]
        [InlineData(@"This is a_6Th_Edition (2019)", "This is a_6th_Edition (2019)")]
        [InlineData(@"This is a6Th_Edition (2019)", "This is a6th_Edition (2019)")]
        [InlineData(@"This is a 6TH, also a 8TH Edition (2019)", "This is a 6th, also a 8th Edition (2019)")]
        public void FormatEditionsToLowercase(string inputString, string expectedOutput)
        {
            var output = inputString.FormatEditionsToLowerCase();

            Assert.Equal(expectedOutput, output);
        }

        [Theory]
        [InlineData(@"this is a string-ReMovE", "this is a string-")]
        [InlineData(@"this is a string-ReMove", "this is a string-ReMove")]
        [InlineData(@"this is a string", "this is a string")]
        public void RemoveSpecifiedWordsFromEnd(string inputString, string expectedOutput)
        {
            var wordsToRemove = new[] { "ReMovE" };
            var output = inputString.RemoveSpecifiedWordsFromEnd(wordsToRemove);
            
            Assert.Equal(expectedOutput, output);
        }
    }
}
