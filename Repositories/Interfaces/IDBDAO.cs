using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhioskSite.Repositories.Interfaces
{
    public interface IDBDAO<T> where T : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
        Task<T?> FindByIdAsync(int Id);
    }
}
