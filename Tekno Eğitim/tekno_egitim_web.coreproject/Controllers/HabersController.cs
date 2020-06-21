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
    public class HabersController : Controller
    {
        private readonly SiteDbContext _context;
        private readonly IHaberServices _services;

        public HabersController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Habers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habers.ToListAsync());
        }

        // GET: Habers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var haber = await _context.Habers
            .FirstOrDefaultAsync(m => m.haber_id == id);
            haber.haber_görüntüleme+= 1;
            _context.SaveChanges();

            if (haber == null)
            {
                return NotFound();
            }

            return View(haber);
        }

        // GET: Habers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("haber_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,haber_silme")] Haber haber)
        {
            if (ModelState.IsValid)
            {
                await _services.HaberKaydet(haber);
                //_context.Add(haber);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(haber);
        }

        // GET: Habers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haber = await _context.Habers.FindAsync(id);
            if (haber == null)
            {
                return NotFound();
            }
            return View(haber);
        }

        // POST: Habers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("haber_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,haber_silme")] Haber haber)
        {
            if (id != haber.haber_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(haber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HaberExists(haber.haber_id))
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
            return View(haber);
        }

        // GET: Habers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var haber = await _context.Habers
                .FirstOrDefaultAsync(m => m.haber_id == id);
            if (haber == null)
            {
                return NotFound();
            }

            return View(haber);
        }

        // POST: Habers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var haber = await _context.Habers.FindAsync(id);
            _context.Habers.Remove(haber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HaberExists(int id)
        {
            return _context.Habers.Any(e => e.haber_id == id);
        }
    }
}
