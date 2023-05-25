using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovie(NewMovieVM newMovie)
        {
            var NewMovie = new Movie()
            {
                Name = newMovie.Name,
                Description = newMovie.Description,
                Price = newMovie.Price,
                ImageURL = newMovie.ImageURL,
                CinemaId = newMovie.CinemaId,
                StartDate = newMovie.StartDate,
                EndDate = newMovie.EndDate,
                MovieCategory = newMovie.MovieCategory,
                ProducerId = newMovie.ProducerId
            };
            await _context.Movies.AddAsync(NewMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in newMovie.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = NewMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies.
                Include(c => c.Cinema).
                Include(p => p.Producer).
                Include(am => am.Actors_Movies).ThenInclude(a => a.Actor).
                FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM();
            response.actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync();
            response.cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync();
            response.producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync();

            return response;
        }
    }
}
