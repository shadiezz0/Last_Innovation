using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IMyServiceServ _myService;

        public ServiceController(IMyServiceServ myService)
        {
            _myService = myService;
        }
        public async Task<IActionResult> MyService()
        {
            var items = await _myService.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Create(int? id)
		{
			if (id.HasValue && id != 0)
			{
                var items = await _myService.GetByIdAsync(id.Value);
                if (items != null)
                {
                    return View(items);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
				return View(new MyServices());
			}
		}


        [HttpPost]
        public async Task<IActionResult> Save(MyServices myServices, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\UploadService", Image);
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        myServices.Image = Image;
                    }
                }

                if (myServices.Id == 0 || myServices.Id == null)
                {
                    await _myService.AddAsync(myServices);
                }
                else
                {
                    await _myService.UpdateAsync(myServices);
                }
                return RedirectToAction(nameof(MyService));
            }
            else
            {
                return View("Create", myServices);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _myService.DeleteAsync(Id);
            return RedirectToAction(nameof(MyService));
        }
    }
}
