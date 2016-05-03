using System.IO;
using System.Linq;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class SaveFileReader
    {
        public byte[] ReadSaveDataFile(string saveDataFileName)
        {
            var saveDataFolder = Directory.GetParent(saveDataFileName);
            var saveDataFileInfo = new FileInfo(saveDataFileName);
            byte[] saveDataFileContent = null;
            using (var stream = saveDataFileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                byte[] buffer = new byte[stream.Length];
                using (var memoryStream = new MemoryStream())
                {
                    int read;
                    while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, read);
                    }
                    saveDataFileContent = memoryStream.ToArray();
                }
            }
            return saveDataFileContent;
        }
    }
}
