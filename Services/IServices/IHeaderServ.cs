using Core.Models;

namespace Services.IServices
{
	public interface IHeaderServ
    {
        Task<Header> GetByIdAsync(int id);
        Task<List<Header>> GetAllAsync();
        Task AddAsync(Header header);
        Task UpdateAsync(Header header);
        Task DeleteAsync(int id);
		Task<IEnumerable<Header>> GetEnglishDataAsync();
		Task<IEnumerable<Header>> GetArabicDataAsync();

	}
}
