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

            newName = newName.ReplaceSpecifiedCharsWithWhitespace(new[] { '.', '_' });
            newName = newName.ToTitleCase();
            newName = newName.LowercaseSpecifiedWords(new[] { "the", "of", "and", "at", "vs", "a", "an", "but", "nor", "for", "on", "so", "yet" });
            newName = newName.UppercaseSpecifiedWords(new[]
                {"ai", "usa", "uk", "pal", "ntsc", "html", "ui", "dns", "html", "xml", "php", "ux", "usb", "uwp", "sql", "tfs", "css", "api" });
            newName = newName.UpperCaseFirstLetter();
            newName = newName.PutLastOccurenceOfAYearInParentheses();
            newName = newName.FormatEditionsToLowercase();

            _fileAndDirectoryRenamer.RenameFileWithoutExtensionOrDirectory(fileOrDirectoryPath, newName);
        }
    }
}
