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
            var sceneFileRenamer = new GenericSceneFileRenamer(fileAndDirectoryRenamer);

            if (!fileSystem.File.Exists(args[0]))
                throw new Exception("File or directory does not exist");

            sceneFileRenamer.Rename(args[0]);
        }
    }
}
