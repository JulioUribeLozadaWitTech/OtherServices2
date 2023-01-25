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
    public class FuncionariosController : Controller
    {
        private readonly BillOtherServicesContext _context;

        public FuncionariosController(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
              return View(await _context.Funcionarios.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(string id)
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

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocIdentTercero,TipoIdentTercero,PrimerApellido,SegundoApellido,PrimerNombre,SegundoNombre,Vinculacion,Movil,MaritalStatus,CodMpioDomicilio,BarrioDomicilio,DireccionDomicilio,TelefonoAlterno,Genero,Fax,TelefonoDomicilio,CorreoPersonal,CorreoCorporativo,CodPaisDomicilio,Zona,UsuarioRegistro,PostalCode,DocUnicoTercero,FechaRegistro,CodArl,CodFondoP,CodFondoCes,CodInstEduc,CodNivel,CodTipoVinc")] Funcionario funcionario)
        {
            var documento = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.DocIdentTercero == funcionario.DocIdentTercero);

            if(funcionario.DocIdentTercero != null && documento == null)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MensajeError"] = "El documento ya esta registrado";
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DocIdentTercero,TipoIdentTercero,PrimerApellido,SegundoApellido,PrimerNombre,SegundoNombre,Vinculacion,Movil,MaritalStatus,CodOccupation,CodMpioDomicilio,BarrioDomicilio,DireccionDomicilio,TelefonoAlterno,Genero,Fax,TelefonoDomicilio,Nombre,CorreoPersonal,CorreoCorporativo,CodPaisDomicilio,Zona,UsuarioRegistro,PostalCode,DocUnicoTercero,FechaRegistro,CodArl,CodFondoP,CodFondoCes,CodInstEduc,CodNivel,CodTipoVinc")] Funcionario funcionario)
        {
            if (id != funcionario.DocIdentTercero)
            {
                return NotFound();
            }

            if (funcionario.DocIdentTercero != null && funcionario.TipoIdentTercero != null && funcionario.PrimerApellido != null && funcionario.PrimerNombre != null)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.DocIdentTercero))
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
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(string id)
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

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Funcionarios'  is null.");
            }
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(string id)
        {
          return _context.Funcionarios.Any(e => e.DocIdentTercero == id);
        }

        public IActionResult Eliminar(string id)
        {
            var Funcionarios = _context.Funcionarios.Find(id);
            if (Funcionarios != null)

                try
                {
                    _context.Funcionarios.Remove(Funcionarios);
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
