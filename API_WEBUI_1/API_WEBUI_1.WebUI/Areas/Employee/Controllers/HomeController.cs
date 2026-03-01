using API_WEBUI_1.WebUI.Services.UserServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace API_WEBUI_1.WebUI.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class HomeController( UserService _userService ) : Controller
    {

        public async Task<IActionResult> Index()
        {
            
            return View();
        }
    }
}
