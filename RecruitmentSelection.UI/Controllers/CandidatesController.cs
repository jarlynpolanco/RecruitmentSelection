using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitmentSelection.UI.Models;
using RecruitmentSelection.UI.Models.Context;
using RecruitmentSelection.UI.Utilities;

namespace RecruitmentSelection.UI.Controllers
{

    public class CandidatesController : Controller
    {
        private readonly RecruitmentDbContext _context;

        public CandidatesController(RecruitmentDbContext context)
        {
            _context = context;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var recruitmentDbContext = _context.Candidates
                .Include(c => c.JobPosition)
                .Where(c => !_context.Employees.Any(e => e.DocumentNumber == c.DocumentNumber));

            return View(await recruitmentDbContext.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .Include(c => c.JobPosition)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name");
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentNumber,Name,JobPositionID,Department,SalaryWished,Languages,RecommendedBy,ID")] Candidate candidate)
        {
            if (!Validations.ValidateDocumentNumber(candidate.DocumentNumber)) 
            {
                ViewBag.Error = "El documento indicado es invalido!";
                ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", candidate.JobPositionID);
                return View(candidate);
            }
            if (_context.Candidates.Any(x => x.DocumentNumber == candidate.DocumentNumber)) 
            {
                ViewBag.Error = "Este candidato ya se encuentra registrado!";
                ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", candidate.JobPositionID);
                return View(candidate);
            }
            if (_context.Employees.Any(x => x.DocumentNumber == candidate.DocumentNumber && x.Status)) 
            {
                ViewBag.Error = "Este candidato ya existe como empleado!";
                ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", candidate.JobPositionID);
                return View(candidate);
            }
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", candidate.JobPositionID);
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", candidate.JobPositionID);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentNumber,Name,JobPositionID,Department,SalaryWished,Languages,RecommendedBy,ID")] Candidate candidate)
        {
            if (id != candidate.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.ID))
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
            ViewData["JobPositionID"] = new SelectList(_context.JobPositions, "ID", "Name", candidate.JobPositionID);
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidates
                .Include(c => c.JobPosition)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidates.Any(e => e.ID == id);
        }

        // GET: Candidates/{id}/Proficiencies
        [HttpGet("[controller]/{id}/Proficiencies")]
        public async Task<IActionResult> Proficiencies(int id)
        {
            var recruitmentDbContext = _context.Proficiencies.Where(p => p.CandidateID == id);

            ViewData["CandidateID"] = id;

            return View(await recruitmentDbContext.ToListAsync());
        }

        // GET: Candidates/{id}/Proficiencies/Create
        [HttpGet("[controller]/{id}/Proficiencies/Create")]
        public IActionResult ProficienciesCreate(int id)
        {
            var proficiency = new Proficiency
            {
                CandidateID = id
            };

            return View(nameof(ProficienciesCreate), proficiency);
        }

        // POST: Candidates/{id}/Proficiencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("[controller]/{id}/Proficiencies/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProficienciesCreate(int id, [Bind("Description,Status,CandidateID")] Proficiency proficiency)
        {
            proficiency.CandidateID = id;
            
            if (ModelState.IsValid)
            {
                _context.Add(proficiency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Proficiencies), new { id });
            }

            return View(nameof(ProficienciesCreate), proficiency);
        }

        // GET: Candidates/{id}/Proficiencies/5/Delete
        [HttpGet("[controller]/{candidateId}/Proficiencies/{proficiencyId}/Delete")]
        public async Task<IActionResult> ProficienciesDelete(int candidateId, int proficiencyId)
        {
            var proficiency = await _context.Proficiencies
                .FirstOrDefaultAsync(m => m.ID == proficiencyId && m.CandidateID == candidateId);

            if (proficiency == null)
            {
                return NotFound();
            }

            return View(proficiency);
        }

        // POST: Candidates/{id}/Proficiencies/5/Delete
        [HttpPost("[controller]/{candidateId}/Proficiencies/{proficiencyId}/Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProficienciesDeleteConfirmed(int candidateId, int proficiencyId)
        {
            var proficiency = await _context.Proficiencies
                .FirstOrDefaultAsync(m => m.ID == proficiencyId && m.CandidateID == candidateId);
            _context.Proficiencies.Remove(proficiency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Proficiencies), new { id = candidateId });
        }

        [HttpGet("[controller]/{id}/Trainings")]
        public async Task<IActionResult> Trainings(int id)
        {
            var recruitmentDbContext = _context.Trainings.Where(p => p.CandidateID == id);

            ViewData["CandidateID"] = id;

            return View(await recruitmentDbContext.ToListAsync());
        }

        [HttpGet("[controller]/{id}/Trainings/Create")]
        public IActionResult TrainingsCreate(int id)
        {
            var trainings = new Training
            {
                CandidateID = id
            };

            return View(nameof(TrainingsCreate), trainings);
        }

        [HttpPost("[controller]/{id}/Trainings/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrainingsCreate(int id, [Bind("Description,Level,InitialDate,EndDate,Institution,CandidateID")] Training training)
        {
            training.CandidateID = id;

            if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Trainings), new { id });
            }

            return View(nameof(TrainingsCreate), training);
        }

        [HttpGet("[controller]/{candidateId}/Trainings/{trainingId}/Delete")]
        public async Task<IActionResult> TrainingsDelete(int candidateId, int trainingId)
        {
            var training = await _context.Trainings
                .FirstOrDefaultAsync(m => m.ID == trainingId && m.CandidateID == candidateId);

            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        [HttpPost("[controller]/{candidateId}/Trainings/{trainingId}/Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TrainingsDeleteConfirmed(int candidateId, int trainingId)
        {
            var training = await _context.Trainings
                .FirstOrDefaultAsync(m => m.ID == trainingId && m.CandidateID == candidateId);
            _context.Trainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Trainings), new { id = candidateId });
        }

        //JobExperiences
        [HttpGet("[controller]/{id}/JobExperiences")]
        public async Task<IActionResult> JobExperiences(int id)
        {
            var recruitmentDbContext = _context.JobExperiences.Where(p => p.CandidateID == id);

            ViewData["CandidateID"] = id;

            return View(await recruitmentDbContext.ToListAsync());
        }

        [HttpGet("[controller]/{id}/JobExperiences/Create")]
        public IActionResult JobExperiencesCreate(int id)
        {
            var jobExperience = new JobExperience
            {
                CandidateID = id
            };

            return View(nameof(JobExperiencesCreate), jobExperience);
        }

        [HttpPost("[controller]/{id}/JobExperiences/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JobExperiencesCreate(int id, [Bind("Bussiness,JobPosition,InitialDate,EndDate,Salary,CandidateID")] JobExperience jobExperience)
        {
            jobExperience.CandidateID = id;

            if (ModelState.IsValid)
            {
                _context.Add(jobExperience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(JobExperiences), new { id });
            }

            return View(nameof(JobExperiencesCreate), jobExperience);
        }

        [HttpGet("[controller]/{candidateId}/JobExperiences/{jobExperienceId}/Delete")]
        public async Task<IActionResult> JobExperiencesDelete(int candidateId, int jobExperienceId)
        {
            var jobExperience = await _context.JobExperiences
                .FirstOrDefaultAsync(m => m.ID == jobExperienceId && m.CandidateID == candidateId);

            if (jobExperience == null)
            {
                return NotFound();
            }

            return View(jobExperience);
        }

        [HttpPost("[controller]/{candidateId}/JobExperiences/{jobExperienceId}/Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JobExperiencesDeleteConfirmed(int candidateId, int jobExperienceId)
        {
            var jobExperience = await _context.JobExperiences
                .FirstOrDefaultAsync(m => m.ID == jobExperienceId && m.CandidateID == candidateId);
            _context.JobExperiences.Remove(jobExperience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(JobExperiences), new { id = candidateId });
        }

        //Languages
        [HttpGet("[controller]/{id}/Languages")]
        public async Task<IActionResult> Languages(int id)
        {
            var recruitmentDbContext = _context.Languages.Where(p => p.CandidateID == id);

            ViewData["CandidateID"] = id;

            return View(await recruitmentDbContext.ToListAsync());
        }

        [HttpGet("[controller]/{id}/Languages/Create")]
        public IActionResult LanguagesCreate(int id)
        {
            var languages = new Languages
            {
                CandidateID = id
            };

            return View(nameof(LanguagesCreate), languages);
        }

        [HttpPost("[controller]/{id}/Languages/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LanguagesCreate(int id, [Bind("Name,State,CandidateID")] Languages languages)
        {
            languages.CandidateID = id;

            if (ModelState.IsValid)
            {
                _context.Add(languages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Languages), new { id });
            }

            return View(nameof(LanguagesCreate), languages);
        }

        [HttpGet("[controller]/{candidateId}/Languages/{languageId}/Delete")]
        public async Task<IActionResult> LanguagesDelete(int candidateId, int languageId)
        {
            var languages = await _context.Languages
                .FirstOrDefaultAsync(m => m.ID == languageId && m.CandidateID == candidateId);

            if (languages == null)
            {
                return NotFound();
            }

            return View(languages);
        }

        [HttpPost("[controller]/{candidateId}/Languages/{languageId}/Delete"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LanguagesDeleteConfirmed(int candidateId, int languageId)
        {
            var language = await _context.Languages
                .FirstOrDefaultAsync(m => m.ID == languageId && m.CandidateID == candidateId);
            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Languages), new { id = candidateId });
        }
    }
}
