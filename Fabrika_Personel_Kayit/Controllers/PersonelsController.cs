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
    public class PersonelsController : Controller
    {
        private readonly AppDbContext _context;

        public PersonelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Personels
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Personels.Include(p => p.Gorev);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Personels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }

            var personel = await _context.Personels
                .Include(p => p.Gorev)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Personels/Create
        public IActionResult Create()
        {
            ViewData["GorevId"] = new SelectList(_context.Gorevs, "Id", "Name");
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SurName,Photo,Maas,TCNo,GorevId")] Personel personel,IFormFile file)
        {
            
            if (file != null)
            {
                var yeniPhoto = CopyPhoto(file);
                if (yeniPhoto != null)
                {
                    personel.Photo = yeniPhoto;
                    if (ModelState.IsValid)
                    {
                        _context.Add(personel);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
                else ModelState.AddModelError("Photo", "Fotoğraf Yüklenemedi");

            }
    
            ViewData["GorevId"] = new SelectList(_context.Gorevs, "Id", "Name", personel.GorevId);
            return View(personel);
        }

        private string? CopyPhoto(IFormFile file)
        {
            var extent = Path.GetExtension(file.FileName);
            var randomName = ($"{Guid.NewGuid()}{extent}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

            if (file.ContentType == "image/png" || file.ContentType == "image/jpeg")
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    try
                    {
                        file.CopyTo(stream);
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            return randomName;
        }
        private bool RemovePhoto(string photo)
        {
            var silPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", photo);

            if (System.IO.File.Exists(silPath))
            {
                try
                {
                    System.IO.File.Delete(silPath);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        // GET: Personels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }


            var personel = await _context.Personels.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            ViewData["GorevId"] = new SelectList(_context.Gorevs, "Id", "Name", personel.GorevId);
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SurName,Photo,Maas,TCNo,GorevId")] Personel personel)
        {
            if (id != personel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonelExists(personel.Id))
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
            ViewData["GorevId"] = new SelectList(_context.Gorevs, "Id", "Id", personel.GorevId);
            return View(personel);
        }

        // GET: Personels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personels == null)
            {
                return NotFound();
            }


            var personel = await _context.Personels
                .Include(p => p.Gorev)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personels == null)
            {
                return Problem("Entity set 'AppDbContext.Personels'  is null.");
            }
            var personel = await _context.Personels.FindAsync(id);
            if (personel != null)
            {
                _context.Personels.Remove(personel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
          return (_context.Personels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
