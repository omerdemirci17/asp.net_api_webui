using API_WEBUI_1.WebUI.DTOs.ServiceDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultServiceDTO>>("Service");
            return View(values);
        }

        public IActionResult CreateService()
        {
            return View(new CreateServiceDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDTO createServiceDto)
        {
            if (!ModelState.IsValid)
                return View(createServiceDto);

            await _client.PostAsJsonAsync("Service", createServiceDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateServiceDTO>($"Service/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDTO updateServiceDto)
        {
            await _client.PutAsJsonAsync("Service", updateServiceDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Service/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
