using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IMyServiceServ
    {
        Task<MyServices> GetByIdAsync(int id);
        Task<IEnumerable<MyServices>> GetAllAsync();
        Task AddAsync(MyServices myServices);
        Task UpdateAsync(MyServices myServices);
        Task DeleteAsync(int id);
    }
}
