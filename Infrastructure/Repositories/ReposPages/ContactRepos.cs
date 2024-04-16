using Core.Interfaces.InterfacesPages;
using Core.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

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

		public async Task<IEnumerable<Contact>> GetArabicDataAsync()
		{
			return await _context.Contacts
				.Where(c => c.AddressArabic != null && c.DescriptionArabic != null && c.PhoneArabic != null)
				.ToListAsync();
		}

		public async Task<IEnumerable<Contact>> GetEnglishDataAsync()
		{
			return await _context.Contacts
				.Where(c => c.Address != null && c.Description != null && c.Phone != null)
				.ToListAsync();
		}
	}
}
