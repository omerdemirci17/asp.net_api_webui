using API_WEBUI_1.WebUI.DTOs.ServiceDTOs;

namespace API_WEBUI_1.WebUI.DTOs.ServicesCategoryDTO
{
    public class ResultServicesCategoryDTO
    {
        public int ServiceCategoryID { get; set; }
        public string Name { get; set; }
        public List<ResultServiceDTO> ResultServices { get; set; } = new();
    }
}
