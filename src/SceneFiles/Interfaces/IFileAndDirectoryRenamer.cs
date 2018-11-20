namespace SceneFiles
{
    public interface IFileAndDirectoryRenamer
    {
        string GetCurrentFileOrDirectoryName(string path);
        void RenameDirectory(string oldPath, string newName);
        void RenameFileWithoutExtension(string oldPath, string newName);
        void RenameFileWithoutExtensionOrDirectory(string oldPath, string newName);
    }
}