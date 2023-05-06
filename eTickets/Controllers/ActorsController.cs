using eTickets.Data.Services;
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
    }
}
