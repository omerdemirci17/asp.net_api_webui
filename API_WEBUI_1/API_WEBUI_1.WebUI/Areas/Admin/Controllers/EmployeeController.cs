using API_WEBUI_1.WebUI.DTOs.EmployeeDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultEmployeeDTO>>("Employee");
            return View(values);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Employee/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateEmployee()
        {
            return View(new CreateEmployeeDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDTO createEmployeeDto)
        {
            await _client.PostAsJsonAsync("Employee", createEmployeeDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateEmployeeDTO>($"Employee/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDTO updateEmployeeDto)
        {
            await _client.PutAsJsonAsync("Employee", updateEmployeeDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
