using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
