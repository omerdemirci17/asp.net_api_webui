using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
