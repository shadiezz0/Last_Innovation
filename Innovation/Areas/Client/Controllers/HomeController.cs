using Core.Interfaces.InterfacesPages;
using Innovation.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System.Diagnostics;

namespace Innovation.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly IHeaderServ _headerServ;
        private readonly IAboutServ _aboutServ;
        private readonly IMyServiceServ _myServices;
        private readonly IContactServ _contactServ;
        private readonly ITeamServ _teamServ;

        public HomeController(IHeaderServ headerServ, IAboutServ aboutServ, IMyServiceServ myServices, IContactServ contactServ, ITeamServ teamServ)
        {
            _headerServ = headerServ;
            _aboutServ = aboutServ;
            _myServices = myServices;
            _contactServ = contactServ;
            _teamServ = teamServ;
        }

        public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);

            viewModel.Abouts = await _aboutServ.GetAllAsync();
            viewModel.Abouts = viewModel.Abouts.Take(1);

            viewModel.myServices = await _myServices.GetAllAsync();

            return View(viewModel);
        }

        public async Task<IActionResult> AboutUs()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(2);
            viewModel.Abouts = await _aboutServ.GetAllAsync();
            viewModel.Abouts = viewModel.Abouts.Take(1);
            return View(viewModel);
        }

        public async Task<IActionResult> Contact()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Contacts = await _contactServ.GetAllAsync();
            viewModel.Contacts = viewModel.Contacts.Take(1);
            return View(viewModel);
        }

        public async Task<IActionResult> Team()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Teams = await _teamServ.GetAllAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> Servicess()
        {

            string secretKey = "myClientSecretKey";
            if (!Request.Cookies.ContainsKey(secretKey))
                return NotFound();
            Serview serview = new Serview();

            serview.MyServices = await _myServices.GetAllAsync();
            return View(serview);
        }

    }
}