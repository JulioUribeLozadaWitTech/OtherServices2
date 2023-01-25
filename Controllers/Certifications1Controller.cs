﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OtherServices2.Models;

namespace OtherServices2.Controllers
{
    public class Certifications1Controller : Controller
    {
        private readonly BillOtherServicesContext _context;

        public Certifications1Controller(BillOtherServicesContext context)
        {
            _context = context;
        }

        // GET: Certifications1
        public async Task<IActionResult> Index()
        {
              return View(await _context.Certifications.ToListAsync());
        }

        // GET: Certifications1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Certifications == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .FirstOrDefaultAsync(m => m.IdCertification == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Certifications1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certifications1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCertification,NoContract,ContractNumber,DocIdentContrator,Address,MobilePhone,City,Email,TypeContract,DateSuscripcion,Object,ValueInicial,ValueAddictionNo1,ModificatorioReduccionNo1,ValueAaddictionNo2,ValueAddictionNo3,ValueFinalContract,InitialTerm,ExtensionTerm,FinalTerm,StateContract,DocIdentSupervisor,IssueDate")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certification);
        }

        // GET: Certifications1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Certifications == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.FindAsync(id);
            if (certification == null)
            {
                return NotFound();
            }
            return View(certification);
        }

        // POST: Certifications1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCertification,NoContract,ContractNumber,DocIdentContrator,Address,MobilePhone,City,Email,TypeContract,DateSuscripcion,Object,ValueInicial,ValueAddictionNo1,ModificatorioReduccionNo1,ValueAaddictionNo2,ValueAddictionNo3,ValueFinalContract,InitialTerm,ExtensionTerm,FinalTerm,StateContract,DocIdentSupervisor,IssueDate")] Certification certification)
        {
            if (id != certification.IdCertification)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationExists(certification.IdCertification))
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
            return View(certification);
        }

        // GET: Certifications1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Certifications == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .FirstOrDefaultAsync(m => m.IdCertification == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // POST: Certifications1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Certifications == null)
            {
                return Problem("Entity set 'BillOtherServicesContext.Certifications'  is null.");
            }
            var certification = await _context.Certifications.FindAsync(id);
            if (certification != null)
            {
                _context.Certifications.Remove(certification);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificationExists(int id)
        {
          return _context.Certifications.Any(e => e.IdCertification == id);
        }

        public IActionResult Eliminar(int id)
        {
            var certification = _context.Certifications.Find(id);
            if (certification == null)
            {
                return StatusCode(404);
            }
            _context.Certifications.Remove(certification);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
