using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Repositories.Interfaces;
using PhioskSite.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhioskSite.Services
{
    public class OrderDBService : IOrderDBService
    {
        private readonly IOrderDBDAO _orderDBDAO;
        public OrderDBService(IOrderDBDAO orderDBDAO)
        {
            _orderDBDAO = orderDBDAO;
        }

        public Task AddAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>?> GetAllAsync()
        {
            return await _orderDBDAO.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUser(int Id)
        {
            return await _orderDBDAO.GetOrderByUser(Id);
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
