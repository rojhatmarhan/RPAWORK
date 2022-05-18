using DATA.Abstract;
using ENTITIES.Concrete;
using Microsoft.EntityFrameworkCore;
using SHARED.Data.Concrete.NewFolder.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete.EntityFramework.Repositories
{
    public class ProductRepository : EntityRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
