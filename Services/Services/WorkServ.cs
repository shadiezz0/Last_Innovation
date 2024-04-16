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
    public class WorkServ : IWorkServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public WorkServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<IEnumerable<MyWorks>> GetEnglishDataAsync()
		{
			return await _unitOfWork.Work.GetEnglishDataAsync();
		}

		public async Task<IEnumerable<MyWorks>> GetArabicDataAsync()
		{
			return await _unitOfWork.Work.GetArabicDataAsync();
		}

		public async Task AddAsync(MyWorks myWorks)
        {
            await _unitOfWork.Work.AddAsync(myWorks);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pageToDelete = await _unitOfWork.Work.GetByIdAsync(id);
            if (pageToDelete != null)
            {
                _unitOfWork.Work.Delete(pageToDelete);
                await _unitOfWork.CompleteAsync();
            }
        }

        public async Task<IEnumerable<MyWorks>> GetAllAsync()
        {
            return await _unitOfWork.Work.GetWorksAsync();
        }

        public async Task<MyWorks> GetByIdAsync(int id)
        {
            return await _unitOfWork.Work.GetByIdAsync(id);
        }

        public async Task UpdateAsync(MyWorks myWorks)
        {
            _unitOfWork.Work.Update(myWorks);
            await _unitOfWork.CompleteAsync();
        }
    }
}
