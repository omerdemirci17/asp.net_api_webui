 using Microsoft.AspNetCore.Mvc;
using API_WEBUI_1.WebUI.DTOs.UserDTOs;
using API_WEBUI_1.WebUI.Services.UserServices;

namespace API_WEBUI_1.WebUI.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDTO userLoginDTO)
        {
            var userRole = await _userService.LoginAsync(userLoginDTO);

            if (userRole == "Admin")
            {
                return RedirectToAction("Index", "Home", new {area = "Admin"});
            }

            if (userRole == "Employee")
            {
                return RedirectToAction("Index", "Home");
            }

            if (userRole == "Customer")
            {
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ModelState.AddModelError("", "Email or Password is incorrect");
                return View();
            }

        }
    }
}
