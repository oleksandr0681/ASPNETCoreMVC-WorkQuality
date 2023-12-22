using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkQuality.Models;

namespace WorkQuality.Controllers
{
    public class ExaminationsController : Controller
    {
        private readonly WorkQualityDbContext _context;

        public ExaminationsController(WorkQualityDbContext context)
        {
            _context = context;
        }

        // GET: Examinations
        public async Task<IActionResult> Index()
        {
            var workQualityDbContext = _context.Examinations.Include(e => e.Employee);
            return View(await workQualityDbContext.ToListAsync());
        }

        // GET: Examinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Examinations == null)
            {
                return NotFound();
            }

            var examination = await _context.Examinations
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examination == null)
            {
                return NotFound();
            }

            return View(examination);
        }

        // GET: Examinations/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Examinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,Date")] Examination examination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(examination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", examination.EmployeeId);
            return View(examination);
        }

        // GET: Examinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Examinations == null)
            {
                return NotFound();
            }

            var examination = await _context.Examinations.FindAsync(id);
            if (examination == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", examination.EmployeeId);
            return View(examination);
        }

        // POST: Examinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Date")] Examination examination)
        {
            if (id != examination.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(examination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExaminationExists(examination.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", examination.EmployeeId);
            return View(examination);
        }

        // GET: Examinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Examinations == null)
            {
                return NotFound();
            }

            var examination = await _context.Examinations
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (examination == null)
            {
                return NotFound();
            }

            return View(examination);
        }

        // POST: Examinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Examinations == null)
            {
                return Problem("Entity set 'WorkQualityDbContext.Examinations'  is null.");
            }
            var examination = await _context.Examinations.FindAsync(id);
            if (examination != null)
            {
                _context.Examinations.Remove(examination);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExaminationExists(int id)
        {
          return (_context.Examinations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
