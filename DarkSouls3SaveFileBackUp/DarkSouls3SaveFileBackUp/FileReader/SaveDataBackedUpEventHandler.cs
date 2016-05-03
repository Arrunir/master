using System;

namespace DarkSouls3SaveFileBackUp.FileReader
{
    internal class SaveDataBackedUpEventArgs : EventArgs
    {
        internal SaveDataBackedUpEventArgs(string saveFilePath, DateTime timeOfBackUp)
        {
            SaveFilePath = saveFilePath;
            TimeOfBackUp = timeOfBackUp;
        }

        public string SaveFilePath { get; set; }
        public DateTime TimeOfBackUp { get; set; }
    }
}
