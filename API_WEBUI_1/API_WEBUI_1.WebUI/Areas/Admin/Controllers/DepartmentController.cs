using Microsoft.AspNetCore.Mvc;
using API_WEBUI_1.WebUI.Helpers;
using API_WEBUI_1.WebUI.DTOs.DepartmentDTOs;
using Microsoft.AspNetCore.Authorization;


namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultDepartmentDTO>>("Department");
            return View(values);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Department/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateDepartment()
        {
            return View(new CreateDepartmentDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(CreateDepartmentDTO createDepartmentDto)
        {
            await _client.PostAsJsonAsync("Department", createDepartmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateDepartment(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateDepartmentDTO>($"Department/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDTO updateDepartmentDto)
        {
            await _client.PutAsJsonAsync("Department", updateDepartmentDto);
            return RedirectToAction(nameof(Index));
        }


    }
}
