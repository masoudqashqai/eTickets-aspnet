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
        void Add(Actor actor);

        //update db
        Actor Update(int id, Actor newActor);

        //delete a record from db
        void Delete(int id);
    }
}
