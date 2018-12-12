// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Controllers/FindPizzaController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EverythingPizza.Data;
using EverythingPizza.Models;
using Microsoft.AspNetCore.Authorization;

namespace EverythingPizza.Controllers
{
    public class FindPizzaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FindPizzaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        // GET: FindPizza
        public IActionResult Index()
        {
            DbViewModel dvm = new DbViewModel();
            dvm.MyPizzaPlacesItems = _context.MyPizzaPlaces.ToList();
            return View(dvm);
        }

        [AllowAnonymous]
        // GET: FindPizza/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myPizzaPlaces = await _context.MyPizzaPlaces
                .FirstOrDefaultAsync(m => m.MyPizzaPlacesId == id);
            if (myPizzaPlaces == null)
            {
                return NotFound();
            }

            return View(myPizzaPlaces);
        }

        [Authorize]
        // GET: FindPizza/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        // POST: FindPizza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MyPizzaPlacesId,Name,Street,Zip,Phone,Votes,TotalVotes,Slogan,Menu")] MyPizzaPlaces myPizzaPlaces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myPizzaPlaces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myPizzaPlaces);
        }

        [Authorize(Roles = "Admin")]
        // GET: FindPizza/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myPizzaPlaces = await _context.MyPizzaPlaces.FindAsync(id);
            if (myPizzaPlaces == null)
            {
                return NotFound();
            }
            return View(myPizzaPlaces);
        }

        [Authorize(Roles = "Admin")]
        // POST: FindPizza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MyPizzaPlacesId,Name,Street,Zip,Phone,Votes,TotalVotes,Slogan,Menu")] MyPizzaPlaces myPizzaPlaces)
        {
            if (id != myPizzaPlaces.MyPizzaPlacesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myPizzaPlaces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyPizzaPlacesExists(myPizzaPlaces.MyPizzaPlacesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(myPizzaPlaces);
        }

        [Authorize(Roles = "Admin")]
        // GET: FindPizza/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myPizzaPlaces = await _context.MyPizzaPlaces
                .FirstOrDefaultAsync(m => m.MyPizzaPlacesId == id);
            if (myPizzaPlaces == null)
            {
                return NotFound();
            }

            return View(myPizzaPlaces);
        }

        [Authorize(Roles = "Admin")]
        // POST: FindPizza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myPizzaPlaces = await _context.MyPizzaPlaces.FindAsync(id);
            _context.MyPizzaPlaces.Remove(myPizzaPlaces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyPizzaPlacesExists(int id)
        {
            return _context.MyPizzaPlaces.Any(e => e.MyPizzaPlacesId == id);
        }
    }
}
