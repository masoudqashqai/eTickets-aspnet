﻿using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    public class ProducersController : Controller
    {

        //inject appdbcontext to constructor
        private readonly IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllProducers = await _service.GetAllAsync();
            return View(AllProducers);
        }

        //GET: /Producers/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null) return View("NotFound");
            return View(producerDetail);
        }

        //GET: /poducers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")]Producer producer)
        {
            if(!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        //GET: /poducers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            if (id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            else return View(producer);
            
            
        }

        //GET: /poducers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if (producerDetails == null) return View("NotFound");
            return View(producerDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var producerDetail = await _service.GetByIdAsync(id);
            if (producerDetail == null) return View("NotFound");

            await _service.Delete(id);
            return RedirectToAction(nameof(Index));


        }




    }
}
