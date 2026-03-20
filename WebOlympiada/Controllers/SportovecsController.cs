using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOlympiada.Data;
using WebOlympiada.Models;

namespace WebOlympiada.Controllers
{
    public class SportovecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SportovecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sportovecs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sportovec.ToListAsync());
        }

        // GET: Sportovecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportovec = await _context.Sportovec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportovec == null)
            {
                return NotFound();
            }

            return View(sportovec);
        }

        // GET: Sportovecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sportovecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jmeno,Prijmeni,Narodnost")] Sportovec sportovec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sportovec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sportovec);
        }

        // GET: Sportovecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportovec = await _context.Sportovec.FindAsync(id);
            if (sportovec == null)
            {
                return NotFound();
            }
            return View(sportovec);
        }

        // POST: Sportovecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jmeno,Prijmeni,Narodnost")] Sportovec sportovec)
        {
            if (id != sportovec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sportovec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SportovecExists(sportovec.Id))
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
            return View(sportovec);
        }

        // GET: Sportovecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportovec = await _context.Sportovec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sportovec == null)
            {
                return NotFound();
            }

            return View(sportovec);
        }

        // POST: Sportovecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sportovec = await _context.Sportovec.FindAsync(id);
            if (sportovec != null)
            {
                _context.Sportovec.Remove(sportovec);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SportovecExists(int id)
        {
            return _context.Sportovec.Any(e => e.Id == id);
        }
    }
}
