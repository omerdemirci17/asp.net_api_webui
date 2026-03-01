using API_WEBUI_1.Entity.Entities;

namespace API_WEBUI_1.WebUI.DTOs.FeaturedServicesDTO
{
    public class ResultFeaturedServicesDTO
    {
        public int FeaturedServicesID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ServiceCategoryID { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }
    }
}
