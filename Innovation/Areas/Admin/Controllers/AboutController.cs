using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutServ _aboutServ;

        public AboutController(IAboutServ aboutServ)
        {
            _aboutServ = aboutServ;
        }


        public async Task<IActionResult> AboutInfo()
        {
            var abouts = await _aboutServ.GetAllAsync();
            return View(abouts);
        }


        public async Task<IActionResult> Create(int? id)
		{
			if (id.HasValue && id != 0)
			{
                var abouts = await _aboutServ.GetByIdAsync(id.Value);
                if (abouts != null)
                {
                    return View(abouts);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
				return View(new About());
			}
		}


        [HttpPost]
        public async Task<IActionResult> Save(About about, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\UploadAbout", Image);
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        about.Image = Image;
                    }
                }

                if (about.Id == 0 || about.Id == null)
                {
                    await _aboutServ.AddAsync(about);
                }
                else
                {
                    await _aboutServ.UpdateAsync(about);
                }
                return RedirectToAction(nameof(AboutInfo));
            }
            else
            {
                return View("Create", about);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _aboutServ.DeleteAsync(Id);
            return RedirectToAction(nameof(AboutInfo));
        }
    }
}
