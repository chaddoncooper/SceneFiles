using System;
using System.IO.Abstractions;

namespace SceneFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileSystem = new FileSystem();

            var fileAndDirectoryRenamer = new FileAndDirectoryRenamer(fileSystem); 
            var sceneFileRenamer = new GenericSceneRenamer(fileAndDirectoryRenamer);

            if (!fileSystem.File.Exists(args[0]))
                throw new Exception(string.Format("File or directory does not exist: {0}", args[0]));

            sceneFileRenamer.RenameFileOrDirectory(args[0]);
        }
    }
}
