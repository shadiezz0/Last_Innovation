using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
    public interface IContact : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetContactAsync();
		Task<IEnumerable<Contact>> GetEnglishDataAsync();
		Task<IEnumerable<Contact>> GetArabicDataAsync();
	}
}
