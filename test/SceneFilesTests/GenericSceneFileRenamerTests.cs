using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using SceneFiles;
using Xunit;

namespace SceneFilesTests
{
    public class GenericSceneFileRenamerTests
    {
        [Theory]
        [InlineData(@"c:\This.is.my.filename.with.an.extension.lol", @"c:\This Is My Filename With an Extension.lol")]
        [InlineData(@"c:\This Is My Filename 1999 With a Year 2001.lol", @"c:\This Is My Filename 1999 With a Year (2001).lol")]
        public void GenericRenameFile(string pathBeforeRename, string pathAfterRename)
        {
            var fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
            {
                { pathBeforeRename, new MockFileData("") },
            });

            new GenericSceneFileRenamer(new FileAndDirectoryRenamer(fileSystem)).Rename(pathBeforeRename);

            Assert.True(fileSystem.File.Exists(pathAfterRename));
            Assert.False(fileSystem.File.Exists(pathBeforeRename));
        }
    }
}
