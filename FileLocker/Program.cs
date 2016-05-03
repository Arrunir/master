using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLocker
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = @"C:\Users\roman\AppData\Roaming\DarkSoulsIII\0110000100cfd861\DS30000.sl2";
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                while(true)
                {
                    var input = Console.ReadLine();
                    if (input == "q")
                    {
                        break;
                    }
                }
            }
        }
    }
}
