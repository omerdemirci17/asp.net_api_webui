using API_WEBUI_1.DTO.DTOs.ServiceDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.DTO.DTOs.ServicesCategoryDTO
{
    public class CreateServicesCategoryDTO
    {
        public int ServiceCategoryID { get; set; }
        public string Name { get; set; }
        public List<ResultServiceDTO> ResultServices { get; set; } = new();
    }
}
