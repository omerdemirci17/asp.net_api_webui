using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_WEBUI_1.DTO.DTOs.ClientDTOs
{
    public class UpdateClientDTO
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ImageUrl { get; set; }
    }
}
