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
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Order datum)
        {
            try
            {
                await _unitOfWork.Orders.AddAsync(datum);
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
                var order = await _unitOfWork.Orders.GetAsync(x => x.Id == Id);
                if (order == null)
                    throw new Exception("Silenecek Sipariş Bulunamadı !");

                await _unitOfWork.Orders.DeleteAsync(order);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Orders.GetAllAsync(null, x=> x.OrderDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IList<Order>> GetAllAsync(Guid UserId)
        {
            try
            {
                return await _unitOfWork.Orders.GetAllAsync(x=> x.UserId == UserId, x => x.OrderDetails);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> GetAsync(Guid Id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetAsync(x => x.Id == Id, x => x.OrderDetails);
                if (order == null)
                    throw new Exception("Gösterilecek Sipariş Bulunamadı !");

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Order> GetAsync(Guid UserId, Guid Id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetAsync(x => x.Id == Id && x.UserId == UserId, x => x.OrderDetails);
                if (order == null)
                    throw new Exception("Gösterilecek Sipariş Bulunamadı !");

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateAsync(Order datum)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetAsync(x => x.Id == datum.Id);
                if (order == null)
                    throw new Exception("Düzenlenecek Sipraiş Bulunamadı !");

                order = datum;

                await _unitOfWork.Orders.UpdateAsync(order);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
