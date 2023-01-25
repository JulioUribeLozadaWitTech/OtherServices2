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
    public class VigenciaCupoesController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public VigenciaCupoesController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: VigenciaCupoes
        public async Task<IActionResult> Index()
        {
            var billOtherServicesContext = _context.VigenciaCupos.Include(v => v.DocIdentTerceroNavigation).Include(v => v.IdCupoNavigation);
            return View(await billOtherServicesContext.ToListAsync());
        }

        // GET: VigenciaCupoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VigenciaCupos == null)
            {
                return NotFound();
            }

            var vigenciaCupo = await _context.VigenciaCupos
                .Include(v => v.DocIdentTerceroNavigation)
                .Include(v => v.IdServiceNavigation)
                .FirstOrDefaultAsync(m => m.IdCupo == id);

            if (vigenciaCupo == null)
            {
                return NotFound();
            }

            return View(vigenciaCupo);
        }

        // GET: VigenciaCupoes/Create
        public async Task<IActionResult> Create()
        {
            var arealist = await _context.Cupos.ToListAsync();
            var serviciolist = await _context.Servicios.ToListAsync();

            var listdistig = arealist.Select(item => item.Area).Distinct().ToList();
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero");
            
            ViewData["DocIdentTercero"] = new SelectList(_context.Vehiculos, "DocIdentTercero", "DocIdentTercero");
            
            ViewData["AreaList"] = new SelectList(listdistig);
            ViewData["ServicioList"] = new SelectList(serviciolist, "IdService", "Descripcion");

            return View();

        }

        // POST: VigenciaCupoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("FechaDesde,FechaHasta,Jornada,DocIdentTercero,IdCupo,Placa,TipoVehiculo,IdService")] VigenciaCupo vigenciaCupo)
        {
            {
                String query = $"Exec[PARQ].[VigenciaCupoInsert]  '{vigenciaCupo.FechaDesde.ToString("yyyy-MM-dd")}','{vigenciaCupo.FechaHasta.ToString("yyyy-MM-dd")}','{vigenciaCupo.DocIdentTercero}',{vigenciaCupo.IdCupo},'{vigenciaCupo.TipoVehiculo}','{vigenciaCupo.Placa}','{vigenciaCupo.Jornada}','',{vigenciaCupo.IdService}";
                await _context.Database.ExecuteSqlRawAsync(query);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero", vigenciaCupo.DocIdentTercero);

            ViewData["DocIdentTercero"] = new SelectList(_context.Vehiculos, "DocIdentTercero", "DocIdentTercero");
            
            return View(vigenciaCupo);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsFuncionario(string id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.Include(m => m.Vehiculos)
                .FirstOrDefaultAsync(m => m.DocIdentTercero == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return new JsonResult(funcionario);
        }

        [HttpGet]
        public async Task<IActionResult> NumeroCupos(string id)
        {
            if (id == null || _context.Cupos == null)
            {
                return NotFound();
            }

            var numCupo = await _context.Cupos.OrderBy(m => m.NoCupoArea)
                .ToListAsync();
            var numCupolist = numCupo.Where(m => m.Area == id && m.DocIdentTercero == null).ToList();

            return new JsonResult(numCupolist);
        }

        // GET: Vehiculoes/Details/5
        public async Task<IActionResult> DetailsVehiculo(int? id)
        {
            if (id == null || _context.Vehiculos == null)
            {
                return NotFound();
            }

            var vehiculo = await _context.Vehiculos
                .Include(v => v.DocIdentTerceroNavigation)
                .FirstOrDefaultAsync(m => int.Parse(m.DocIdentTerceroNavigation.DocUnicoTercero) == id);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return new JsonResult(vehiculo);
        }

        // GET: VigenciaCupoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VigenciaCupos == null)
            {
                return NotFound();
            }

            var vigenciaCupo = await _context.VigenciaCupos.FindAsync(id);
            if (vigenciaCupo == null)
            {
                return NotFound();
            }
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero", vigenciaCupo.DocIdentTercero);
            return View(vigenciaCupo);
        }

        // POST: VigenciaCupoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaDesde,FechaHasta,Jornada,DocIdentTercero,IdCupo")] VigenciaCupo vigenciaCupo)
        {
            if (id != vigenciaCupo.IdCupo)
            {
                return NotFound();
            }

            if (vigenciaCupo.DocIdentTercero != null)
            {
                try
                {
                    _context.Update(vigenciaCupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VigenciaCupoExists(vigenciaCupo.IdCupo))
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
            ViewData["DocIdentTercero"] = new SelectList(_context.Funcionarios, "DocIdentTercero", "DocIdentTercero", vigenciaCupo.DocIdentTercero);
            return View(vigenciaCupo);
        }

        // GET: VigenciaCupoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VigenciaCupos == null)
            {
                return NotFound();
            }

            var vigenciaCupo = await _context.VigenciaCupos
                .Include(v => v.DocIdentTerceroNavigation)
                .Include(v => v.IdServiceNavigation)
                .FirstOrDefaultAsync(m => m.IdVigencia == id);
            if (vigenciaCupo == null)
            {
                return NotFound();
            }

            return View(vigenciaCupo);
        }

        // POST: VigenciaCupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VigenciaCupos == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.VigenciaCupos'  is null.");
            }
            var vigenciaCupo = await _context.VigenciaCupos.FindAsync(id);
            if (vigenciaCupo != null)
            {
                var cupo = await _context.Cupos
                    .FirstOrDefaultAsync(m => m.IdCupo == vigenciaCupo.IdCupo);

                cupo.DocIdentTercero = null;
                _context.Update(cupo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VigenciaCupoExists(int id)
        {
            return _context.VigenciaCupos.Any(e => e.IdCupo == id);
        }

        public async Task <IActionResult> Eliminar(int id)
        {
            var VigenciaCupos = _context.VigenciaCupos.Find(id);
            if (VigenciaCupos != null)

                try
                {
                    _context.VigenciaCupos.Remove(VigenciaCupos);

                    var cupo = await _context.Cupos
                        .FirstOrDefaultAsync(m => m.IdCupo == VigenciaCupos.IdCupo);

                    cupo.DocIdentTercero = null;
                    _context.Update(cupo);

                    await _context.SaveChangesAsync();

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
