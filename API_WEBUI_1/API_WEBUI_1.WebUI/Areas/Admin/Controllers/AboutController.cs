using API_WEBUI_1.WebUI.DTOs.AboutDtos;
using API_WEBUI_1.WebUI.DTOs.AboutDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDTO>>("About");
            return View(values);
        }

        public IActionResult CreateAbout()
        {
            return View(new CreateAboutDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDto)
        {
            if (!ModelState.IsValid)
                return View(createAboutDto);

            await _client.PostAsJsonAsync("About", createAboutDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateAboutDto>($"About/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync("About", updateAboutDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"About/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
