using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Models;

namespace OtherServices2.Controllers
{
    public class ServiciosController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public ServiciosController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Servicios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Servicios.ToListAsync());
        }

        // GET: Servicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.IdService == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // GET: Servicios/Create
        public async Task<IActionResult>  Create()
        {
            var tipoServiciolist = await _context.TipoServicios.ToListAsync();
            ViewData["TipoServiciolist"] = new SelectList(tipoServiciolist, "IdTipoServicio", "TipoServicio1");

            var grupoServiciolist = await _context.GrupoServicios.ToListAsync();
            ViewData["GrupoServiciolist"] = new SelectList(grupoServiciolist, "IdGrupo", "Descripcion");

            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            ViewData["IdGrupo"] = new SelectList(_context.GrupoServicios, "IdGrupo", "Descripcion");

            return View();
        }

        // POST: Servicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdService,Codigo,IdGrupo,IdTipoServicio,FechaRegistro,Descripcion,Valor")] Servicio servicio)
        {

            if (servicio.Valor != null)
            {
                _context.Add(servicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdService,Codigo,IdGrupo,IdTipoServicio,FechaRegistro,Descripcion,Valor")] Servicio servicio)
        {
            if (id != servicio.Codigo)
            {
                return NotFound();
            }

            if (servicio.Descripcion != null)
            {
                try
                {
                    _context.Update(servicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioExists(servicio.IdService))
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
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Servicios == null)
            {
                return NotFound();
            }

            var servicio = await _context.Servicios
                .FirstOrDefaultAsync(m => m.IdService == id);
            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Servicios == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Servicios'  is null.");
            }
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio != null)
            {
                _context.Servicios.Remove(servicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioExists(int id)
        {
          return _context.Servicios.Any(e => e.IdService == id);
        }
        public IActionResult Eliminar(int id)
        {
            var Servicios = _context.Servicios.Find(id);
            if (Servicios != null)

                try
                {
                    _context.Servicios.Remove(Servicios);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    ViewData["MensajeError"] = "Este registro no se puede eliminar";
                    return RedirectToAction(nameof(Index));
                }

            return RedirectToAction(nameof(Index));
        }
    }
}
