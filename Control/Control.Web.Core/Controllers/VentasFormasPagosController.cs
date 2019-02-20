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
    public class VentasFormasPagosController : Controller
    {
        private readonly PosControlContext _context;

        public VentasFormasPagosController(PosControlContext context)
        {
            _context = context;
        }

        // GET: VentasFormasPagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasFormasPagos.ToListAsync());
        }

        // GET: VentasFormasPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasFormasPagos = await _context.VentasFormasPagos
                .FirstOrDefaultAsync(m => m.IdFormaPago == id);
            if (ventasFormasPagos == null)
            {
                return NotFound();
            }

            return View(ventasFormasPagos);
        }

        // GET: VentasFormasPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasFormasPagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormaPago,Descripcion")] VentasFormasPagos ventasFormasPagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasFormasPagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasFormasPagos);
        }

        // GET: VentasFormasPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasFormasPagos = await _context.VentasFormasPagos.FindAsync(id);
            if (ventasFormasPagos == null)
            {
                return NotFound();
            }
            return View(ventasFormasPagos);
        }

        // POST: VentasFormasPagos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFormaPago,Descripcion")] VentasFormasPagos ventasFormasPagos)
        {
            if (id != ventasFormasPagos.IdFormaPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasFormasPagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasFormasPagosExists(ventasFormasPagos.IdFormaPago))
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
            return View(ventasFormasPagos);
        }

        // GET: VentasFormasPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasFormasPagos = await _context.VentasFormasPagos
                .FirstOrDefaultAsync(m => m.IdFormaPago == id);
            if (ventasFormasPagos == null)
            {
                return NotFound();
            }

            return View(ventasFormasPagos);
        }

        // POST: VentasFormasPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasFormasPagos = await _context.VentasFormasPagos.FindAsync(id);
            _context.VentasFormasPagos.Remove(ventasFormasPagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasFormasPagosExists(int id)
        {
            return _context.VentasFormasPagos.Any(e => e.IdFormaPago == id);
        }
    }
}
