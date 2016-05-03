using System;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class BackUpFolderNameGenerator
    {
        public static string GenerateFolderName()
        {
            var folderName = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
            return folderName;
        }
    }
}
