using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using API_WEBUI_1.WebUI.DTOs.ClientDTOs;
using Microsoft.AspNetCore.Authorization;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ClientController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        // GET: Admin/Client/Index
        public async Task<IActionResult> Index()
        {
            var values = await _client
                .GetFromJsonAsync<List<ResultClientDTO>>("Client");
            return View(values);
        }

        // GET: Admin/Client/CreateClient
        public IActionResult CreateClient()
        {
            return View(new CreateClientDTO());
        }

        // POST: Admin/Client/CreateClient
        [HttpPost]
        public async Task<IActionResult> CreateClient(CreateClientDTO createClientDto)
        {
            if (!ModelState.IsValid)
                return View(createClientDto);

            await _client.PostAsJsonAsync("Client", createClientDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Client/UpdateClient/{id}
        public async Task<IActionResult> UpdateClient(int id)
        {
            var value = await _client
                .GetFromJsonAsync<UpdateClientDTO>($"Client/{id}");
            return View(value);
        }

        // POST: Admin/Client/UpdateClient
        [HttpPost]
        public async Task<IActionResult> UpdateClient(UpdateClientDTO updateClientDto)
        {
            await _client.PutAsJsonAsync("Client", updateClientDto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Client/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Client/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
