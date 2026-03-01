using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.Entity.Entities
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ImageUrl { get; set; }
        public bool IsShown { get; set; }
    }
}
