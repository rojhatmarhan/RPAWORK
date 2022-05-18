using DATA.Abstract;
using DATA.Concrete.EntityFramework.Contexts;
using DATA.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RPAContext _context;
        private CategoryRepository categoryRepository;
        private OrderDetailRepository orderDetailRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private UserRepository userRepository;

        public UnitOfWork(RPAContext context)
        {
            _context = context;
        }

        public ICategoryRepository Categories => categoryRepository ?? new CategoryRepository(_context);

        public IOrderDetailRepository OrderDetails => orderDetailRepository ?? new OrderDetailRepository(_context);

        public IOrderRepository Orders => orderRepository ?? new OrderRepository(_context);

        public IProductRepository Products => productRepository ?? new ProductRepository(_context);

        public IUserRepository Users => userRepository ?? new UserRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
