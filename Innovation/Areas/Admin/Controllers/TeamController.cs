using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;

namespace Innovation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly ITeamServ _teamServ;

        public TeamController(ITeamServ teamServ)
        {
            _teamServ = teamServ;
        }
 
        public async Task<IActionResult> MyTeam()
        {
            var items = await _teamServ.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Create(int? id)
		{
			if (id.HasValue && id != 0)
			{
                var items = await _teamServ.GetByIdAsync(id.Value);
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
				return View(new Team());
			}
		}


        [HttpPost]
        public async Task<IActionResult> Save(Team team, List<IFormFile> Files)
        {
            if (ModelState.IsValid)
            {
                foreach (var file in Files)
                {
                    if (file.Length > 0)
                    {
                        string Image = Guid.NewGuid().ToString() + ".jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\UploadTeam", Image);
                        using (var fileStream = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                        team.Image = Image;
                    }
                }

                if (team.Id == 0 || team.Id == null)
                {
                    await _teamServ.AddAsync(team);
                }
                else
                {
                    await _teamServ.UpdateAsync(team);
                }
                return RedirectToAction(nameof(MyTeam));
            }
            else
            {
                return View("Create", team);
            }
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await _teamServ.DeleteAsync(Id);
            return RedirectToAction(nameof(MyTeam));
        }
    }
}
