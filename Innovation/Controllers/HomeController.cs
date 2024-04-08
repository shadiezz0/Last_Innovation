using Core.Interfaces.InterfacesPages;
using Innovation.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System.Diagnostics;

namespace Innovation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeaderServ _headerServ;
        private readonly IAboutServ _aboutServ;
        private readonly IMyServiceServ _myServices;

        public HomeController(IHeaderServ headerServ , IAboutServ aboutServ , IMyServiceServ myServices)
        {
            _headerServ = headerServ;
            _aboutServ = aboutServ;
            _myServices = myServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Abouts = await _aboutServ.GetAllAsync();
            viewModel.myServices = await _myServices.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);
            viewModel.Abouts = viewModel.Abouts.Take(1);
            return View(viewModel);
        }

    }
}
