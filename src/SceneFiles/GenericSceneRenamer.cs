using System.Linq;

namespace SceneFiles
{
    public class GenericSceneRenamer : ISceneRenamer
    {
        private readonly IFileAndDirectoryRenamer _fileAndDirectoryRenamer;
        private readonly AppSettings _appSettings;

        public GenericSceneRenamer(IFileAndDirectoryRenamer fileAndDirectoryRenamer, AppSettings appSettings)
        {
            _fileAndDirectoryRenamer = fileAndDirectoryRenamer;
            _appSettings = appSettings;
        }

        public void RenameFileOrDirectory(string fileOrDirectoryPath)
        {
            var newName = _fileAndDirectoryRenamer.GetCurrentFileOrDirectoryName(fileOrDirectoryPath);

            if (_appSettings.RemoveSpecifiedWordsFromEnd.Count() > 0)
            {
                newName = newName.RemoveSpecifiedWordsFromEnd(_appSettings.RemoveSpecifiedWordsFromEnd);
            }
            
            if (_appSettings.ReplaceSpecifiedCharsWithWhitespace.Count() > 0)
            {
                newName = newName.ReplaceSpecifiedCharsWithWhitespace(_appSettings.ReplaceSpecifiedCharsWithWhitespace);
            }
            
            if (_appSettings.ToTitleCase)
            {
                newName = newName.ToTitleCase();
            }
            
            if (_appSettings.LowerCaseSpecifiedWords.Count() > 0)
            {
                newName = newName.LowerCaseSpecifiedWords(_appSettings.LowerCaseSpecifiedWords);
            }
            
            if (_appSettings.UpperCaseSpecifiedWords.Count() > 0)
            {
                newName = newName.UpperCaseSpecifiedWords(_appSettings.UpperCaseSpecifiedWords);
            }
            
            if (_appSettings.UpperCaseFirstLetter)
            {
                newName = newName.UpperCaseFirstLetter();
            }

            if (_appSettings.PutLastOccurenceOfAYearInParentheses)
            {
                newName = newName.PutLastOccurenceOfAYearInParentheses();
            }
            
            if (_appSettings.FormatEditionsToLowerCase)
            {
                newName = newName.FormatEditionsToLowerCase();
            }

            _fileAndDirectoryRenamer.RenameFileWithoutExtensionOrDirectory(fileOrDirectoryPath, newName);
        }
    }
}
