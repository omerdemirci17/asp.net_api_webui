using API_WEBUI_1.WebUI.DTOs.UserDTOs;
using API_WEBUI_1.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Controllers
{
    public class RegisterController(IUserService _userService) : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(UserRegisterDTO userRegisterDTO)
        {
            var result = await _userService.CreateUserAsync(userRegisterDTO);
            if (!result.Succeeded || !ModelState.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
                return View();
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
