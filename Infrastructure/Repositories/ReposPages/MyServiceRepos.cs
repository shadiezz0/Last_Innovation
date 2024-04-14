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
    public class MyServiceRepos : BaseRepository<MyServices>, IMyServices
    {
        private readonly InnovationDbContext _context;
        public MyServiceRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MyServices>> GetServiceAsync()
        {
            return await _context.myServices.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
