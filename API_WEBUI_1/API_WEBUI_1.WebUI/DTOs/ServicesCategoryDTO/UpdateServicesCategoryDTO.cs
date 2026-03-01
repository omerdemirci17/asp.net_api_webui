using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_WEBUI_1.WebUI.DTOs.ServiceDTOs;


namespace API_WEBUI_1.WebUI.DTOs.ServicesCategoryDTO
{
    public class UpdateServicesCategoryDTO
    {
        public int ServiceCategoryID { get; set; }
        public string Name { get; set; }
        public List<ResultServiceDTO> ResultServices { get; set; } = new();
    }
}
