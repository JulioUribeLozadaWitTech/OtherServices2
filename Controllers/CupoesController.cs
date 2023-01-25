using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Models;
using OtherServices2.Models2;

namespace OtherServices2.Controllers
{
    public class CupoesController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public CupoesController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Cupoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cupos.ToListAsync());
        }

        // GET: Cupoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cupos == null)
            {
                return NotFound();
            }

            var cupo = await _context.Cupos
                .FirstOrDefaultAsync(m => m.IdCupo == id);
            if (cupo == null)
            {
                return NotFound();
            }

            return View(cupo);
        }

        // GET: Cupoes/Create
        public IActionResult Create()
        {
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero");
            return View();
        }

        // POST: Cupoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCupo,Area,NoCupoArea")] Cupo cupo)
        {
            if (cupo.Area != null)
            {
                _context.Add(cupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cupo);
        }

        // GET: Cupoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cupos == null)
            {
                return NotFound();
            }

            var cupo = await _context.Cupos.FindAsync(id);
            if (cupo == null)
            {
                return NotFound();
            }
            return View(cupo);
        }

        // POST: Cupoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCupo,Area,NoCupoArea")] Cupo cupo)
        {
            if (id != cupo.IdCupo)
            {
                return NotFound();
            }

            if(cupo.Area != null)
            {
                try
                {
                    _context.Update(cupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CupoExists(cupo.IdCupo))
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
            return View(cupo);
        }

        // GET: Cupoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cupos == null)
            {
                return NotFound();
            }

            var cupo = await _context.Cupos
                .FirstOrDefaultAsync(m => m.IdCupo == id);
            if (cupo == null)
            {
                return NotFound();
            }

            return View(cupo);
        }

        // POST: Cupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cupos == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Cupos'  is null.");
            }
            var cupo = await _context.Cupos.FindAsync(id);
            if (cupo != null)
            {
                _context.Cupos.Remove(cupo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CupoExists(int id)
        {
          return _context.Cupos.Any(e => e.IdCupo == id);
        }
        public IActionResult Eliminar(int id)
        {
            var Cupos = _context.Cupos.Find(id);
            if (Cupos != null)

                try
                {
                    _context.Cupos.Remove(Cupos);
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
