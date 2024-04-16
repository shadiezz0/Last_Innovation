using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using Services.Services;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactServ _contactServ;

        public ContactController(IContactServ contactServ)
        {
            _contactServ = contactServ;
        }


        public async Task<IActionResult> MyContact()
        {
            var contacts = await _contactServ.GetAllAsync();
            return View(contacts);
        }


		public async Task<IActionResult> Create(int? id)
		{
			if (id.HasValue && id != 0)
			{
				var slider = await _contactServ.GetByIdAsync(id.Value);
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
				return View(new Contact());
			}
		}


		[HttpPost]
        public async Task<IActionResult> Save(Contact contact, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\UploadContact", Image);
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        contact.Image = Image;
                    }
                }

                if (contact.Id == 0 || contact.Id == null)
                {
                    await _contactServ.AddAsync(contact);
                }
                else
                {
                    await _contactServ.UpdateAsync(contact);
                }
                return RedirectToAction(nameof(MyContact));
            }
            else
            {
                return View("Create", contact);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _contactServ.DeleteAsync(Id);
            return RedirectToAction(nameof(MyContact));
        }
    }
}
