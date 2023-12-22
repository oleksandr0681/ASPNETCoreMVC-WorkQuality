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
    public class CriteriaController : Controller
    {
        private readonly WorkQualityDbContext _context;

        public CriteriaController(WorkQualityDbContext context)
        {
            _context = context;
        }

        // GET: Criteria
        public async Task<IActionResult> Index()
        {
              return _context.Criteria != null ? 
                          View(await _context.Criteria.ToListAsync()) :
                          Problem("Entity set 'WorkQualityDbContext.Criteria'  is null.");
        }

        // GET: Criteria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Criteria == null)
            {
                return NotFound();
            }

            var criterion = await _context.Criteria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (criterion == null)
            {
                return NotFound();
            }

            return View(criterion);
        }

        // GET: Criteria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Criteria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PriorityCoefficient")] Criterion criterion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(criterion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criterion);
        }

        // GET: Criteria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Criteria == null)
            {
                return NotFound();
            }

            var criterion = await _context.Criteria.FindAsync(id);
            if (criterion == null)
            {
                return NotFound();
            }
            return View(criterion);
        }

        // POST: Criteria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PriorityCoefficient")] Criterion criterion)
        {
            if (id != criterion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(criterion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CriterionExists(criterion.Id))
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
            return View(criterion);
        }

        // GET: Criteria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Criteria == null)
            {
                return NotFound();
            }

            var criterion = await _context.Criteria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (criterion == null)
            {
                return NotFound();
            }

            return View(criterion);
        }

        // POST: Criteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Criteria == null)
            {
                return Problem("Entity set 'WorkQualityDbContext.Criteria'  is null.");
            }
            var criterion = await _context.Criteria.FindAsync(id);
            if (criterion != null)
            {
                _context.Criteria.Remove(criterion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CriterionExists(int id)
        {
          return (_context.Criteria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
