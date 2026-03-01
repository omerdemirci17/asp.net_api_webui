using API_WEBUI_1.WebUI.DTOs.ServiceDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.ViewComponents.Home
{
    public class _HomeService2Component : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultServiceDTO>>("Service");
            return View(values);
        }
    }
}
