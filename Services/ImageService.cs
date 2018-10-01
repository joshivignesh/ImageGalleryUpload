using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCProject.Models;

namespace MVCProject.Services
{
    public class ImageService : IImageService
    {
        private Dictionary<string, string> images = new Dictionary<string, string>
        {
            { "img1","1.jpg" },
            { "img2","2.jpg" },
            { "img3","3.jpg" },
            { "img4","4.jpg" }

        };
        //public Dictionary<string, string> GetImages()
        //{

        //    return images;
            
        //}
        public IEnumerable<ImageData> GetImages()
        {

            using (ImageContext db = new ImageContext())
            {

               var images= db.ImageData.ToList();
                return images;
            }

        }
       public ImageData AddImages(ImageData imageData)
        {
            using (ImageContext db= new ImageContext())
            {
                db.ImageData.Add(imageData);
                db.SaveChanges();
                return imageData;
            }
            //    images.Add(imageData.Caption, imageData.ImageUrl);
        }
    }
}
