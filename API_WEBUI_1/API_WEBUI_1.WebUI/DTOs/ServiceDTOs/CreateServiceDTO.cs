using API_WEBUI_1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.ServiceDTOs
{
    public class CreateServiceDTO
    {
        public int ServiceID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ServiceCategoryID { get; set; }
        public ServiceCategory? ServiceCategory { get; set; } 
    }
}
