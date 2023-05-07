using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ActorsController : Controller
    {

        //inject the interface not implementation !!
        private readonly IActorService _service;


        public ActorsController(IActorService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetALL();
            return View(data);
        }

        //
        //Get method   Url:.../Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        //handling post method
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            _service.Add(actor);

            return RedirectToAction(nameof(Index));
        }
    }
}
