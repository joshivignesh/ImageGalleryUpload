using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCProject.Models
{
    public class ImageData
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public DateTime PostedDate { get; set; }
        public string PostedBy { get; set; }
    }
}
