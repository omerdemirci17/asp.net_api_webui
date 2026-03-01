using API_WEBUI_1.WebUI.DTOs.MessageDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMessageDTO>>("Message");
            return View(values);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultMessageDTO>($"Message/{id}");
            return View(value);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Message/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
