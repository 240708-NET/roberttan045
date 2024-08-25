using System;

namespace RotatingImageGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of ImageRepository
            IImageRepository imageRepository = new ImageRepository();

            // Pass the repository to the ImageGallery constructor
            var gallery = new ImageGallery(imageRepository);

            // Adding images to the repository
            imageRepository.AddImage(new Image("Cherry Blossom", @"c:\Users\huynh\OneDrive\Pictures\cherry blossom.jpg"));
            imageRepository.AddImage(new Image("DnD Hydra Tiamat", @"c:\Users\huynh\OneDrive\Pictures\game-dungeons-and-dragons-hydra-tiamat-dungeons-and-dragons-wallpaper-preview.jpg"));
            imageRepository.AddImage(new Image("Mario", @"c:\Users\huynh\OneDrive\Pictures\Mario.jpg"));

            Console.WriteLine("Press Enter to rotate images, or type 'exit' to quit:");

            // Loop to rotate images based on user input
            while (true)
            {
                var input = Console.ReadLine();
                if (input?.ToLower() == "exit") break;

                gallery.Rotate();
            }
        }
    }
}