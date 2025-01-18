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
    public class UserDBDAO : IDBDAO<User>
    {
        private readonly PhioskDbContext _context;

        public UserDBDAO(PhioskDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>?> GetAllAsync()
        {
            try
            {
                return await _context.Users
                .Include(u => u.Address)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving all Users");
            }
            
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
