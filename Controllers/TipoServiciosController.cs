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
    public class TipoServiciosController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public TipoServiciosController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: TipoServicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoServicios.ToListAsync());
        }

        // GET: TipoServicios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TipoServicios == null)
            {
                return NotFound();
            }

            var tipoServicio = await _context.TipoServicios
                .FirstOrDefaultAsync(m => m.IdTipoServicio == id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            return View(tipoServicio);
        }

        // GET: TipoServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoServicio,TipoServicio1,FechaRegistro")] TipoServicio tipoServicio)
        {

            if (tipoServicio.TipoServicio1 != null)
            {
                _context.Add(tipoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoServicio);
        }

        // GET: TipoServicios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TipoServicios == null)
            {
                return NotFound();
            }

            var tipoServicio = await _context.TipoServicios.FindAsync(id);
            if (tipoServicio == null)
            {
                return NotFound();
            }
            return View(tipoServicio);
        }

        // POST: TipoServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdTipoServicio,TipoServicio1,FechaRegistro")] TipoServicio tipoServicio)
        {
            if (id != tipoServicio.IdTipoServicio)
            {
                return NotFound();
            }

            if (tipoServicio.TipoServicio1 != null)
            {
                try
                {
                    _context.Update(tipoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoServicioExists(tipoServicio.IdTipoServicio))
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
            return View(tipoServicio);
        }

        // GET: TipoServicios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TipoServicios == null)
            {
                return NotFound();
            }

            var tipoServicio = await _context.TipoServicios
                .FirstOrDefaultAsync(m => m.IdTipoServicio == id);
            if (tipoServicio == null)
            {
                return NotFound();
            }

            return View(tipoServicio);
        }

        // POST: TipoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TipoServicios == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.TipoServicios'  is null.");
            }
            var tipoServicio = await _context.TipoServicios.FindAsync(id);
            if (tipoServicio != null)
            {
                _context.TipoServicios.Remove(tipoServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoServicioExists(string id)
        {
            return _context.TipoServicios.Any(e => e.IdTipoServicio == id);
        }

        public IActionResult Eliminar(string id)
        {
            var TipoServicio = _context.TipoServicios.Find(id);
            if (TipoServicio == null)
            {
                return StatusCode(404);
            }
            _context.TipoServicios.Remove(TipoServicio);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
