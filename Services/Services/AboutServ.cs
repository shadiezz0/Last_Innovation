using Core.Interfaces;
using Core.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AboutServ : IAboutServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<IEnumerable<About>> GetEnglishDataAsync()
		{
			return await _unitOfWork.About.GetEnglishDataAsync();
		}

		public async Task<IEnumerable<About>> GetArabicDataAsync()
		{
			return await _unitOfWork.About.GetArabicDataAsync();
		}

		public async Task AddAsync(About about)
        {
            await _unitOfWork.About.AddAsync(about);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pageToDelete = await _unitOfWork.About.GetByIdAsync(id);
            if (pageToDelete != null)
            {
                _unitOfWork.About.Delete(pageToDelete);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<List<About>> GetAllAsync()
        {   
            return await _unitOfWork.About.GetAboutAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            return await _unitOfWork.About.GetByIdAsync(id);
        }

        public async Task UpdateAsync(About about)
        {
            _unitOfWork.About.Update(about);
            await _unitOfWork.CompleteAsync();
        }
    }
}
