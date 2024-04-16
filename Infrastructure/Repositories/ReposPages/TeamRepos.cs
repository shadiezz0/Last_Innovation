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
    public class TeamRepos : BaseRepository<Team>, ITeam
    {
        private readonly InnovationDbContext _context;
        public TeamRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }

		public async Task<IEnumerable<Team>> GetArabicDataAsync()
		{
			return await _context.Teams
				.Where(t => t.NameArabic != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<Team>> GetEnglishDataAsync()
		{
			return await _context.Teams
				.Where(t => t.Name != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<Team>> GetTeamAsync()
        {
            return await _context.Teams.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
