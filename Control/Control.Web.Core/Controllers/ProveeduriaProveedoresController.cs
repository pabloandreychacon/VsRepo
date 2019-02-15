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
    public class ProveeduriaProveedoresController : Controller
    {
        private readonly PosControlContext _context;

        public ProveeduriaProveedoresController(PosControlContext context)
        {
            _context = context;
        }

        // GET: ProveeduriaProveedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProveeduriaProveedores.ToListAsync());
        }

        // GET: ProveeduriaProveedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveeduriaProveedores = await _context.ProveeduriaProveedores
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (proveeduriaProveedores == null)
            {
                return NotFound();
            }

            return View(proveeduriaProveedores);
        }

        // GET: ProveeduriaProveedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProveeduriaProveedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedor,Nombre,Telefono,Correo,Identificacion")] ProveeduriaProveedores proveeduriaProveedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveeduriaProveedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveeduriaProveedores);
        }

        // GET: ProveeduriaProveedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveeduriaProveedores = await _context.ProveeduriaProveedores.FindAsync(id);
            if (proveeduriaProveedores == null)
            {
                return NotFound();
            }
            return View(proveeduriaProveedores);
        }

        // POST: ProveeduriaProveedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedor,Nombre,Telefono,Correo,Identificacion")] ProveeduriaProveedores proveeduriaProveedores)
        {
            if (id != proveeduriaProveedores.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveeduriaProveedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveeduriaProveedoresExists(proveeduriaProveedores.IdProveedor))
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
            return View(proveeduriaProveedores);
        }

        // GET: ProveeduriaProveedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveeduriaProveedores = await _context.ProveeduriaProveedores
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (proveeduriaProveedores == null)
            {
                return NotFound();
            }

            return View(proveeduriaProveedores);
        }

        // POST: ProveeduriaProveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proveeduriaProveedores = await _context.ProveeduriaProveedores.FindAsync(id);
            _context.ProveeduriaProveedores.Remove(proveeduriaProveedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProveeduriaProveedoresExists(int id)
        {
            return _context.ProveeduriaProveedores.Any(e => e.IdProveedor == id);
        }
    }
}
