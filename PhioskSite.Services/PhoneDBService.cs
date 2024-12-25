using Microsoft.EntityFrameworkCore;
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
    public class PhoneDBService : IDBService<Phone>
    {
        private readonly IDBDAO<Phone> _phoneDBDAO;

        public PhoneDBService(IDBDAO<Phone> phoneDBDAO)
        {
            _phoneDBDAO = phoneDBDAO;
        }

        public Task AddAsync(Phone entity)
        {
            throw new ArgumentNullException(nameof(entity));

        }

        public Task DeleteAsync(Phone entity)
        {
            throw new NotImplementedException();
        }

        public Task<Phone?> FindByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Phone>?> GetAllAsync()
        {
            return await _phoneDBDAO.GetAllAsync();
        }

        public Task UpdateAsync(Phone entity)
        {
            throw new NotImplementedException();
        }
    }
}
