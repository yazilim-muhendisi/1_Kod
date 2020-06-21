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
    public class NotsController : Controller
    {
        private readonly SiteDbContext _context;
        private readonly INotServices _services;

        public NotsController(SiteDbContext context)
        {
            _context = context;
        }

        // GET: Nots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nots.ToListAsync());
        }

        // GET: Nots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var not = await _context.Nots
                .FirstOrDefaultAsync(m => m.not_id == id);
            if (not == null)
            {
                return NotFound();
            }

            return View(not);
        }

        // GET: Nots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("not_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,not_silme")] Not not)
        {
            if (ModelState.IsValid)
            {
                await _services.NotKaydet(not);
                //_context.Add(not);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(not);
        }

        // GET: Nots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var not = await _context.Nots.FindAsync(id);
            if (not == null)
            {
                return NotFound();
            }
            return View(not);
        }

        // POST: Nots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("not_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,not_silme")] Not not)
        {
            if (id != not.not_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(not);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotExists(not.not_id))
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
            return View(not);
        }

        // GET: Nots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var not = await _context.Nots
                .FirstOrDefaultAsync(m => m.not_id == id);
            if (not == null)
            {
                return NotFound();
            }

            return View(not);
        }

        // POST: Nots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var not = await _context.Nots.FindAsync(id);
            _context.Nots.Remove(not);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotExists(int id)
        {
            return _context.Nots.Any(e => e.not_id == id);
        }
    }
}
