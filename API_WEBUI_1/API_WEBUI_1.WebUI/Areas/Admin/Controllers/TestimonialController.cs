using API_WEBUI_1.WebUI.DTOs.TestimonialDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDTO>>("Testimonial");
            return View(values);
        }

        public IActionResult CreateTestimonial()
        {
            return View(new CreateTestimonialDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createDto)
        {
            if (!ModelState.IsValid)
                return View(createDto);

            await _client.PostAsJsonAsync("Testimonial", createDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateTestimonialDto>($"Testimonial/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateDto)
        {
            await _client.PutAsJsonAsync("Testimonial", updateDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Testimonial/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
