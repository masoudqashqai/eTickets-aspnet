using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ICinemasService _service;
        public CinemasController(ICinemasService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllCinemas = await _service.GetAllAsync();
            return View(AllCinemas);
        }

        //GET /cinemas/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            //show model state errors
            if (!ModelState.IsValid) return View(cinema);

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));

        }

        //GET: /cinemas/details/id
        public async Task<IActionResult> Details(int id)
        {
            var CinemaDetail = await _service.GetByIdAsync(id);
            if (CinemaDetail == null) return View("NotFound");
            return View(CinemaDetail);
        }

        //GET: /cinemas/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var CinemaDetail = await _service.GetByIdAsync(id);
            if (CinemaDetail == null) return View("NotFound");
            return View(CinemaDetail);
        }

        [HttpPost]
        //if you dont bind id , 0 row will change and you'll get an error page
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Cinema cinema)
        {
            //return cinema errors if is not valid
            if (!ModelState.IsValid) return View(cinema);

            await _service.UpdateAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //GET: /cinemas/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var CinemaDetail = await _service.GetByIdAsync(id);
            if (CinemaDetail == null) return View("NotFound");
            return View(CinemaDetail);
        }

        [HttpPost, ActionName("delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinema = await _service.GetByIdAsync(id);
            if (cinema == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
