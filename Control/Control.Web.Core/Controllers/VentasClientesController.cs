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
    public class VentasClientesController : Controller
    {
        private readonly PosControlContext _context;

        public VentasClientesController(PosControlContext context)
        {
            _context = context;
        }

        // GET: VentasClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentasClientes.ToListAsync());
        }

        // GET: VentasClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasClientes = await _context.VentasClientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (ventasClientes == null)
            {
                return NotFound();
            }

            return View(ventasClientes);
        }

        // GET: VentasClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VentasClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nombre,Identificacion,Telefono,Correo")] VentasClientes ventasClientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasClientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventasClientes);
        }

        // GET: VentasClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasClientes = await _context.VentasClientes.FindAsync(id);
            if (ventasClientes == null)
            {
                return NotFound();
            }
            return View(ventasClientes);
        }

        // POST: VentasClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nombre,Identificacion,Telefono,Correo")] VentasClientes ventasClientes)
        {
            if (id != ventasClientes.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasClientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasClientesExists(ventasClientes.IdCliente))
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
            return View(ventasClientes);
        }

        // GET: VentasClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasClientes = await _context.VentasClientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (ventasClientes == null)
            {
                return NotFound();
            }

            return View(ventasClientes);
        }

        // POST: VentasClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventasClientes = await _context.VentasClientes.FindAsync(id);
            _context.VentasClientes.Remove(ventasClientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasClientesExists(int id)
        {
            return _context.VentasClientes.Any(e => e.IdCliente == id);
        }
    }
}
