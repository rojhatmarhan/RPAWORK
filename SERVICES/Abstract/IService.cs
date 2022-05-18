using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Abstract
{
    public interface IService<T>
    {
        Task<T> GetAsync(Guid Id);
        Task<IList<T>> GetAllAsync();
        Task<bool> AddAsync(T datum);
        Task<bool> UpdateAsync(T datum);
        Task<bool> DeleteAsync(Guid Id);
    }
}
