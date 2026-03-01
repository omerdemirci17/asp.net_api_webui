using API_WEBUI_1.WebUI.DTOs.ContactDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDTO>>("Contact");
            return View(values);
        }

        public IActionResult CreateContact()
        {
            return View(new CreateContactDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
                return View(createContactDto);

            await _client.PostAsJsonAsync("Contact", createContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateContactDto>($"Contact/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _client.PutAsJsonAsync("Contact", updateContactDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Contact/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
