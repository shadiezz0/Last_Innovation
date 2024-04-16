using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.ReposPages
{
    public class WorkRepos : BaseRepository<MyWorks>, IWork
    {
        private readonly InnovationDbContext _context;
        public WorkRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }

		public async Task<IEnumerable<MyWorks>> GetArabicDataAsync()
		{
			return await _context.MyWorks
				.Where(w => w.TitleArabic != null && w.DescriptionArabic != null && w.NameArabic != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<MyWorks>> GetEnglishDataAsync()
		{
			return await _context.MyWorks
				.Where(w => w.Title != null && w.Description != null && w.Name != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<MyWorks>> GetWorksAsync()
        {
            return await _context.MyWorks.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
