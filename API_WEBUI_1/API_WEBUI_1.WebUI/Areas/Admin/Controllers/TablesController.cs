using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_WEBUI_1.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TablesController : Controller
    {

        public IActionResult Tables()
        {
            return View();
        }
    }
}
