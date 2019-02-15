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
    public class GeneralParametrosController : Controller
    {
        private readonly PosControlContext _context;

        public GeneralParametrosController(PosControlContext context)
        {
            _context = context;
        }

        // GET: GeneralParametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.GeneralParametros.ToListAsync());
        }

        // GET: GeneralParametros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalParametros = await _context.GeneralParametros
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (generalParametros == null)
            {
                return NotFound();
            }

            return View(generalParametros);
        }

        // GET: GeneralParametros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GeneralParametros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametro,ConsecutivoFacturas,EnviarFactura,NombreEmpresa,DetalleFacturas,Telefono,Correo,Identificacion,RutaLogo,RutaSistema,HostCorreo,PortCorreo,TimeOutCorreo,UserNameCorreo,PasswordCorreo,FromCorreo,DisplayNameCorreo,CorreoContactoRespaldos")] GeneralParametros generalParametros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(generalParametros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(generalParametros);
        }

        // GET: GeneralParametros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalParametros = await _context.GeneralParametros.FindAsync(id);
            if (generalParametros == null)
            {
                return NotFound();
            }
            return View(generalParametros);
        }

        // POST: GeneralParametros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParametro,ConsecutivoFacturas,EnviarFactura,NombreEmpresa,DetalleFacturas,Telefono,Correo,Identificacion,RutaLogo,RutaSistema,HostCorreo,PortCorreo,TimeOutCorreo,UserNameCorreo,PasswordCorreo,FromCorreo,DisplayNameCorreo,CorreoContactoRespaldos")] GeneralParametros generalParametros)
        {
            if (id != generalParametros.IdParametro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(generalParametros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralParametrosExists(generalParametros.IdParametro))
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
            return View(generalParametros);
        }

        // GET: GeneralParametros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalParametros = await _context.GeneralParametros
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (generalParametros == null)
            {
                return NotFound();
            }

            return View(generalParametros);
        }

        // POST: GeneralParametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generalParametros = await _context.GeneralParametros.FindAsync(id);
            _context.GeneralParametros.Remove(generalParametros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GeneralParametrosExists(int id)
        {
            return _context.GeneralParametros.Any(e => e.IdParametro == id);
        }
    }
}
