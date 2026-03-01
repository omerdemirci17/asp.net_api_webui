using API_WEBUI_1.WebUI.DTOs.SubscriberDtos;
using API_WEBUI_1.WebUI.DTOs.SubscriberDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDTO>>("Subscriber");
            return View(values);
        }

        public IActionResult CreateSubscriber()
        {
            return View(new CreateSubscriberDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto createDto)
        {
            if (!ModelState.IsValid)
                return View(createDto);

            await _client.PostAsJsonAsync("Subscriber", createDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateSubscriber(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"Subscriber/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto updateDto)
        {
            await _client.PutAsJsonAsync("Subscriber", updateDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Subscriber/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
