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
    public class VehiculoesController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public VehiculoesController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Vehiculoes
        public async Task<IActionResult> Index()
        {
            var billOtherServicesContext = _context.Vehiculos.Include(v => v.DocIdentTerceroNavigation);
            return View(await billOtherServicesContext.ToListAsync());
        }

        // GET: Vehiculoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.DocIdentTerceroNavigation)
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculoes/Create
        public IActionResult Create()
        {
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero");
            return View();
        }

        // POST: Vehiculoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("DocIdentTercero,Placa,Tipo,Color,Linea,Marca,Principal,IdVehiculo,FechaRegistro,UsuarioRegistro")] Vehiculo vehiculo)
        {
            var placa = await _context.Vehiculos
                .FirstOrDefaultAsync(m => m.Placa == vehiculo.Placa);

            if ( vehiculo.DocIdentTercero != null && placa == null)
            {
                _context.Add(vehiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero", vehiculo.DocIdentTercero);
            ViewData["MensajeError"] = "La placa ya esta registrada";
            return View(vehiculo);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsFuncionario(string id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.DocIdentTercero == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return new JsonResult(funcionario);
        }

        // GET: Vehiculoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo == null)
            {
                return NotFound();
            }
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero", vehiculo.DocIdentTercero);
            return View(vehiculo);
        }

        // POST: Vehiculoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVehiculo,DocIdentTercero,Tipo,Placa,Color,Linea,Marca,Principal")] Vehiculo vehiculo)
        {
            if (id != vehiculo.IdVehiculo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiculoExists(vehiculo.IdVehiculo))
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
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero", vehiculo.DocIdentTercero);
            return View(vehiculo);
        }

        // GET: Vehiculoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.DocIdentTerceroNavigation)
                .FirstOrDefaultAsync(m => m.IdVehiculo == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehiculos == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Vehiculos'  is null.");
            }
            var vehiculo = await _context.Vehiculos.FindAsync(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiculoExists(int id)
        {
            return _context.Vehiculos.Any(e => e.IdVehiculo == id);
        }
        public IActionResult Eliminar(int id)
        {
            var Vehiculos = _context.Vehiculos.Find(id);
            if (Vehiculos != null)

                try
                {
                    _context.Vehiculos.Remove(Vehiculos);
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
