using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.DTO.DTOs.BannerDtos
{
    public class CreateBannerDto
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
