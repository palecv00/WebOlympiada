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
    public class DivacisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DivacisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Divacis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Divaci.ToListAsync());
        }

        // GET: Divacis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divaci = await _context.Divaci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (divaci == null)
            {
                return NotFound();
            }

            return View(divaci);
        }

        // GET: Divacis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Divacis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Jmeno,Prijmeni")] Divaci divaci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(divaci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(divaci);
        }

        // GET: Divacis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divaci = await _context.Divaci.FindAsync(id);
            if (divaci == null)
            {
                return NotFound();
            }
            return View(divaci);
        }

        // POST: Divacis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Jmeno,Prijmeni")] Divaci divaci)
        {
            if (id != divaci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(divaci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivaciExists(divaci.Id))
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
            return View(divaci);
        }

        // GET: Divacis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var divaci = await _context.Divaci
                .FirstOrDefaultAsync(m => m.Id == id);
            if (divaci == null)
            {
                return NotFound();
            }

            return View(divaci);
        }

        // POST: Divacis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var divaci = await _context.Divaci.FindAsync(id);
            if (divaci != null)
            {
                _context.Divaci.Remove(divaci);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivaciExists(int id)
        {
            return _context.Divaci.Any(e => e.Id == id);
        }
    }
}
