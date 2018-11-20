namespace SceneFiles
{
    public class GenericSceneRenamer : ISceneRenamer
    {
        private readonly IFileAndDirectoryRenamer _fileAndDirectoryRenamer;

        public GenericSceneRenamer(IFileAndDirectoryRenamer fileAndDirectoryRenamer)
        {
            _fileAndDirectoryRenamer = fileAndDirectoryRenamer;
        }

        public void RenameFileOrDirectory(string fileOrDirectoryPath)
        {
            var newName = _fileAndDirectoryRenamer.GetCurrentFileOrDirectoryName(fileOrDirectoryPath);

            newName = ReplaceCharsWithWhitespace(newName);
            newName = newName.ToTitleCase();
            newName = LowercaseWords(newName);
            newName = newName.UpperCaseFirstLetter();
            newName = newName.PutLastOccurenceOfAYearInParentheses();

            _fileAndDirectoryRenamer.RenameFileWithoutExtensionOrDirectory(fileOrDirectoryPath, newName);
        }

        private static string ReplaceCharsWithWhitespace(string inputString)
        {
            return inputString.ReplaceSpecifiedCharsWithWhitespace(new[] {'.', '_'});
        }

        private static string LowercaseWords(string inputString)
        {
            return inputString.LowercaseSpecifiedWords(new[]
                {"the", "of", "and", "at", "vs", "a", "an", "but", "nor", "for", "on", "so", "yet"});
        }
    }
}
