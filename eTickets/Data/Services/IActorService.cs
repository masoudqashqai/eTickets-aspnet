using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetALL();

        //a method to return a single Actor
        Task<Actor> GetByIdAsync(int id);

        //a method to add data to db
        Task AddAsync(Actor actor);

        //update db
        Task<Actor> UpdateAsync(int id, Actor newActor);

        //delete a record from db
        Task Delete(int id);
    }
}
