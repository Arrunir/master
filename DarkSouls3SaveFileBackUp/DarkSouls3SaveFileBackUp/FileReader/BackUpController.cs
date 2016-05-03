using System.IO;
using static DarkSouls3SaveFileBackUp.AppConstants;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class BackUpController
    {
        private SaveFileLocator _fileLocator;
        private SaveFileReader _fileReader;
        private SaveFileWriter _saveFileWriter;
        private string _lastBackUpPath;

        public BackUpController()
        {
            _fileLocator = new SaveFileLocator();
            _fileReader = new SaveFileReader();
            _saveFileWriter = new SaveFileWriter();
        }

        public string LastBackUpPath
        {
            get
            {
                return _lastBackUpPath;
            }
        }

        public bool BackUpSaveData()
        {
            var backUpFolder = Settings.BackUpFolder;
            var saveFileName = GetSaveDataFileName();

            if(string.IsNullOrEmpty(saveFileName))
            {
                return false;
            }

            try
            {
                var saveDatafileContent = ReadSaveDataFile(saveFileName);
                _lastBackUpPath = _saveFileWriter.WriteSaveFile(saveDatafileContent, Path.GetFileName(saveFileName), backUpFolder);
            }
            catch(IOException ex)
            {
                return false;
            }
            return true;
        }

        private string GetSaveDataFileName()
        {
            var userDataFolder = Settings.UserDataFolder;
            var saveFileName = _fileLocator.GetSaveDataFileName(userDataFolder);
            return saveFileName;
        }

        private byte[] ReadSaveDataFile(string saveDataFileName)
        {
            var saveDataFileContent = _fileReader.ReadSaveDataFile(saveDataFileName);
            return saveDataFileContent;
        }
    }
}
