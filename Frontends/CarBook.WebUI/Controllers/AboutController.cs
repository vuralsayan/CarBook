using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v = "Hakkımızda";    
            ViewBag.v2 = "Hakkımızda";    
            return View();
        }
    }
}
