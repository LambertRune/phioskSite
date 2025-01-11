using Microsoft.EntityFrameworkCore;
using PhioskSite.Domains.DataDB;
using PhioskSite.Domains.EntitiesDB;
using PhioskSite.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<IEnumerable<Order>?> GetOrderByUser(int userId)
        {
            try
            {
                return await _context.Orders
                    .Where(b=>b.UserId == userId)
                    .Include(b=> b.User)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("error DAO order");
            }
        }

        public Task<IEnumerable<OrderDBDAO>> GetOrderByUser()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
