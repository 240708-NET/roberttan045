using System.Linq;

namespace RotatingImageGallery
{
    public class ImageGallery
    {
        private IImageRepository _imageRepository;
        private int _currentIndex;

        public ImageGallery(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
            _currentIndex = 0;
        }

        public void Rotate()
        {
            var images = _imageRepository.GetAllImages();
            if (!images.Any())
            {
                Console.WriteLine("No images in the gallery.");
                return;
            }

            var image = images.ElementAt(_currentIndex);
            image.Display();
            _currentIndex = (_currentIndex + 1) % images.Count();
        }
    }
}