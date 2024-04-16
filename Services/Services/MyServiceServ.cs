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
    public class MyServiceServ : IMyServiceServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public MyServiceServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<IEnumerable<MyServices>> GetEnglishDataAsync()
		{
			return await _unitOfWork.Services.GetEnglishDataAsync();
		}

		public async Task<IEnumerable<MyServices>> GetArabicDataAsync()
		{
			return await _unitOfWork.Services.GetArabicDataAsync();
		}

		public async Task AddAsync(MyServices myServices)
        {
            await _unitOfWork.Services.AddAsync(myServices);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pageToDelete = await _unitOfWork.Services.GetByIdAsync(id);
            if (pageToDelete != null)
            {
                _unitOfWork.Services.Delete(pageToDelete);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<List<MyServices>> GetAllAsync()
        {
            return await _unitOfWork.Services.GetServiceAsync();
        }

        public async Task<MyServices> GetByIdAsync(int id)
        {
            return await _unitOfWork.Services.GetByIdAsync(id);
        }

        public async Task UpdateAsync(MyServices myServices)
        {
            _unitOfWork.Services.Update(myServices);
            await _unitOfWork.CompleteAsync();
        }
    }
}
