using System.Diagnostics;
using System.IO;

namespace RotatingImageGallery
{
    public class Image
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Image(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {Name} from {Path}");
            if (File.Exists(Path))
            {
                Process.Start(new ProcessStartInfo(Path) { UseShellExecute = true });
            }
            else
            {
                Console.WriteLine($"File not found: {Path}");
            }
        }
    }
}