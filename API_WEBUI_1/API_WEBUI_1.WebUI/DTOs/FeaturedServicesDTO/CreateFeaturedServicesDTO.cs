using API_WEBUI_1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.FeaturedServicesDTO
{
    public class CreateFeaturedServicesDTO
    {
        public int FeaturedServicesID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ServiceCategoryID { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
    }
}
