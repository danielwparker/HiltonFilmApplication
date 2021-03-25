using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HiltonFilmApplication.Models;

namespace HiltonFilmApplication.Controllers
{
    public class MovieListingsController : Controller
    {
        private readonly MovieListingContext _context;

        public MovieListingsController(MovieListingContext context)
        {
            _context = context;
        }

        // GET: MovieListings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: MovieListings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieListing = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieKey == id);
            if (movieListing == null)
            {
                return NotFound();
            }

            return View(movieListing);
        }

        // GET: MovieListings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieListings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieKey,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] MovieListing movieListing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieListing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieListing);
        }

        // GET: MovieListings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieListing = await _context.Movies.FindAsync(id);
            if (movieListing == null)
            {
                return NotFound();
            }
            return View(movieListing);
        }

        // POST: MovieListings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieKey,Category,Title,Year,Director,Rating,Edited,LentTo,Notes")] MovieListing movieListing)
        {
            if (id != movieListing.MovieKey)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieListing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieListingExists(movieListing.MovieKey))
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
            return View(movieListing);
        }

        // GET: MovieListings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieListing = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieKey == id);
            if (movieListing == null)
            {
                return NotFound();
            }

            return View(movieListing);
        }

        // POST: MovieListings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieListing = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movieListing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieListingExists(int id)
        {
            return _context.Movies.Any(e => e.MovieKey == id);
        }
    }
}
