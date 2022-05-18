using DATA.Abstract;
using ENTITIES.Concrete;
using SERVICES.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Product datum)
        {
            try
            {
                await _unitOfWork.Products.AddAsync(datum);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetAsync(x => x.Id == Id);
                if (product == null)
                    throw new Exception("Silenecek Ürün Bulunamadı !");

                await _unitOfWork.Products.DeleteAsync(product);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Products.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetAsync(Guid Id)
        {
            try
            {
                var product = await _unitOfWork.Products.GetAsync(x => x.Id == Id);
                if (product == null)
                    throw new Exception("Gösterilecek Ürün Bulunamadı !");

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Product datum)
        {
            try
            {
                var product = await _unitOfWork.Products.GetAsync(x => x.Id == datum.Id);
                if (product == null)
                    throw new Exception("Düzenlenecek Ürün Bulunamadı !");

                product = datum;

                await _unitOfWork.Products.UpdateAsync(product);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
