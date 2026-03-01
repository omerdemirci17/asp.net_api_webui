using API_WEBUI_1.WebUI.DTOs.ContactDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;

namespace API_WEBUI_1.WebUI.ViewComponents._UILayout
{
    public class _UILayoutContactComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDTO>>("Contact");
            return View(values);
        }
    }
}
