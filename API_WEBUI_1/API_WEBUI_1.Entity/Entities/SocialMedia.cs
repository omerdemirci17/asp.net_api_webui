using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.Entity.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
