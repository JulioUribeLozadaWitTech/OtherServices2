using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Models2;

namespace OtherServices2.Controllers
{
    public class ServicePortalsController : Controller
    {
        private readonly PatientPortalContext _context;

        public ServicePortalsController(PatientPortalContext context)
        {
            _context = context;
        }

        // GET: ServicePortals
        public async Task<IActionResult> Index()
        {
              return View(await _context.ServicePortals.ToListAsync());
        }

        // GET: ServicePortals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicePortals == null)
            {
                return NotFound();
            }

            var servicePortal = await _context.ServicePortals
                .FirstOrDefaultAsync(m => m.IdServicePortal == id);
            if (servicePortal == null)
            {
                return NotFound();
            }

            return View(servicePortal);
        }

        // GET: ServicePortals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicePortals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicePortal,ServiceName,ServiceDescription,TypeProcedure,TypeProcedureThumb,Cost,TypeCostThumb,TimeMinute,TypeTimeThumb,WhenToDo,WhenToDoThumb,Parameter,LoginRequired,Href,OrderList")] ServicePortal servicePortal)
        {
            if (servicePortal.ServiceName != null && Request.Form.Files.Count > 0)
            {
                MemoryStream ms = new MemoryStream();
                await Request.Form.Files[0].CopyToAsync(ms);
                servicePortal.ServiceThumbnail = ms.ToString();
                ms.Close();
                ms.Dispose();

                _context.Add(servicePortal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicePortal);
        }

        // GET: ServicePortals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicePortals == null)
            {
                return NotFound();
            }

            var servicePortal = await _context.ServicePortals.FindAsync(id);
            if (servicePortal == null)
            {
                return NotFound();
            }
            return View(servicePortal);
        }

        // POST: ServicePortals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicePortal,ServiceName,ServiceThumbnail,ServiceDescription,TypeProcedure,TypeProcedureThumb,Cost,TypeCostThumb,TimeMinute,TypeTimeThumb,WhenToDo,WhenToDoThumb,Parameter,LoginRequired,Href,OrderList")] ServicePortal servicePortal)
        {
            if (id != servicePortal.IdServicePortal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicePortal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicePortalExists(servicePortal.IdServicePortal))
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
            return View(servicePortal);
        }

        // GET: ServicePortals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicePortals == null)
            {
                return NotFound();
            }

            var servicePortal = await _context.ServicePortals
                .FirstOrDefaultAsync(m => m.IdServicePortal == id);
            if (servicePortal == null)
            {
                return NotFound();
            }

            return View(servicePortal);
        }

        // POST: ServicePortals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicePortals == null)
            {
                return Problem("Entity set 'PatientPortalContext.ServicePortals'  is null.");
            }
            var servicePortal = await _context.ServicePortals.FindAsync(id);
            if (servicePortal != null)
            {
                _context.ServicePortals.Remove(servicePortal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicePortalExists(int id)
        {
          return _context.ServicePortals.Any(e => e.IdServicePortal == id);
        }

        public IActionResult Eliminar(int id)
        {
            var servicePortal = _context.ServicePortals.Find(id);
            if (servicePortal != null)

                try
                {
                    _context.ServicePortals.Remove(servicePortal);
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
