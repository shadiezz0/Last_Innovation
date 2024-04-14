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
    public class ContactRepos : BaseRepository<Contact> , IContact
    {
        private readonly InnovationDbContext _context;
        public ContactRepos(InnovationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetContactAsync()
        {
            return await _context.Contacts.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
