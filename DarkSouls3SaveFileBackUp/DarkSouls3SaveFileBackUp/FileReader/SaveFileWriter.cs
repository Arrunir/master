using System.IO;
using System.Linq;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class SaveFileWriter
    {
        public string WriteSaveFile(byte[] saveFileContent, string saveFileName, string saveFolder)
        {
            var backUpFolderName = BackUpFolderNameGenerator.GenerateFolderName();
            CreateBackUpFulder(saveFolder, backUpFolderName);

            var fileFullName = Path.Combine(saveFolder, backUpFolderName, saveFileName);
            using (var stream = File.Create(fileFullName))
            {
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(saveFileContent);
                    writer.Flush();
                }
            }
            return fileFullName;
        }

        private void CreateBackUpFulder(string saveFolder, string backUpFolderName)
        {
            var backUpFolders = Directory.GetDirectories(saveFolder);
            if(!backUpFolders.Contains(saveFolder))
            {
                Directory.CreateDirectory(Path.Combine(saveFolder, backUpFolderName));
            }
        }
   }
}
