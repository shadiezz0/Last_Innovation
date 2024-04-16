using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IWorkServ
    {
        Task<MyWorks> GetByIdAsync(int id);
        Task<IEnumerable<MyWorks>> GetAllAsync();
        Task AddAsync(MyWorks myServices);
        Task UpdateAsync(MyWorks myServices);
        Task DeleteAsync(int id);
		Task<IEnumerable<MyWorks>> GetEnglishDataAsync();
		Task<IEnumerable<MyWorks>> GetArabicDataAsync();
	}
}
