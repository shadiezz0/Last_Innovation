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
    public class AboutRepos : BaseRepository<About>, IAbout
    {
        private readonly InnovationDbContext _context;
        public AboutRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<About>> GetAboutAsync()
        {
            return await _context.Abouts.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
