using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class SaveFileLocator
    {
        public string GetSaveDataFileName(string userDataFolder)
        {
            var directories = Directory.GetDirectories(userDataFolder);

            foreach (var directory in directories)
            {
                var files = Directory.GetFiles(directory);
                var saveDataFile = files.FirstOrDefault(file => file.EndsWith(".sl2"));
                if (!string.IsNullOrEmpty(saveDataFile))
                {
                    return saveDataFile;
                }
            }

            return null;
        }
    }
}
