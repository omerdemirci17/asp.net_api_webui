using API_WEBUI_1.WebUI.DTOs.SocialMediaDtos;
using API_WEBUI_1.WebUI.DTOs.SocialMediaDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDTO>>("SocialMedia");
            return View(values);
        }

        public IActionResult CreateSocialMedia()
        {
            return View(new CreateSocialMediaDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createDto)
        {
            if (!ModelState.IsValid)
                return View(createDto);

            await _client.PostAsJsonAsync("SocialMedia", createDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSocialMediaDto>($"SocialMedia/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateDto)
        {
            await _client.PutAsJsonAsync("SocialMedia", updateDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"SocialMedia/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
