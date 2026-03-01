using API_WEBUI_1.WebUI.DTOs.AboutDTOs;
using API_WEBUI_1.WebUI.DTOs.BannerDtos;
using API_WEBUI_1.WebUI.DTOs.BannerDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDTO>>("Banner");
            return View(values);
        }

        public IActionResult CreateBanner()
        {
            return View(new CreateBannerDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            if (!ModelState.IsValid)
                return View(createBannerDto);

            await _client.PostAsJsonAsync("Banner", createBannerDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBannerDto>($"Banner/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            await _client.PutAsJsonAsync("Banner", updateBannerDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Banner/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
