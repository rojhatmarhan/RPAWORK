using ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Abstract
{
    public interface IOrderService : IService<Order>
    {
        Task<Order> GetAsync(Guid UserId, Guid Id);
        Task<IList<Order>> GetAllAsync(Guid UserId);
    }
}
