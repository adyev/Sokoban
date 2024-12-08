
using System.IO;

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

        public static int GetLevelCount()
        {
            return new DirectoryInfo($"{GetRootDir()}\\Content\\Levels").GetDirectories().Length;
        }
    }
}
