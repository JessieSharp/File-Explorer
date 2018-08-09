using System.IO;
using System.Linq;

namespace File_Explorer.Extensions
{
    public class Helpers
    {
        public static long GetDirectorySize(string p)
        {
            var a = Directory.GetFiles(p, "*.*", SearchOption.AllDirectories);
            return a.Select(name => new FileInfo(name)).Select(info => info.Length).Sum();
        }

        public static double ConvertBytesToMegabytes(long bytes)
        {
            return bytes / 1024f / 1024f;
        }
    }
}