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
    public class AddressDBDAO : IDBDAO<Address>
    {
        private readonly PhioskDbContext _context;

        public AddressDBDAO(PhioskDbContext context)
        {
            _context = context;
        }
        public Task AddAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Address?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Address>?> GetAllAsync()
        {
            
                return await _context
                    .Address.ToListAsync();
            
        }
        public Task UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
