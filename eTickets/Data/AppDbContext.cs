using Microsoft.EntityFrameworkCore;


namespace eTickets.Data
//serves as translator between model and database, ch12
{
    //inherit from base class dbcontext in Install microsoft.entityframeworkcore
    //entity = mojodiat
    public class AppDbContext:DbContext
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
