using ENTITIES.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Abstract
{
    public interface IUserService : IService<User>
    {
        Task<Guid> Login(string username, string password);
    }
}
