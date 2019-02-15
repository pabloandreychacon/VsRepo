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
    public class InventarioTiposMovimientosController : Controller
    {
        private readonly PosControlContext _context;

        public InventarioTiposMovimientosController(PosControlContext context)
        {
            _context = context;
        }

        // GET: InventarioTiposMovimientos
        public async Task<IActionResult> Index()
        {
            return View(await _context.InventarioTiposMovimientos.ToListAsync());
        }

        // GET: InventarioTiposMovimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioTiposMovimientos = await _context.InventarioTiposMovimientos
                .FirstOrDefaultAsync(m => m.IdTipoMovimiento == id);
            if (inventarioTiposMovimientos == null)
            {
                return NotFound();
            }

            return View(inventarioTiposMovimientos);
        }

        // GET: InventarioTiposMovimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioTiposMovimientos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMovimiento,Positivo,Nombre")] InventarioTiposMovimientos inventarioTiposMovimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioTiposMovimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioTiposMovimientos);
        }

        // GET: InventarioTiposMovimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioTiposMovimientos = await _context.InventarioTiposMovimientos.FindAsync(id);
            if (inventarioTiposMovimientos == null)
            {
                return NotFound();
            }
            return View(inventarioTiposMovimientos);
        }

        // POST: InventarioTiposMovimientos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMovimiento,Positivo,Nombre")] InventarioTiposMovimientos inventarioTiposMovimientos)
        {
            if (id != inventarioTiposMovimientos.IdTipoMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioTiposMovimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioTiposMovimientosExists(inventarioTiposMovimientos.IdTipoMovimiento))
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
            return View(inventarioTiposMovimientos);
        }

        // GET: InventarioTiposMovimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioTiposMovimientos = await _context.InventarioTiposMovimientos
                .FirstOrDefaultAsync(m => m.IdTipoMovimiento == id);
            if (inventarioTiposMovimientos == null)
            {
                return NotFound();
            }

            return View(inventarioTiposMovimientos);
        }

        // POST: InventarioTiposMovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioTiposMovimientos = await _context.InventarioTiposMovimientos.FindAsync(id);
            _context.InventarioTiposMovimientos.Remove(inventarioTiposMovimientos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioTiposMovimientosExists(int id)
        {
            return _context.InventarioTiposMovimientos.Any(e => e.IdTipoMovimiento == id);
        }
    }
}
