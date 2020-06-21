using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Services;
using tekno_egitim_web.data;

namespace tekno_egitim_web.coreproject.Controllers
{
    public class MakalesController : Controller
    {
        private readonly SiteDbContext _context;
        private readonly IMakaleServices _services;

        public MakalesController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Makales
        public async Task<IActionResult> Index()
        {
            return View(await _context.Makales.ToListAsync());
        }

        // GET: Makales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makale = await _context.Makales
                .FirstOrDefaultAsync(m => m.makale_id == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // GET: Makales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Makales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("makale_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,makale_silme")] Makale makale)
        {
            if (ModelState.IsValid)
            {
                await _services.MakaleKaydet(makale);
                //_context.Add(makale);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(makale);
        }

        // GET: Makales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makale = await _context.Makales.FindAsync(id);
            if (makale == null)
            {
                return NotFound();
            }
            return View(makale);
        }

        // POST: Makales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("makale_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,makale_silme")] Makale makale)
        {
            if (id != makale.makale_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(makale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MakaleExists(makale.makale_id))
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
            return View(makale);
        }

        // GET: Makales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makale = await _context.Makales
                .FirstOrDefaultAsync(m => m.makale_id == id);
            if (makale == null)
            {
                return NotFound();
            }

            return View(makale);
        }

        // POST: Makales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makale = await _context.Makales.FindAsync(id);
            _context.Makales.Remove(makale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakaleExists(int id)
        {
            return _context.Makales.Any(e => e.makale_id == id);
        }
    }
}
