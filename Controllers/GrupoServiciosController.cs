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
    public class GrupoServiciosController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public GrupoServiciosController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: GrupoServicios
        public async Task<IActionResult> Index()
        {
            var billOtherServicesContext = _context.GrupoServicios.Include(g => g.IdTipoServicioNavigation);
            return View(await billOtherServicesContext.ToListAsync());
        }

        // GET: GrupoServicios/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.GrupoServicios == null)
            {
                return NotFound();
            }

            var grupoServicio = await _context.GrupoServicios
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupoServicio == null)
            {
                return NotFound();
            }

            return View(grupoServicio);
        }

        // GET: GrupoServicios/Create
        public async Task<IActionResult> Create()
        {
            
            var tipoServiciolist = await _context.TipoServicios.ToListAsync();
            ViewData["TipoServiciolist"] = new SelectList(tipoServiciolist, "IdTipoServicio", "TipoServicio1");
            
            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");
            

            return View();
        }

        // POST: GrupoServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,Descripcion,IdTipoServicio,FechaRegistro")] GrupoServicio grupoServicio)
        {

            if (grupoServicio.IdGrupo != null && Request.Form.Files.Count > 0)
            {
                MemoryStream ms = new MemoryStream();
                await Request.Form.Files[0].CopyToAsync(ms);
                grupoServicio.thumbnails = ms.ToArray();
                ms.Close();
                ms.Dispose();

                _context.Add(grupoServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(grupoServicio);
        }


        // GET: GrupoServicios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.GrupoServicios == null)
            {
                return NotFound();
            }

            var grupoServicio = await _context.GrupoServicios.FindAsync(id);
            if (grupoServicio == null)
            {
                return NotFound();
            }

            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "TipoServicio1");

            return View(grupoServicio);
        }

        // POST: GrupoServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdGrupo,Descripcion,IdTipoServicio,FechaRegistro")] GrupoServicio grupoServicio)
        {
            if (id != grupoServicio.IdGrupo)
            {
                return NotFound();
            }

            if (grupoServicio.IdTipoServicio != null)
            {
                try
                {
                    var oldgrupoServicio = await _context.GrupoServicios
                        .FirstOrDefaultAsync(m => m.IdGrupo == id);

                    oldgrupoServicio.Descripcion = grupoServicio.Descripcion;
                    oldgrupoServicio.IdTipoServicio = grupoServicio.IdTipoServicio;

                    if (Request.Form.Files.Count > 0)
                    {
                        MemoryStream ms = new MemoryStream();
                        await Request.Form.Files[0].CopyToAsync(ms);
                        oldgrupoServicio.thumbnails = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }

                    _context.GrupoServicios.Update(oldgrupoServicio);

                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {
                    ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "IdTipoServicio", grupoServicio.IdTipoServicio);
                    ViewData["MensajeError"] = "Ocurrio un error al guardar el registro";
                    return View(grupoServicio);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoServicio"] = new SelectList(_context.TipoServicios, "IdTipoServicio", "IdTipoServicio", grupoServicio.IdTipoServicio);
            return View(grupoServicio);
        }


        // GET: GrupoServicios/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.GrupoServicios == null)
            {
                return NotFound();
            }

            var grupoServicio = await _context.GrupoServicios
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (grupoServicio == null)
            {
                return NotFound();
            }

            return View(grupoServicio);
        }

        // POST: GrupoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.GrupoServicios == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.GrupoServicios'  is null.");
            }
            var grupoServicio = await _context.GrupoServicios.FindAsync(id);
            if (grupoServicio != null)
            {
                _context.GrupoServicios.Remove(grupoServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoServicioExists(string id)
        {
            return _context.GrupoServicios.Any(e => e.IdGrupo == id);
        }

        public IActionResult Eliminar(string id)
        {
            var GrupoServicios = _context.GrupoServicios.Find(id);
            if (GrupoServicios != null)

                try
                {
                    _context.GrupoServicios.Remove(GrupoServicios);
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
