using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkQuality.Models;

namespace WorkQuality.Controllers
{
    public class AssessmentsController : Controller
    {
        private readonly WorkQualityDbContext _context;

        public AssessmentsController(WorkQualityDbContext context)
        {
            _context = context;
        }

        // GET: Assessments
        public async Task<IActionResult> Index()
        {
            var workQualityDbContext = _context.Assessments.Include(a => a.Employee);
            return View(await workQualityDbContext.ToListAsync());
        }

        // GET: Assessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: Assessments/Create
        public IActionResult Create()
        {
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName");
            return View();
        }

        // POST: Assessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,AssessmentDate,TechnicalKnowledgeScore,AbilityToApplyTechnicalKnowledgeScore,ProjectManagementSkillsScore,QualityCustomerServiceScore,Rating")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                // Початок доданого мною.
                Employee? employee = await _context.Employees.Where(e => e.Id == assessment.EmployeeId).SingleOrDefaultAsync();
                if (employee != null)
                {
                    Job? job = await _context.Jobs.Where(j => j.Id == employee.JobId)
                        .SingleOrDefaultAsync();
                    if (job != null)
                    {
                        double rating = 0;
                        rating += assessment.TechnicalKnowledgeScore * 
                            job.TechnicalKnowledgePriorityCoefficient;
                        rating += assessment.AbilityToApplyTechnicalKnowledgeScore * 
                            job.AbilityToApplyTechnicalKnowledgePriorityCoefficient;
                        rating += assessment.ProjectManagementSkillsScore * 
                            job.ProjectManagementSkillsPriorityCoefficient;
                        rating += assessment.QualityCustomerServiceScore * 
                            job.QualityCustomerServicePriorityCoefficient;
                        assessment.Rating = rating;
                    }
                }
                // Кінець доданого мною.
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", assessment.EmployeeId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName", assessment.EmployeeId);
            return View(assessment);
        }

        // GET: Assessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", assessment.EmployeeId);
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName LastName", assessment.EmployeeId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName", assessment.EmployeeId);
            return View(assessment);
        }

        // POST: Assessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,AssessmentDate,TechnicalKnowledgeScore,AbilityToApplyTechnicalKnowledgeScore,ProjectManagementSkillsScore,QualityCustomerServiceScore,Rating")] Assessment assessment)
        {
            if (id != assessment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Початок доданого мною.
                Employee? employee = await _context.Employees.Where(e => e.Id == assessment.EmployeeId)
                    .SingleOrDefaultAsync();
                if (employee != null)
                {
                    Job? job = await _context.Jobs.Where(j => j.Id == employee.JobId)
                        .SingleOrDefaultAsync();
                    if (job != null)
                    {
                        double rating = 0;
                        rating += assessment.TechnicalKnowledgeScore * 
                            job.TechnicalKnowledgePriorityCoefficient;
                        rating += assessment.AbilityToApplyTechnicalKnowledgeScore * 
                            job.AbilityToApplyTechnicalKnowledgePriorityCoefficient;
                        rating += assessment.ProjectManagementSkillsScore * 
                            job.ProjectManagementSkillsPriorityCoefficient;
                        rating += assessment.QualityCustomerServiceScore * 
                            job.QualityCustomerServicePriorityCoefficient;
                        assessment.Rating = rating;
                    }
                }
                // Кінець доданого мною.
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.Id))
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
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", assessment.EmployeeId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "LastName", assessment.EmployeeId);
            return View(assessment);
        }

        // GET: Assessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assessments == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessments
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // POST: Assessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assessments == null)
            {
                return Problem("Entity set 'WorkQualityDbContext.Assessments'  is null.");
            }
            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessments.Remove(assessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentExists(int id)
        {
          return (_context.Assessments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
