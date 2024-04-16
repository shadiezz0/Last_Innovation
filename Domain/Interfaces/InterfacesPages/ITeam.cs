using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.InterfacesPages
{
    public interface ITeam : IBaseRepository<Team>
    {
        Task<IEnumerable<Team>> GetTeamAsync();
		Task<IEnumerable<Team>> GetEnglishDataAsync();
		Task<IEnumerable<Team>> GetArabicDataAsync();
	}
}
