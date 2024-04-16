using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IAboutServ
    {
        Task<About> GetByIdAsync(int id);
        Task<List<About>> GetAllAsync();
        Task AddAsync(About about);
        Task UpdateAsync(About about);
        Task DeleteAsync(int id);
		Task<IEnumerable<About>> GetEnglishDataAsync();
		Task<IEnumerable<About>> GetArabicDataAsync();
	}
}
