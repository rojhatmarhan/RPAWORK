using ENTITIES.Concrete;
using SHARED.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Abstract
{
    public interface IOrderDetailRepository : IEntityRepository<OrderDetail>
    {
    }
}
