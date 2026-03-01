using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.WebUI.DTOs.SocialMediaDtos
{
    public class CreateSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int EmployeeID { get; set; }

    }
}
