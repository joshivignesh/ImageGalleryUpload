using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {

        //GET/blog/new
        [HttpGet("new",Name ="addblog")]
        public IActionResult Create()
        {
            return View();
        }
        //POST/blog/new
        [HttpPost("new",Name ="addblog")]
        public IActionResult Create(Blog blog )
        {
            return View();
        }
    }
}