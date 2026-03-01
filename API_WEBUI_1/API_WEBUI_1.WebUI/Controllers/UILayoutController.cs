using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        [Route("[controller]/[action]/{id?}")]

        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
