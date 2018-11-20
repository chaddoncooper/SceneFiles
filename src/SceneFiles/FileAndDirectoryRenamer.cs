using System.IO;
using System.IO.Abstractions;

namespace SceneFiles
{
    public class FileAndDirectoryRenamer : IFileAndDirectoryRenamer
    {
        private readonly IFileSystem _fileSystem;

        public FileAndDirectoryRenamer(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public string GetCurrentFileOrDirectoryName(string path)
        {
            return IsFile(path) ? Path.GetFileNameWithoutExtension(path) : Path.GetFileName(path);
        }

        public void RenameDirectory(string oldPath, string newName)
        {
            _fileSystem.Directory.Move(oldPath, Path.Combine(_fileSystem.Directory.GetParent(oldPath).ToString(), newName));
        }

        public void RenameFileWithoutExtension(string oldPath, string newName)
        {
            _fileSystem.File.Move(oldPath, Path.Combine(Path.GetDirectoryName(oldPath), newName + Path.GetExtension(oldPath)));
        }

        public void RenameFileWithoutExtensionOrDirectory(string oldPath, string newName)
        {
            if (IsFile(oldPath))
            {
                RenameFileWithoutExtension(oldPath, newName);
            }
            else
            {
                RenameDirectory(oldPath, newName);
            }
        }

        /// <summary>
        /// Check if a path is a file or a directory.
        /// </summary>
        /// <param name="path">Path to check.</param>
        /// <returns>Returns true if path is anything other than directory.</returns>
        private bool IsFile(string path)
        {
            return !_fileSystem.File.GetAttributes(path).HasFlag(FileAttributes.Directory);
        }
    }
}
