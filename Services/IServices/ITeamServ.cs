using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ITeamServ
    {
        Task<Team> GetByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllAsync();
        Task AddAsync(Team team);
        Task UpdateAsync(Team team);
        Task DeleteAsync(int id);
		Task<IEnumerable<Team>> GetEnglishDataAsync();
		Task<IEnumerable<Team>> GetArabicDataAsync();
	}
}
