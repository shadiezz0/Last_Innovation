using Core.Models;

namespace Services.IServices
{
    public interface IHeaderServ
    {
        Task<Header> GetByIdAsync(int id);
        Task<IEnumerable<Header>> GetAllAsync();
        Task AddAsync(Header header);
        Task UpdateAsync(Header header);
        Task DeleteAsync(int id);
    }
}
