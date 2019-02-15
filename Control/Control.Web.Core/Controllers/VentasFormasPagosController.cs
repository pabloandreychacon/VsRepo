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

        // GET: VentasFormasPagoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasFormasPagos.ToListAsync());
        }

        // GET: VentasFormasPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasFormasPago = await _context.VentasFormasPagos
                .FirstOrDefaultAsync(m => m.IdFormaPago == id);
            if (ventasFormasPago == null)
            {
                return NotFound();
            }

            return View(ventasFormasPago);
        }

        // GET: VentasFormasPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasFormasPagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormaPago,Descripcion")] VentasFormasPago ventasFormasPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasFormasPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasFormasPago);
        }

        // GET: VentasFormasPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasFormasPago = await _context.VentasFormasPagos.FindAsync(id);
            if (ventasFormasPago == null)
            {
                return NotFound();
            }
            return View(ventasFormasPago);
        }

        // POST: VentasFormasPagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFormaPago,Descripcion")] VentasFormasPago ventasFormasPago)
        {
            if (id != ventasFormasPago.IdFormaPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasFormasPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasFormasPagoExists(ventasFormasPago.IdFormaPago))
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
            return View(ventasFormasPago);
        }

        // GET: VentasFormasPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasFormasPago = await _context.VentasFormasPagos
                .FirstOrDefaultAsync(m => m.IdFormaPago == id);
            if (ventasFormasPago == null)
            {
                return NotFound();
            }

            return View(ventasFormasPago);
        }

        // POST: VentasFormasPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasFormasPago = await _context.VentasFormasPagos.FindAsync(id);
            _context.VentasFormasPagos.Remove(ventasFormasPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasFormasPagoExists(int id)
        {
            return _context.VentasFormasPagos.Any(e => e.IdFormaPago == id);
        }
    }
}
