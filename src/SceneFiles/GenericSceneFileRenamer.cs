namespace SceneFiles
{
    public class GenericSceneFileRenamer : ISceneFileRenamer
    {
        private readonly IFileAndDirectoryRenamer _fileAndDirectoryRenamer;

        public GenericSceneFileRenamer(IFileAndDirectoryRenamer fileAndDirectoryRenamer)
        {
            _fileAndDirectoryRenamer = fileAndDirectoryRenamer;
        }

        public void Rename(string path)
        {
            var newName = _fileAndDirectoryRenamer.GetCurrentFileOrDirectoryName(path);

            newName = ReplaceCharsWithWhitespace(newName);
            newName = newName.ToTitleCase();
            newName = LowercaseWords(newName);
            newName = newName.UpperCaseFirstLetter();
            newName = newName.PutLastOccurenceOfAYearInParentheses();

            _fileAndDirectoryRenamer.RenameFileWithoutExtensionOrDirectory(path, newName);
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
