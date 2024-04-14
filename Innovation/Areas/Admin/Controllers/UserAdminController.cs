using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Services.DTOs;
using Services.IServices;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserAdminController : Controller
    {
        private readonly IUserServ _userServ;

        public UserAdminController(IUserServ userServ)
        {
            _userServ = userServ;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var isUser = await _userServ.AuthenticateAsync(model.Email, model.Password);
            if (!isUser)
            {
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return View(model);
            }
            string secretKey = "mySecretKey";

            Response.Cookies.Append(secretKey, secretKey);

            return RedirectToAction("Index", "Home"); 

        }

    }
}
