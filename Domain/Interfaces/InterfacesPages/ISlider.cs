using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
	public interface ISlider : IBaseRepository<Header>
	{
		Task<List<Header>> GetHeadersAsync();
		Task<IEnumerable<Header>> GetEnglishDataAsync();
		Task<IEnumerable<Header>> GetArabicDataAsync();
	}
}
