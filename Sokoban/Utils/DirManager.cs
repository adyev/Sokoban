using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Utils
{
    internal class DirManager
    {
        public static string GetRootDir()
        {
            var dirInfo = new DirectoryInfo(".");
            while (!dirInfo.Name.Equals("Sokoban"))
            {
                dirInfo = new DirectoryInfo($"{dirInfo.FullName}\\..");
            }
            return dirInfo.FullName;
        }
    }
}
