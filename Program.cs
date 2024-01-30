using System.IO;
using System.Text;

namespace FolderContent
{
    internal class Program
    {
        static void PrintDirContent(string dir, bool deeper = true)
        {
            if (!Directory.Exists(dir))
            {
                return;
            }

            StringBuilder sb = new StringBuilder("");
            if (!deeper)
            {
                sb.Append("\t");
            }
            Console.WriteLine();
            string[] entries = Directory.GetFileSystemEntries(dir);
            List<string> dirs = new List<string>();
            Console.WriteLine(sb + $"Content of {dir}:\n");
            foreach (string entry in entries)
            {
                FileInfo fi = new FileInfo(entry);
                string info = "<DIR>";
                if (deeper) {
                    dirs.Add(fi.FullName);
                }
                if (!fi.Attributes.HasFlag(FileAttributes.Directory))
                {
                    info = fi.Length.ToString();
                }
                Console.WriteLine(sb+$"{fi.CreationTime,-22} {fi.Name,-50} {info,-15}");
            }
            foreach (var item in dirs)
            {
                PrintDirContent(item, false);
            }
        }
        static void Main(string[] args)
        {
            PrintDirContent(@"C:\work");
        }
    }
}