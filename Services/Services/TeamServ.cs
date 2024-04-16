using Core.Interfaces;
using Core.Interfaces.InterfacesPages;
using Core.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TeamServ : ITeamServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeamServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<IEnumerable<Team>> GetEnglishDataAsync()
		{
			return await _unitOfWork.Team.GetEnglishDataAsync();
		}

		public async Task<IEnumerable<Team>> GetArabicDataAsync()
		{
			return await _unitOfWork.Team.GetArabicDataAsync();
		}
		public  async Task AddAsync(Team team)
        {
            await _unitOfWork.Team.AddAsync(team);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pageToDelete = await _unitOfWork.Team.GetByIdAsync(id);
            if (pageToDelete != null)
            {
                _unitOfWork.Team.Delete(pageToDelete);
                await _unitOfWork.CompleteAsync();
            }
        }

        public  async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _unitOfWork.Team.GetTeamAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _unitOfWork.Team.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Team team)
        {
            _unitOfWork.Team.Update(team);
            await _unitOfWork.CompleteAsync();
        }
    }
}
