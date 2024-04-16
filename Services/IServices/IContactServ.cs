using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IContactServ
    {
        Task<Contact> GetByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task AddAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
		Task<IEnumerable<Contact>> GetEnglishDataAsync();
		Task<IEnumerable<Contact>> GetArabicDataAsync();
	}
}
