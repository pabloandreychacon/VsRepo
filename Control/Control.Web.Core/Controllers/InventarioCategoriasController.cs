using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control.Web.Core.Models;

namespace Control.Web.Core.Controllers
{
    public class InventarioCategoriasController : Controller
    {
        private readonly PosControlContext _context;

        public InventarioCategoriasController(PosControlContext context)
        {
            _context = context;
        }

        // GET: InventarioCategorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventarioCategorias.ToListAsync());
        }

        // GET: InventarioCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioCategorias = await _context.InventarioCategorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (inventarioCategorias == null)
            {
                return NotFound();
            }

            return View(inventarioCategorias);
        }

        // GET: InventarioCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,Descripcion")] InventarioCategorias inventarioCategorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioCategorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioCategorias);
        }

        // GET: InventarioCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioCategorias = await _context.InventarioCategorias.FindAsync(id);
            if (inventarioCategorias == null)
            {
                return NotFound();
            }
            return View(inventarioCategorias);
        }

        // POST: InventarioCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,Descripcion")] InventarioCategorias inventarioCategorias)
        {
            if (id != inventarioCategorias.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioCategorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioCategoriasExists(inventarioCategorias.IdCategoria))
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
            return View(inventarioCategorias);
        }

        // GET: InventarioCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioCategorias = await _context.InventarioCategorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (inventarioCategorias == null)
            {
                return NotFound();
            }

            return View(inventarioCategorias);
        }

        // POST: InventarioCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioCategorias = await _context.InventarioCategorias.FindAsync(id);
            _context.InventarioCategorias.Remove(inventarioCategorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioCategoriasExists(int id)
        {
            return _context.InventarioCategorias.Any(e => e.IdCategoria == id);
        }
    }
}
