using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InterfacesDal
{
    public interface IDataAccess
    {
        Task<List<T>> GetAllAsync<T>();
        Task AddAsync<T>(T newItem);
        Task UpdateAsync<T>(Func<T, bool> predicate, T updatedItem);
        Task DeleteByIdAsync<T>(int id) where T : class;
    }
}
