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
    public class InventarioProductosController : Controller
    {
        private readonly PosControlContext _context;

        public InventarioProductosController(PosControlContext context)
        {
            _context = context;
        }

        // GET: InventarioProductos
        public async Task<IActionResult> Index()
        {
            var posControlContext = _context.InventarioProductos.Include(i => i.IdCategoriaNavigation).Include(i => i.IdProveedorNavigation);
            return View(await posControlContext.ToListAsync());
        }

        // GET: InventarioProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioProductos = await _context.InventarioProductos
                .Include(i => i.IdCategoriaNavigation)
                .Include(i => i.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (inventarioProductos == null)
            {
                return NotFound();
            }

            return View(inventarioProductos);
        }

        // GET: InventarioProductos/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.InventarioCategorias, "IdCategoria", "Descripcion");
            ViewData["IdProveedor"] = new SelectList(_context.ProveeduriaProveedores, "IdProveedor", "Nombre");
            return View();
        }

        // POST: InventarioProductos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,Identificador,Descripcion,IdProveedor,PrecioUnitario,PrecioVenta,IdCategoria,Impuestos,VerificaDisponible,Descuento,Utilidad")] InventarioProductos inventarioProductos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioProductos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.InventarioCategorias, "IdCategoria", "Descripcion", inventarioProductos.IdCategoria);
            ViewData["IdProveedor"] = new SelectList(_context.ProveeduriaProveedores, "IdProveedor", "Correo", inventarioProductos.IdProveedor);
            return View(inventarioProductos);
        }

        // GET: InventarioProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioProductos = await _context.InventarioProductos.FindAsync(id);
            if (inventarioProductos == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.InventarioCategorias, "IdCategoria", "Descripcion", inventarioProductos.IdCategoria);
            ViewData["IdProveedor"] = new SelectList(_context.ProveeduriaProveedores, "IdProveedor", "Correo", inventarioProductos.IdProveedor);
            return View(inventarioProductos);
        }

        // POST: InventarioProductos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,Identificador,Descripcion,IdProveedor,PrecioUnitario,PrecioVenta,IdCategoria,Impuestos,VerificaDisponible,Descuento,Utilidad")] InventarioProductos inventarioProductos)
        {
            if (id != inventarioProductos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioProductos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioProductosExists(inventarioProductos.IdProducto))
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
            ViewData["IdCategoria"] = new SelectList(_context.InventarioCategorias, "IdCategoria", "Descripcion", inventarioProductos.IdCategoria);
            ViewData["IdProveedor"] = new SelectList(_context.ProveeduriaProveedores, "IdProveedor", "Correo", inventarioProductos.IdProveedor);
            return View(inventarioProductos);
        }

        // GET: InventarioProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventarioProductos = await _context.InventarioProductos
                .Include(i => i.IdCategoriaNavigation)
                .Include(i => i.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (inventarioProductos == null)
            {
                return NotFound();
            }

            return View(inventarioProductos);
        }

        // POST: InventarioProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventarioProductos = await _context.InventarioProductos.FindAsync(id);
            _context.InventarioProductos.Remove(inventarioProductos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioProductosExists(int id)
        {
            return _context.InventarioProductos.Any(e => e.IdProducto == id);
        }
    }
}
