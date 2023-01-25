using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Models;
using OtherServices2.Models2;

namespace OtherServices2.Controllers
{
    public class TerceroController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public TerceroController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Tercero
        public async Task<IActionResult> Index()
        {
            var billOtherServicesContext = _context.Terceros.Include(t => t.TipoIdentTerceroNavigation);
            return View(await billOtherServicesContext.ToListAsync());
        }

        // GET: Tercero/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Terceros == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .Include(t => t.TipoIdentTerceroNavigation)
                .FirstOrDefaultAsync(m => m.DocIdentTercero == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // GET: Tercero/Create
        public IActionResult Create()
        {
            ViewData["TipoIdentTercero"] = new SelectList(_context.TipoIdentTerceros, "TipoIdentTercero1", "TipoIdentTercero1");
            return View();
        }

        // POST: Tercero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocIdentTercero,TipoIdentTercero,PrimerApellido,SegundoApellido,PrimerNombre,SegundoNombre,Vinculacion,Movil,MaritalStatus,CodOccupation,CodMpioDomicilio,BarrioDomicilio,DireccionDomicilio,TelefonoAlterno,Genero,Fax,TelefonoDomicilio,Nombre,CorreoPersonal,CorreoCorporativo,CodPaisDomicilio,Zona,UsuarioRegistro,PostalCode,DocUnicoTercero,FechaRegistro")] Tercero tercero)
        {
            var documento = await _context.Terceros
                .FirstOrDefaultAsync(m => m.DocIdentTercero == tercero.DocIdentTercero);

            if (tercero.DocIdentTercero != null && documento == null)
            {
                _context.Add(tercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoIdentTercero"] = new SelectList(_context.TipoIdentTerceros, "TipoIdentTercero1", "TipoIdentTercero1", tercero.TipoIdentTercero);
            ViewData["MensajeError"] = "El documento ya esta registrado";
            return View(tercero);
        }

        // GET: Tercero/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Terceros == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero == null)
            {
                return NotFound();
            }
            ViewData["TipoIdentTercero"] = new SelectList(_context.TipoIdentTerceros, "TipoIdentTercero1", "TipoIdentTercero1", tercero.TipoIdentTercero);
            return View(tercero);
        }

        // POST: Tercero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DocIdentTercero,TipoIdentTercero,PrimerApellido,SegundoApellido,PrimerNombre,SegundoNombre,Vinculacion,Movil,MaritalStatus,CodOccupation,CodMpioDomicilio,BarrioDomicilio,DireccionDomicilio,TelefonoAlterno,Genero,Fax,TelefonoDomicilio,Nombre,CorreoPersonal,CorreoCorporativo,CodPaisDomicilio,Zona,UsuarioRegistro,PostalCode,DocUnicoTercero,FechaRegistro")] Tercero tercero)
        {
            if (id != tercero.DocIdentTercero)
            {
                return NotFound();
            }

            if (tercero.DocIdentTercero != null && tercero.TipoIdentTercero != null && tercero.PrimerApellido != null && tercero.PrimerNombre != null)
            {
                try
                {
                    _context.Update(tercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceroExists(tercero.DocIdentTercero))
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
            ViewData["TipoIdentTercero"] = new SelectList(_context.TipoIdentTerceros, "TipoIdentTercero1", "TipoIdentTercero1", tercero.TipoIdentTercero);
            return View(tercero);
        }

        // GET: Tercero/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Terceros == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .Include(t => t.TipoIdentTerceroNavigation)
                .FirstOrDefaultAsync(m => m.DocIdentTercero == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        //POST: Tercero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Terceros == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Terceros'  is null.");
            }
            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero != null)
            {
                _context.Terceros.Remove(tercero);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceroExists(string id)
        {
            return _context.Terceros.Any(e => e.DocIdentTercero == id);
        }

        public IActionResult Eliminar(string id)
        {
            var Tercero = _context.Terceros.Find(id);
            if (Tercero != null)

                try
                {
                    _context.Terceros.Remove(Tercero);
                    _context.SaveChanges();
                }

                catch (Exception)
                {
                    ViewData["MensajeError"] = "La placa ya esta registrada";
                    return RedirectToAction(nameof(Index));
                }
            return RedirectToAction(nameof(Index));
        }

    }
}
