using PhioskSite.Domains.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhioskSite.Repositories.Interfaces
{
    public interface IOrderDBDAO: IDBDAO<Order>
    {
        Task<IEnumerable<Order>> GetOrderByUser(int userId);
    }
}
