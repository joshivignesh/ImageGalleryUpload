using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Services
{
    public interface IImageService
    {
        //Dictionary<string, string> GetImages();
        IEnumerable<ImageData> GetImages();
        ImageData AddImages(ImageData imageData);
    }
}
