using Microsoft.AspNetCore.Mvc;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string secretKey = "mySecretKey";
            if (Request.Cookies.ContainsKey(secretKey))
                return View();
            else
                return RedirectToAction("Login", "UserAdmin");
        }
    }
}
