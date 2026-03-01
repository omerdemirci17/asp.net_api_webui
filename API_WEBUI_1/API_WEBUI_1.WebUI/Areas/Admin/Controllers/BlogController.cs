using API_WEBUI_1.WebUI.DTOs.BlogDTOs;
using API_WEBUI_1.WebUI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("Blog");
            return View(values);
        }

        public IActionResult CreateBlog()
        {
            return View(new CreateBlogDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            if (!ModelState.IsValid)
                return View(createBlogDto);

            await _client.PostAsJsonAsync("Blog", createBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateBlog(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBlogDto>($"Blog/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _client.PutAsJsonAsync("Blog", updateBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"Blog/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
