using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSouls3SaveFileBackUp
{
    public static class AppConstants
    {
        public const string UserDataFolderSetting = "UserDataFolder";
        public const string BackUpFolderSetting = "BackUpFolder";
        internal static Properties.Settings Settings = Properties.Settings.Default;
    }
}
