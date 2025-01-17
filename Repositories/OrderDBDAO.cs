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

        public async Task AddAsync(Order entity)
        {
            try
            {
                await _context.Orders.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding order: " + ex.Message, ex);
            }
        }

        public async Task DeleteAsync(Order entity)
        {
            try
            {
                _context.Orders.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting order: " + ex.Message, ex);
            }
        }

        public async Task<Order?> FindByIdAsync(int Id)
        {
            try
            {
                return await _context.Orders
                    .Include(o => o.User)
                    .FirstOrDefaultAsync(o => o.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error finding order by ID: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                return await _context.Orders
                    .Include(o => o.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all orders: " + ex.Message, ex);
            }
        }

        public async Task<IEnumerable<Order>> GetOrderByUser(int userId)
        {
            try
            {
                return await _context.Orders
                    .Where(o => o.UserId == userId)
                    .Include(o => o.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders for user: " + ex.Message, ex);
            }
        }

        public async Task UpdateAsync(Order entity)
        {
            try
            {
                _context.Orders.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating order: " + ex.Message, ex);
            }
        }
    }
}
