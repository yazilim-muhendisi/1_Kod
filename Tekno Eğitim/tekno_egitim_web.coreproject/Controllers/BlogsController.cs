﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.core.Repository;
using tekno_egitim_web.data;

namespace tekno_egitim_web.coreproject.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Blog> @object;

        public BlogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public BlogsController(IRepository<Blog> @object)
        {
            this.@object = @object;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }

        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.blog_id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("blog_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,blog_silme")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("blog_id,baslik,aciklama,olusturulma,imageUrl,kategori_id,blog_silme")] Blog blog)
        {
            if (id != blog.blog_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.blog_id))
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
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.blog_id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.blog_id == id);
        }
    }
}
