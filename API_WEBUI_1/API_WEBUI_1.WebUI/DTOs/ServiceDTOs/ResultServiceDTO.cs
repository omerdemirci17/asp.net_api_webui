using API_WEBUI_1.Entity.Entities;

namespace API_WEBUI_1.WebUI.DTOs.ServiceDTOs
{
    public class ResultServiceDTO
    {
        public int ServiceID { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ServiceCategoryID { get; set; }
        public ServiceCategory? ServiceCategory { get; set; } 
    }
}
