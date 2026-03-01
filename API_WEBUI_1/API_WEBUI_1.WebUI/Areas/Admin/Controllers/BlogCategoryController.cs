using API_WEBUI_1.WebUI.DTOs.BlogCategoryDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("BlogCategory");
            return View(values);
        }

        public IActionResult CreateBlogCategory()
        {
            return View(new CreateBlogCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto createBlogCategoryDto)
        {
            if (!ModelState.IsValid)
                return View(createBlogCategoryDto);

            await _client.PostAsJsonAsync("BlogCategory", createBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBlogCategoryDto>($"BlogCategory/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            await _client.PutAsJsonAsync("BlogCategory", updateBlogCategoryDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"BlogCategory/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
