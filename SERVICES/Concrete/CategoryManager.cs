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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Category datum)
        {
            try
            {
                await _unitOfWork.Categories.AddAsync(datum);
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
                var category = await _unitOfWork.Categories.GetAsync(x => x.Id == Id);
                if (category == null)
                    throw new Exception("Silenecek Kategori Bulunamadı !");

                await _unitOfWork.Categories.DeleteAsync(category);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Categories.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Category> GetAsync(Guid Id)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetAsync(x => x.Id == Id);
                if (category == null)
                    throw new Exception("Gösterilecek Kategori Bulunamadı !");

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Category datum)
        {
            try
            {
                var category = await _unitOfWork.Categories.GetAsync(x => x.Id == datum.Id);
                if (category == null)
                    throw new Exception("Düzenlenecek Kategori Bulunamadı !");
                
                category = datum;
                
                await _unitOfWork.Categories.UpdateAsync(category);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
