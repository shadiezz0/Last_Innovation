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
    public class ServiceReposs : BaseRepository<MyServices>, IMyServices
    {
        private readonly InnovationDbContext _context;
        public ServiceReposs(InnovationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MyServices>> GetServiceAsync()
        {
            return await _context.myServices.OrderByDescending(p => p.Id).ToListAsync();
        }
    }
}
