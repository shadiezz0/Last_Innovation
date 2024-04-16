using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
    public interface IAbout : IBaseRepository<About>
    {
        Task<List<About>> GetAboutAsync();
		Task<IEnumerable<About>> GetEnglishDataAsync();
		Task<IEnumerable<About>> GetArabicDataAsync();
	}
}
