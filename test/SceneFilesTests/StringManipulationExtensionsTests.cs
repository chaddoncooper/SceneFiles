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
                {"the", "of", "and", "at", "vs", "a", "an", "but", "nor", "for", "on", "so", "yet"};

            var output = inputString.LowercaseSpecifiedWords(wordsToLowercase);

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
    }
}
