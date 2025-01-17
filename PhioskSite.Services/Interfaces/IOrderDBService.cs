using PhioskSite.Domains.EntitiesDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhioskSite.Services.Interfaces
{
    public interface IOrderDBService: IDBService<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUser(int Id);

    }
}
