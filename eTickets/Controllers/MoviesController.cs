using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var AllMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(AllMovies);
        }

        /*public async Task<IActionResult> Filter(string searchString)
        {
            var AllMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = AllMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                
                return View("Index", filteredResult);
            }

            return View(AllMovies);
        }*/

        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(a => a.Name.Contains(searchString) || a.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }

        //GET: /movies/details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //GET: /movies/create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET: /movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                CinemaId = movieDetails.CinemaId,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {

            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdownsData.actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(movieDropdownsData.producers, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
