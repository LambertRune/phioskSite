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
    public class AddressDBService: IDBService<Address>
    {
        private readonly IDBDAO<Address> _addressDBDAO;
        public AddressDBService(IDBDAO<Address> addressDBDAO)
        {
            _addressDBDAO = addressDBDAO;
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
            return await _addressDBDAO.GetAllAsync();
        }

        public Task UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
