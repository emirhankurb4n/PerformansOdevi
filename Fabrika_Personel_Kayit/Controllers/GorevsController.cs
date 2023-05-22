using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fabrika_Personel_Kayit.Models;

namespace Fabrika_Personel_Kayit.Controllers
{
    public class GorevsController : Controller
    {
        private readonly AppDbContext _context;

        public GorevsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Gorevs
        public async Task<IActionResult> Index()
        {
              return _context.Gorevs != null ? 
                          View(await _context.Gorevs.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Gorevs'  is null.");
        }

        // GET: Gorevs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gorevs == null)
            {
                return NotFound();
            }

            var gorev = await _context.Gorevs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gorev == null)
            {
                return NotFound();
            }

            return View(gorev);
        }

        // GET: Gorevs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gorevs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gorev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gorev);
        }

        // GET: Gorevs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gorevs == null)
            {
                return NotFound();
            }

            var gorev = await _context.Gorevs.FindAsync(id);
            if (gorev == null)
            {
                return NotFound();
            }
            return View(gorev);
        }

        // POST: Gorevs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Gorev gorev)
        {
            if (id != gorev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gorev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GorevExists(gorev.Id))
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
            return View(gorev);
        }

        // GET: Gorevs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gorevs == null)
            {
                return NotFound();
            }

            var gorev = await _context.Gorevs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gorev == null)
            {
                return NotFound();
            }

            return View(gorev);
        }

        // POST: Gorevs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gorevs == null)
            {
                return Problem("Entity set 'AppDbContext.Gorevs'  is null.");
            }
            var gorev = await _context.Gorevs.FindAsync(id);
            if (gorev != null)
            {
                _context.Gorevs.Remove(gorev);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GorevExists(int id)
        {
          return (_context.Gorevs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
