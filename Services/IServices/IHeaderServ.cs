using Azure;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
