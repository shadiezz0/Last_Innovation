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

        public async Task<IEnumerable<Team>> GetTeamAsync()
        {
            return await _context.Teams.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
