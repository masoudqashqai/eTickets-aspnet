using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //refrence to appdbcontext file
                var conetext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //make sure db is created and exist
                conetext.Database.EnsureCreated();

                //cinema
                //actor
                //producer
                //movie
                //actors and movies
            }
        }
    }
}
