 using Microsoft.AspNetCore.Mvc;
using API_WEBUI_1.WebUI.DTOs.CustomerDTOs;
using Microsoft.Extensions.Caching.Hybrid;
using API_WEBUI_1.WebUI.Helpers;
using Azure;
using Microsoft.AspNetCore.Authorization;
using API_WEBUI_1.WebUI.Validators;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCustomerDTO>>("Customer");
            return View(values);
        }
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _client.DeleteAsync($"Customer/{id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateCustomer()
        {
            return View(new CreateCustomerDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO createCustomerDto)
        {
            var validator = new CustomerValidator();
            var result = await validator.ValidateAsync(createCustomerDto);
            if (!result.IsValid)
            {
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View();
            }
            await _client.PostAsJsonAsync("Customer", createCustomerDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCustomerDTO>($"Customer/{id}");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO updateCustomerDto)
        {
           
            var response = await _client.PutAsJsonAsync("Customer",updateCustomerDto);
          
            return RedirectToAction(nameof(Index));
        }
    }

}
