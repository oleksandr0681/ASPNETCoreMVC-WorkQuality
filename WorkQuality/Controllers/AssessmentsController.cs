using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "ManagementSpecialist, Administrator")]
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            return View();
        }

        // POST: Assessments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagementSpecialist, Administrator")]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,AssessDate,TechnicalKnowledgeScore,AbilityToApplyTechnicalKnowledgeScore,NumberAndSeverityOfErrorsScore,CreativityOfSolutionsScore,ComplianceOfWorkWithRequirementsScore,ProductivityScore,TeamworkScore,ProjectManagementSkillsScore,TrainingAndDevelopmentScore,ContributionToOverallGoalsScore,QualityCustomerServiceScore,Rating")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                Employee? employee = await _context.Employees
                    .Where(e => e.Id == assessment.EmployeeId)
                    .SingleOrDefaultAsync();
                if (employee != null)
                {
                    Job? job = await _context.Jobs
                        .Where(j => j.Id == employee.JobId)
                        .SingleOrDefaultAsync();
                    if (job != null)
                    {
                        double? rating = 0;
                        if (assessment.TechnicalKnowledgeScore != null)
                        {
                            rating += assessment.TechnicalKnowledgeScore * 
                                job.TechnicalKnowledgePriorityCoefficient;
                        }
                        if (assessment.AbilityToApplyTechnicalKnowledgeScore != null)
                        {
                            rating += assessment.AbilityToApplyTechnicalKnowledgeScore * 
                                job.AbilityToApplyTechnicalKnowledgePriorityCoefficient;
                        }
                        if (assessment.NumberAndSeverityOfErrorsScore != null)
                        {
                            rating += assessment.NumberAndSeverityOfErrorsScore * 
                                job.NumberAndSeverityOfErrorsPriorityCoefficient;
                        }
                        if (assessment.CreativityOfSolutionsScore != null)
                        {
                            rating += assessment.CreativityOfSolutionsScore + 
                                job.CreativityOfSolutionsPriorityCoefficient;
                        }
                        if (assessment.ComplianceOfWorkWithRequirementsScore != null)
                        {
                            rating += assessment.ComplianceOfWorkWithRequirementsScore * 
                                job.ComplianceOfWorkWithRequirementsPriorityCoefficient;
                        }
                        if (assessment.ProductivityScore != null)
                        {
                            rating += assessment.ProductivityScore * 
                                job.ProductivityPriorityCoefficient;
                        }
                        if (assessment.TeamworkScore != null)
                        {
                            rating += assessment.TeamworkScore * 
                                job.TeamworkPriorityCoefficient;
                        }
                        if (assessment.ProjectManagementSkillsScore != null)
                        {
                            rating += assessment.ProjectManagementSkillsScore * 
                                job.ProjectManagementSkillsPriorityCoefficient;
                        }
                        if (assessment.TrainingAndDevelopmentScore != null)
                        {
                            rating += assessment.TrainingAndDevelopmentScore * 
                                job.TrainingAndDevelopmentPriorityCoefficient;
                        }
                        if (assessment.ContributionToOverallGoalsScore != null)
                        {
                            rating += assessment.ContributionToOverallGoalsScore * 
                                job.ContributionToOverallGoalsPriorityCoefficient;
                        }
                        if (assessment.QualityCustomerServiceScore != null)
                        {
                            rating += assessment.QualityCustomerServiceScore * 
                                job.QualityCustomerServicePriorityCoefficient;
                        }
                        assessment.Rating = rating;
                    }
                }
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", assessment.EmployeeId);
            return View(assessment);
        }

        // GET: Assessments/Edit/5
        [Authorize(Roles = "ManagementSpecialist, Administrator")]
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", assessment.EmployeeId);
            return View(assessment);
        }

        // POST: Assessments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ManagementSpecialist, Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,AssessDate,TechnicalKnowledgeScore,AbilityToApplyTechnicalKnowledgeScore,NumberAndSeverityOfErrorsScore,CreativityOfSolutionsScore,ComplianceOfWorkWithRequirementsScore,ProductivityScore,TeamworkScore,ProjectManagementSkillsScore,TrainingAndDevelopmentScore,ContributionToOverallGoalsScore,QualityCustomerServiceScore,Rating")] Assessment assessment)
        {
            if (id != assessment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Employee? employee = await _context.Employees
                    .Where(e => e.Id == assessment.EmployeeId)
                    .SingleOrDefaultAsync();
                if (employee != null)
                {
                    Job? job = await _context.Jobs
                        .Where(j => j.Id == employee.JobId)
                        .SingleOrDefaultAsync();
                    if (job != null)
                    {
                        double? rating = 0;
                        if (assessment.TechnicalKnowledgeScore != null)
                        {
                            rating += assessment.TechnicalKnowledgeScore *
                                job.TechnicalKnowledgePriorityCoefficient;
                        }
                        if (assessment.AbilityToApplyTechnicalKnowledgeScore != null)
                        {
                            rating += assessment.AbilityToApplyTechnicalKnowledgeScore *
                                job.AbilityToApplyTechnicalKnowledgePriorityCoefficient;
                        }
                        if (assessment.NumberAndSeverityOfErrorsScore != null)
                        {
                            rating += assessment.NumberAndSeverityOfErrorsScore *
                                job.NumberAndSeverityOfErrorsPriorityCoefficient;
                        }
                        if (assessment.CreativityOfSolutionsScore != null)
                        {
                            rating += assessment.CreativityOfSolutionsScore +
                                job.CreativityOfSolutionsPriorityCoefficient;
                        }
                        if (assessment.ComplianceOfWorkWithRequirementsScore != null)
                        {
                            rating += assessment.ComplianceOfWorkWithRequirementsScore *
                                job.ComplianceOfWorkWithRequirementsPriorityCoefficient;
                        }
                        if (assessment.ProductivityScore != null)
                        {
                            rating += assessment.ProductivityScore *
                                job.ProductivityPriorityCoefficient;
                        }
                        if (assessment.TeamworkScore != null)
                        {
                            rating += assessment.TeamworkScore *
                                job.TeamworkPriorityCoefficient;
                        }
                        if (assessment.ProjectManagementSkillsScore != null)
                        {
                            rating += assessment.ProjectManagementSkillsScore *
                                job.ProjectManagementSkillsPriorityCoefficient;
                        }
                        if (assessment.TrainingAndDevelopmentScore != null)
                        {
                            rating += assessment.TrainingAndDevelopmentScore *
                                job.TrainingAndDevelopmentPriorityCoefficient;
                        }
                        if (assessment.ContributionToOverallGoalsScore != null)
                        {
                            rating += assessment.ContributionToOverallGoalsScore *
                                job.ContributionToOverallGoalsPriorityCoefficient;
                        }
                        if (assessment.QualityCustomerServiceScore != null)
                        {
                            rating += assessment.QualityCustomerServiceScore *
                                job.QualityCustomerServicePriorityCoefficient;
                        }
                        assessment.Rating = rating;
                    }
                }
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", assessment.EmployeeId);
            return View(assessment);
        }

        // GET: Assessments/Delete/5
        [Authorize(Roles = "ManagementSpecialist, Administrator")]
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
        [Authorize(Roles = "ManagementSpecialist, Administrator")]
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
