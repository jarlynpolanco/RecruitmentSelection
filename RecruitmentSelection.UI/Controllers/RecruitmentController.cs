using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitmentSelection.UI.Models;
using RecruitmentSelection.UI.Models.Context;

namespace RecruitmentSelection.UI.Controllers
{
    public class RecruitmentController : Controller
    {
        private readonly RecruitmentDbContext _context;

        public RecruitmentController(RecruitmentDbContext context)
        {
            _context = context;
        }

        // GET: Recruitment
        public async Task<IActionResult> Index()
        {
            var recruitmentDbContext = _context.Candidates
                .Include(c => c.JobPosition)
                .Where(c => !_context.Employees.Any(e => e.DocumentNumber == c.DocumentNumber));

            return View(await recruitmentDbContext.ToListAsync());
        }

        // GET: Recruitment/Details/5
        public async Task<IActionResult> CandidateDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .Include(c => c.JobPosition)
                .Include(c => c.Proficiencies)
                .Include(c => c.Trainings)
                .Include(c => c.JobExperiences)
                .Include(c => c.LanguagesList)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Recruitment/Recruit/{id}
        [HttpGet("[controller]/recruit/{id}")]
        public IActionResult Recruit(int id)
        {
            var candidate = _context.Candidates.Find(id);

            if(candidate is null)
            {
                return NotFound();
            }

            var employee = new Employee
            {
                Name = candidate.Name,
                Salary = candidate.SalaryWished,
                DocumentNumber = candidate.DocumentNumber,
                JobPositionID = candidate.JobPositionID,
                Department = candidate.Department,
                InitialDate = DateTime.Now,
                Status = true
            };

            ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", employee.JobPositionID);

            return View(employee);
        }

        // POST: Recruitment/Recruit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("[controller]/recruit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentNumber,Name,InitialDate,Department,JobPositionID,Salary,Status")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", employee.JobPositionID);
            return View(employee);
        }

    }
}
