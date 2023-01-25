using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Borrar;
using OtherServices2.Models;

namespace OtherServices2.Controllers
{
    public class FacturasController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public FacturasController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facturas.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.FacturaDets)
                .FirstOrDefaultAsync(m => m.DocUnicoFact == id);

            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocUnicoFact,PrefijoFactura,NoFactura,CodConvenio,NombreConvenio,Concepto,Direccion,Movil,TipoIdentTercero,DocIdentTercero,NombreTercero,Fecha,FechaVence,FechaRegistro,FechaAnulacion,UsuarioRegistro,UsuarioAnulacion,VrDcto,VrFactura,Observacion,EstadoFact,DatoResolNum,ContactEmail,ContactName,ContactPhone,Cufe,CufeImage,CufeDateEmail")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DocUnicoFact,PrefijoFactura,NoFactura,CodConvenio,NombreConvenio,Concepto,Direccion,Movil,TipoIdentTercero,DocIdentTercero,NombreTercero,Fecha,FechaVence,FechaRegistro,FechaAnulacion,UsuarioRegistro,UsuarioAnulacion,VrDcto,VrFactura,Observacion,EstadoFact,DatoResolNum,ContactEmail,ContactName,ContactPhone,Cufe,CufeImage,CufeDateEmail")] Factura factura)
        {
            if (id != factura.DocUnicoFact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.DocUnicoFact))
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
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Facturas == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .FirstOrDefaultAsync(m => m.DocUnicoFact == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Facturas == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Facturas'  is null.");
            }
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(string id)
        {
            return _context.Facturas.Any(e => e.DocUnicoFact == id);
        }
    }
}
