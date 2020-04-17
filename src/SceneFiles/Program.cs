using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.IO.Abstractions;

namespace SceneFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileSystem = new FileSystem();

            var fileAndDirectoryRenamer = new FileAndDirectoryRenamer(fileSystem); 

            var sceneFileRenamer = new GenericSceneRenamer(fileAndDirectoryRenamer, LoadConfiguration());

            if (!fileSystem.File.Exists(args[0]) && !fileSystem.Directory.Exists(args[0]))
                throw new Exception(string.Format("File or directory does not exist: {0}", args[0]));

            sceneFileRenamer.RenameFileOrDirectory(args[0]);
        }


        private static AppSettings LoadConfiguration()
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true,
                             reloadOnChange: true);
            var appSettingsJson =  builder.Build().Get<AppSettings>();
            if (appSettingsJson == null)
            {
                return new AppSettings();
            }
            return appSettingsJson;
        }
    }
}
