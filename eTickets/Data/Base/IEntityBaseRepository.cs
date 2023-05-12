using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class, IEntityBase, new()
    {
       

        Task<IEnumerable<T>> GetAllAsync();

        //a method to return a single T
        Task<T> GetByIdAsync(int id);

        //a method to add data to db
        Task AddAsync(T entity);

        //update db
        Task UpdateAsync(int id, T entity);

        //delete a record from db
        Task Delete(int id);
    }
}
