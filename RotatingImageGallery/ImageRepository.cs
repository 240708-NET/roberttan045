using System.Collections.Generic;

namespace RotatingImageGallery
{
    public class ImageRepository : IImageRepository
    {
        private List<Image> _images = new List<Image>();

        public void AddImage(Image image)
        {
            _images.Add(image);
        }

        public IEnumerable<Image> GetAllImages()
        {
            return _images;
        }
    }
}