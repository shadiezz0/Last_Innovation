using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderController : Controller
    {
        private readonly IHeaderServ _headerServ;
        public HeaderController(IHeaderServ headerServ)
        {
            _headerServ = headerServ;
        }


        public async Task<IActionResult> Slider()
        {
            var Sliders = await _headerServ.GetAllAsync();
            return View(Sliders);
        }

        public async Task<IActionResult> Create(int? id)
        {
            if (id.HasValue && id != 0)
            {
                var slider = await _headerServ.GetByIdAsync(id.Value);
                if (slider != null)
                {
                    return View(slider);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return View(new Header()); 
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(Header slider , List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Upload", Image);
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        slider.Image = Image;
                    }
                }

                if (slider.Id == 0 || slider.Id == null)
                {
                    await _headerServ.AddAsync(slider);
                }
                else
                {
                    await _headerServ.UpdateAsync(slider);
                }
                return RedirectToAction(nameof(Slider));
            }
            else
            {
                return View("Create", slider);
            }
        }


        public async Task<IActionResult> Delete(int Id)
        {
             await _headerServ.DeleteAsync(Id);
            return RedirectToAction("Slider");
        }


    }
}
