using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.IServices;

namespace Innovation.Areas.Client.Controllers
{
    [Area("Client")]
    public class AccountController : Controller
    {
        private readonly IUserServ _userServ;
        public AccountController(IUserServ userServ)
        {
            _userServ = userServ;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> logInPost([FromForm] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isUser = await _userServ.AuthenticateClienttAsync(model.Email, model.Password);
            if (!isUser)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }
            string secretKey = "myClientSecretKey";

            Response.Cookies.Append(secretKey, secretKey);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegistrationPost([FromForm] RegistrationDto model)
        {
            var isUserAdded = await _userServ.AddUser(model);
            if (isUserAdded)
                 return RedirectToAction("Index");
            return RedirectToAction("Registration");
        }
    }
}
