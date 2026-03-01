using API_WEBUI_1.WebUI.DTOs.MessageDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.ViewComponents.Home
{
    public class _HomeMessageComponent : ViewComponent
    {
        private HttpClient _httpClient = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _httpClient.GetFromJsonAsync<List<ResultMessageDTO>>("Message");
            return View(values);
        }
    }
}
