using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Services;

namespace MVCProject.Controllers
{

    
    public class GalleryController : Controller
      {
        IImageService imageService;
        public GalleryController(IImageService service)
        {
            this.imageService = service;
        }

        
       
        [HttpGet("addimage",Name = "GetImage")]
        public IActionResult GetImage()
        {
            ViewBag.Images = imageService.GetImages();
            return View();
        }
        //[HttpPost("addimage", Name = "addimage")]
        //public  async Task<IActionResult> AddImage (ImageData imageData,IFormFile file)
        //{

        //     return View();
        //}

        [HttpPost("addimage", Name = "AddImage")]
        public async Task<IActionResult> AddImage(ImageData imageData, IFormFile file)
        {


            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images", file.FileName);
            
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            imageData.Id = new Guid();
            imageData.ImageUrl = file.FileName;
            imageData.PostedBy = "Vignesh";
            imageData.PostedDate = DateTime.Now;


            imageService.AddImages(imageData);
            return RedirectToAction("GetImage");

        }
    }
}