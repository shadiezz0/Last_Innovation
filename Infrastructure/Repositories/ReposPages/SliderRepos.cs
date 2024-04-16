using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ReposPages
{
	public class SliderRepos : BaseRepository<Header>, ISlider
    {
        private readonly InnovationDbContext _context;
        public SliderRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Header>> GetHeadersAsync()
        {
            return await _context.Headers.OrderBy(p=>p.Id).ToListAsync();
        }

		public async Task<IEnumerable<Header>> GetEnglishDataAsync()
		{
			return await _context.Headers.Where(h => h.Description != null).ToListAsync();
		}

		public async Task<IEnumerable<Header>> GetArabicDataAsync()
		{
			return await _context.Headers.Where(h => h.DescriptionArabic != null).ToListAsync();
		}

	}
}
