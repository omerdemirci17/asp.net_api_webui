using API_WEBUI_1.WebUI.DTOs.ServicesCategoryDTO;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ServicesCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultServicesCategoryDTO>>("ServiceCategory");
            return View(values);
        }

        public IActionResult CreateServicesCategory()
        {
            return View(new CreateServicesCategoryDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateServicesCategory(CreateServicesCategoryDTO createDto)
        {
            if (!ModelState.IsValid)
                return View(createDto);

            await _client.PostAsJsonAsync("ServiceCategory", createDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateServicesCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateServicesCategoryDTO>($"ServiceCategory/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateServicesCategory(UpdateServicesCategoryDTO updateDto)
        {
            await _client.PutAsJsonAsync("ServiceCategory", updateDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"ServiceCategory/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
