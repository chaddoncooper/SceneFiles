using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.IO.Abstractions;

namespace SceneFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ServiceCollection().BuildServiceProvider();

            var sceneRenamer = serviceProvider.GetRequiredService<ISceneRenamer>();
            var fileSystem = serviceProvider.GetRequiredService<IFileSystem>();

            if (!fileSystem.File.Exists(args[0]) && !fileSystem.Directory.Exists(args[0]))
                throw new Exception(string.Format("File or directory does not exist: {0}", args[0]));

            sceneRenamer.RenameFileOrDirectory(args[0]);
        }

        private static IServiceCollection ServiceCollection()
        {
            return new ServiceCollection()
                .AddLogging()
                .AddSingleton(LoadConfiguration())
                .AddSingleton<IFileSystem, FileSystem>()
                .AddTransient<IFileAndDirectoryRenamer, FileAndDirectoryRenamer>()
                .AddTransient<ISceneRenamer, GenericSceneRenamer>();
        }


        private static AppSettings LoadConfiguration()
        {
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
