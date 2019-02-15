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
    public class GeneralUsuariosController : Controller
    {
        private readonly PosControlContext _context;

        public GeneralUsuariosController(PosControlContext context)
        {
            _context = context;
        }

        // GET: GeneralUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneralUsuarios.ToListAsync());
        }

        // GET: GeneralUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalUsuarios = await _context.GeneralUsuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (generalUsuarios == null)
            {
                return NotFound();
            }

            return View(generalUsuarios);
        }

        // GET: GeneralUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Nombre,Administrador,Clave,Activo")] GeneralUsuarios generalUsuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalUsuarios);
        }

        // GET: GeneralUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalUsuarios = await _context.GeneralUsuarios.FindAsync(id);
            if (generalUsuarios == null)
            {
                return NotFound();
            }
            return View(generalUsuarios);
        }

        // POST: GeneralUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,Nombre,Administrador,Clave,Activo")] GeneralUsuarios generalUsuarios)
        {
            if (id != generalUsuarios.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalUsuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralUsuariosExists(generalUsuarios.IdUsuario))
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
            return View(generalUsuarios);
        }

        // GET: GeneralUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalUsuarios = await _context.GeneralUsuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (generalUsuarios == null)
            {
                return NotFound();
            }

            return View(generalUsuarios);
        }

        // POST: GeneralUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generalUsuarios = await _context.GeneralUsuarios.FindAsync(id);
            _context.GeneralUsuarios.Remove(generalUsuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralUsuariosExists(int id)
        {
            return _context.GeneralUsuarios.Any(e => e.IdUsuario == id);
        }
    }
}
