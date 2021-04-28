using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoviePro.Data;
using MoviePro.Models;
using MoviePro.Services;

namespace MoviePro.Controllers
{
    public class CastsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageService _imageService;

        public CastsController(ApplicationDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        // GET: Casts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cast.Include( c => c.Movie).ToListAsync());
        }

        // GET: Casts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast
                .Include( c => c.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "ID", "Title");
            return View(cast);
        }

        // GET: Casts/Create
        public IActionResult Create()
        {

            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title");
            return View();
        }

        // POST: Casts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,CastID,Department,Name,Character,Profile,ContentType")] Cast cast, IFormFile Profile)
        {
            if (ModelState.IsValid)
            {

                cast.ContentType = _imageService.RecordContentType(Profile);
                cast.Profile = await _imageService.EncodePosterAsync(Profile);

                _context.Add(cast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Title", cast.MovieId);
            return View(cast);
        }

        // GET: Casts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast.FindAsync(id);
            if (cast == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "ID", "Title", cast.MovieId);
            return View(cast);
        }

        // POST: Casts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,CastID,Department,Name,Character,Profile,ContentType")] Cast cast, IFormFile NewProfile, IFormFile NewContentType)
        {
            if (id != cast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NewProfile is not null)
                    {
                        cast.ContentType = _imageService.RecordContentType(NewProfile);
                        cast.Profile = await _imageService.EncodePosterAsync(NewProfile);
                    }


                    _context.Update(cast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CastExists(cast.Id))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "ID", "Title", cast.MovieId);
            return View(cast);
        }

        // GET: Casts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cast = await _context.Cast
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cast == null)
            {
                return NotFound();
            }

            return View(cast);
        }

        // POST: Casts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cast = await _context.Cast.FindAsync(id);
            _context.Cast.Remove(cast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CastExists(int id)
        {
            return _context.Cast.Any(e => e.Id == id);
        }
    }
}
