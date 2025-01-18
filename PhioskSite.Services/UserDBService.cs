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
    public class UserDBService : IDBService<User>
    {
        private readonly IDBDAO<User> _userDBDAO;

        public UserDBService(IDBDAO<User> userDBDAO)
        {
            _userDBDAO = userDBDAO;
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
            return await _userDBDAO.GetAllAsync();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
