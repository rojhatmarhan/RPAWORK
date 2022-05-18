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
    
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(OrderDetail datum)
        {
            try
            {
                await _unitOfWork.OrderDetails.AddAsync(datum);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddRangeAsync(IList<OrderDetail> data)
        {
            try
            {
                await _unitOfWork.OrderDetails.AddRangeAsync(data);
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
                var orderDetail = await _unitOfWork.OrderDetails.GetAsync(x => x.Id == Id);
                if (orderDetail == null)
                    throw new Exception("Silenecek Kategori Bulunamadı !");

                await _unitOfWork.OrderDetails.DeleteAsync(orderDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<OrderDetail>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.OrderDetails.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderDetail> GetAsync(Guid Id)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetails.GetAsync(x => x.Id == Id);
                if (orderDetail == null)
                    throw new Exception("Gösterilecek Sipariş Detayı Bulunamadı !");

                return orderDetail;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(OrderDetail datum)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetails.GetAsync(x => x.Id == datum.Id);
                if (orderDetail == null)
                    throw new Exception("Düzenlenecek Sipariş Detayı Bulunamadı !");

                orderDetail = datum;

                await _unitOfWork.OrderDetails.UpdateAsync(orderDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
