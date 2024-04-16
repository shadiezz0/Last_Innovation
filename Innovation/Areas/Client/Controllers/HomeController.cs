using Innovation.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Services.IServices;

namespace Innovation.Areas.Client.Controllers
{
	[Area("Client")]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;

        private readonly IHeaderServ _headerServ;
        private readonly IAboutServ _aboutServ;
        private readonly IMyServiceServ _myServices;
        private readonly IContactServ _contactServ;
        private readonly ITeamServ _teamServ;
        private readonly IWorkServ _workServ;

		public HomeController(IHeaderServ headerServ, IAboutServ aboutServ, IMyServiceServ myServices, IContactServ contactServ, ITeamServ teamServ
            , IWorkServ workServ , IStringLocalizer<HomeController> localizer)
        {
            _headerServ = headerServ;
            _aboutServ = aboutServ;
            _myServices = myServices;
            _contactServ = contactServ;
            _teamServ = teamServ;
            _workServ = workServ;
            _localizer = localizer;
		}

		[HttpPost]
		public IActionResult SetLanguage(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
				);

			return LocalRedirect(returnUrl);
		}


		private string GetCurrentCulture()
		{
			var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
			return requestCulture?.RequestCulture?.Culture?.Name;
		}


		public async Task<IActionResult> Index()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);

            viewModel.myServices = await _myServices.GetAllAsync();

            viewModel.Abouts = await _aboutServ.GetAllAsync();
            viewModel.Abouts = viewModel.Abouts.Take(1);

            viewModel.Contacts = await _contactServ.GetAllAsync();
            viewModel.Contacts = viewModel.Contacts.Take(1);


			string culture = GetCurrentCulture();
			ViewBag.Culture = culture;

			if (culture == "en")
			{
				viewModel.Headers = await _headerServ.GetEnglishDataAsync();
				viewModel.Abouts = await _aboutServ.GetEnglishDataAsync();
				viewModel.Contacts = await _contactServ.GetEnglishDataAsync();

			}
			else
			{
				viewModel.Headers = await _headerServ.GetArabicDataAsync();
				viewModel.Abouts = await _aboutServ.GetArabicDataAsync();
				viewModel.Contacts = await _contactServ.GetArabicDataAsync();
			}

			return View(viewModel);
        }


		public async Task<IActionResult> AboutUs()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(2);

            viewModel.Abouts = await _aboutServ.GetAllAsync();
            viewModel.Abouts = viewModel.Abouts.Take(1);

			string culture = GetCurrentCulture();
			ViewBag.Culture = culture;

			if (culture == "en")
			{
				viewModel.Headers = await _headerServ.GetEnglishDataAsync();
				viewModel.Abouts = await _aboutServ.GetEnglishDataAsync();

			}
			else
			{
				viewModel.Headers = await _headerServ.GetArabicDataAsync();
				viewModel.Abouts = await _aboutServ.GetArabicDataAsync();
			}

			return View(viewModel);
        }


        public async Task<IActionResult> Contact()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);

            viewModel.Contacts = await _contactServ.GetAllAsync();
            viewModel.Contacts = viewModel.Contacts.Take(1);


			string culture = GetCurrentCulture();
			ViewBag.Culture = culture;

			if (culture == "en")
			{
				viewModel.Headers = await _headerServ.GetEnglishDataAsync();
				viewModel.Contacts = await _contactServ.GetEnglishDataAsync();

			}
			else
			{
				viewModel.Headers = await _headerServ.GetArabicDataAsync();
				viewModel.Contacts = await _contactServ.GetArabicDataAsync();
			}

			return View(viewModel);
        }


        public async Task<IActionResult> Team()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);

            viewModel.Teams = await _teamServ.GetAllAsync();


			string culture = GetCurrentCulture();
			ViewBag.Culture = culture;

			if (culture == "en")
			{
				viewModel.Headers = await _headerServ.GetEnglishDataAsync();
				viewModel.Teams = await _teamServ.GetEnglishDataAsync();

			}
			else
            {
				viewModel.Headers = await _headerServ.GetArabicDataAsync();
				viewModel.Teams = await _teamServ.GetArabicDataAsync();
			}

			return View(viewModel);
        }


        public async Task<IActionResult> Servicess()
        {
            string secretKey = "myClientSecretKey";
            if (!Request.Cookies.ContainsKey(secretKey))
                return RedirectToAction("Index", "Account");

            ViewModel viewModel = new ViewModel();

            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);

            viewModel.myServices = await _myServices.GetAllAsync();

			string culture = GetCurrentCulture();
			ViewBag.Culture = culture;

			if (culture == "en")
			{
				viewModel.Headers = await _headerServ.GetEnglishDataAsync();
				viewModel.myServices = await _myServices.GetEnglishDataAsync();

			}
			else
			{
				viewModel.Headers = await _headerServ.GetArabicDataAsync();
				viewModel.myServices = await _myServices.GetArabicDataAsync();
			}

			return View(viewModel);
        }


        public async Task<IActionResult> Works()
        {
            ViewModel viewModel = new ViewModel();

            viewModel.Headers = await _headerServ.GetAllAsync();
            viewModel.Headers = viewModel.Headers.Take(1);

            viewModel.myWorks = await _workServ.GetAllAsync();


			string culture = GetCurrentCulture();
			ViewBag.Culture = culture;

			if (culture == "en")
			{
				viewModel.Headers = await _headerServ.GetEnglishDataAsync();
				viewModel.myWorks = await _workServ.GetEnglishDataAsync();

			}
			else
			{
				viewModel.Headers = await _headerServ.GetArabicDataAsync();
				viewModel.myWorks = await _workServ.GetArabicDataAsync();
			}

			return View(viewModel);
        }




	}
}



