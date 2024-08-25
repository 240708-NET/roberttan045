using System.Collections.Generic;

namespace RotatingImageGallery
{
    public interface IImageRepository
    {
        void AddImage(Image image);
        IEnumerable<Image> GetAllImages();
    }
}