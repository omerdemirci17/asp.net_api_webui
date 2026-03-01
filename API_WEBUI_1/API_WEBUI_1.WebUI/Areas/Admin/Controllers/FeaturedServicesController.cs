using API_WEBUI_1.WebUI.DTOs.FeaturedServicesDTO;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class FeaturedServicesController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeaturedServicesDTO>>("FeaturedServices");
            return View(values);
        }

        public IActionResult CreateFeaturedServices()
        {
            return View(new CreateFeaturedServicesDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedServices(CreateFeaturedServicesDTO createDto)
        {
            if (!ModelState.IsValid)
                return View(createDto);

            await _client.PostAsJsonAsync("FeaturedServices", createDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateFeaturedServices(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateFeaturedServicesDTO>($"FeaturedServices/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeaturedServices(UpdateFeaturedServicesDTO updateDto)
        {
            await _client.PutAsJsonAsync("FeaturedServices", updateDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"FeaturedServices/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
