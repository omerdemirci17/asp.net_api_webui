using API_WEBUI_1.WebUI.DTOs.SocialMediaDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.ViewComponents._UILayout
{
    public class _UILayoutSocialMediaComponent : ViewComponent
    {
        private readonly HttpClient _httpClient = HttpClientInstance.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedia");
            return View(values);
        }
    }
}
