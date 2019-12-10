using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AHSDemo.Models;

namespace AHSDemo.Views
{
    public class DepartmentsController : Controller
    {
        private readonly AHSDemoDbContext _context;

        public DepartmentsController()
        {
            _context = new AHSDemoDbContext();
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var aHSDemoDbContext = _context.Departments.Include(d => d.Hospital);
            return View(await aHSDemoDbContext.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .Include(d => d.Hospital)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "HospitalId", "HospitalId");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName,HospitalId")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "HospitalId", "HospitalId", departments.HospitalId);
            return View(departments);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "HospitalId", "HospitalId", departments.HospitalId);
            return View(departments);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName,HospitalId")] Departments departments)
        {
            if (id != departments.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsExists(departments.DepartmentId))
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
            ViewData["HospitalId"] = new SelectList(_context.Hospitals, "HospitalId", "HospitalId", departments.HospitalId);
            return View(departments);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .Include(d => d.Hospital)
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departments = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(departments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
