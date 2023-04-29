using eTickets.Models;
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

        //many to many relation ship between actor and movies
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        //define table names
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas  { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }


    }
}
