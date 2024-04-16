using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkController : Controller
    {
        private readonly IWorkServ _workServ;

        public WorkController(IWorkServ workServ)
        {
            _workServ = workServ;
        }


        public async Task<IActionResult> MyWork()
        {
            var works = await _workServ.GetAllAsync();
            return View(works);
        }


        public async Task<IActionResult> Create(int? id)
		{
			if (id.HasValue && id != 0)
			{
                var works = await _workServ.GetByIdAsync(id.Value);
                if (works != null)
                {
                    return View(works);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
				return View(new Team());
			}
		}


        [HttpPost]
        public async Task<IActionResult> Save(MyWorks myWorks, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\UploadWork", Image);
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        myWorks.Image = Image;
                    }
                }

                if (myWorks.Id == 0 || myWorks.Id == null)
                {
                    await _workServ.AddAsync(myWorks);
                }
                else
                {
                    await _workServ.UpdateAsync(myWorks);
                }
                return RedirectToAction(nameof(MyWork));
            }
            else
            {
                return View("Create", myWorks);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _workServ.DeleteAsync(Id);
            return RedirectToAction(nameof(MyWork));
        }
    }
}
