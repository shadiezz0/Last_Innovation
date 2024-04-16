using Core.Interfaces;
using Core.Models;
using Services.IServices;

namespace Services.Services
{
	public class HeaderServ : IHeaderServ
    {
        private readonly IUnitOfWork _unitOfWork;

        public HeaderServ(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(Header header)
        {
            await _unitOfWork.Slider.AddAsync(header);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pageToDelete = await _unitOfWork.Slider.GetByIdAsync(id);
            if (pageToDelete != null)
            {
                _unitOfWork.Slider.Delete(pageToDelete);
                await _unitOfWork.CompleteAsync();
            }
        }

            public async Task<List<Header>> GetAllAsync()
        {
            return await _unitOfWork.Slider.GetHeadersAsync();
        }

        public async Task<Header> GetByIdAsync(int id)
        {
            return await _unitOfWork.Slider.GetByIdAsync(id);
        }


        public async Task UpdateAsync(Header header)
        {
            _unitOfWork.Slider.Update(header);
            await _unitOfWork.CompleteAsync();
        }

		public async Task<IEnumerable<Header>> GetEnglishDataAsync()
		{
			return await _unitOfWork.Slider.GetEnglishDataAsync();
		}

		public async Task<IEnumerable<Header>> GetArabicDataAsync()
		{
			return await _unitOfWork.Slider.GetArabicDataAsync();
		}
	}
}