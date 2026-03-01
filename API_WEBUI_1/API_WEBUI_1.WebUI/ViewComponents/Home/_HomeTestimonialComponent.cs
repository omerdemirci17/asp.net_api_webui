using API_WEBUI_1.WebUI.DTOs.TestimonialDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.ViewComponents.Home
{
    public class _HomeTestimonialComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonial");
            return View(values);
        }
    }
}
