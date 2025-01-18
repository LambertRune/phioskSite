using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.DataDB;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhioskSite.Repositories
{
    public class OrderDBDAO : IOrderDBDAO
    {
        private readonly PhioskDbContext _context;


        public OrderDBDAO(PhioskDbContext context)
        {
            _context = context;
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
            try
            {
                return await _context.Orders
                    .Include(o => o.Phones)
                    .Include(o => o.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all orders");
            }
        }

        public async Task<IEnumerable<Order>> GetOrder(int userId)
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderByUser(int userId)
        {
            try
            {
                return await _context.Orders
                    .Where(o => o.UserId == userId)                    
                    .Include(o => o.User)
                    .Include(o=> o.Phones)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders for user: " + ex.Message, ex);
            }
        }

        public async Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
