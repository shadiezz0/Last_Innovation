using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
    public interface IWork : IBaseRepository<MyWorks>
    {
        Task<IEnumerable<MyWorks>> GetWorksAsync();
		Task<IEnumerable<MyWorks>> GetEnglishDataAsync();
		Task<IEnumerable<MyWorks>> GetArabicDataAsync();
	}
}
