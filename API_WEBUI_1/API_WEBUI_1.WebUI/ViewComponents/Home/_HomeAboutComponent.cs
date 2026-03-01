using API_WEBUI_1.WebUI.DTOs.AboutDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
namespace API_WEBUI_1.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDTO>>("About");
            return View(values);
        }
    } 
}
