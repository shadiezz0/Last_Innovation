using Core.Interfaces;
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
    public class SliderRepos : BaseRepository<Header>, ISlider
    {
        private readonly InnovationDbContext _context;
        public SliderRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Header>> GetHeadersAsync()
        {
            return await _context.Headers.OrderBy(p=>p.Id).ToListAsync();
        }
    }
}
