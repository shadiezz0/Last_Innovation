using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReposPages
{
	public class AboutRepos : BaseRepository<About>, IAbout
    {
        private readonly InnovationDbContext _context;
        public AboutRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<About>> GetAboutAsync()
        {
			return await _context.Abouts.OrderBy(p => p.Id).ToListAsync();
		}
		public async Task<IEnumerable<About>> GetArabicDataAsync()
		{
			return await _context.Abouts
				.Where(a => a.TitleArabic != null && a.DescriptionArabic != null && a.NameArabic != null
						 && a.NationalityArabic != null && a.WorkStateArabic != null && a.PhoneArabic != null
						 && a.AddressArabic != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<About>> GetEnglishDataAsync()
		{
			return await _context.Abouts
							.Where(a => a.Title != null && a.Description != null && a.Name != null
									 && a.Nationality != null && a.WorkState != null && a.Phone != null
									 && a.Address != null)
							.ToListAsync();
		}
	}
}
