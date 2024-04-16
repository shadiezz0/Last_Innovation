using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReposPages
{
	public class MyServiceRepos : BaseRepository<MyServices>, IMyServices
    {
        private readonly InnovationDbContext _context;
        public MyServiceRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }

		public async Task<IEnumerable<MyServices>> GetArabicDataAsync()
		{
			return await _context.myServices
				.Where(s => s.TitleArabic != null && s.DescriptionArabic != null && s.NameServArabic != null && s.Desc_ServArabic != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<MyServices>> GetEnglishDataAsync()
		{
			return await _context.myServices
				.Where(s => s.Title != null && s.Description != null && s.NameServ != null && s.Desc_Serv != null)
				.ToListAsync();
		}

		public async Task<List<MyServices>> GetServiceAsync()
        {
            return await _context.myServices.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
