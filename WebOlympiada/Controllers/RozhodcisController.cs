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
    public class RozhodcisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RozhodcisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rozhodcis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rozhodci.ToListAsync());
        }

        // GET: Rozhodcis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rozhodci = await _context.Rozhodci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rozhodci == null)
            {
                return NotFound();
            }

            return View(rozhodci);
        }

        // GET: Rozhodcis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rozhodcis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jmeno,Prijmeni,Sport")] Rozhodci rozhodci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rozhodci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rozhodci);
        }

        // GET: Rozhodcis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rozhodci = await _context.Rozhodci.FindAsync(id);
            if (rozhodci == null)
            {
                return NotFound();
            }
            return View(rozhodci);
        }

        // POST: Rozhodcis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jmeno,Prijmeni,Sport")] Rozhodci rozhodci)
        {
            if (id != rozhodci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rozhodci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RozhodciExists(rozhodci.Id))
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
            return View(rozhodci);
        }

        // GET: Rozhodcis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rozhodci = await _context.Rozhodci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rozhodci == null)
            {
                return NotFound();
            }

            return View(rozhodci);
        }

        // POST: Rozhodcis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rozhodci = await _context.Rozhodci.FindAsync(id);
            if (rozhodci != null)
            {
                _context.Rozhodci.Remove(rozhodci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RozhodciExists(int id)
        {
            return _context.Rozhodci.Any(e => e.Id == id);
        }
    }
}
