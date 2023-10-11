using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CPMS.Data;
using CPMS.Models;

namespace CPMS.Controllers
{
    public class ProjectResponsesController : Controller
    {
        private readonly CPMSContext _context;

        public ProjectResponsesController(CPMSContext context)
        {
            _context = context;
        }

        // GET: ProjectResponses
        public async Task<IActionResult> Index()
        {
            var cPMSContext = _context.ProjectResponse.Include(p => p.Project);
            return View(await cPMSContext.ToListAsync());
        }

        // GET: ProjectResponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectResponse == null)
            {
                return NotFound();
            }

            var projectResponse = await _context.ProjectResponse
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectResponse == null)
            {
                return NotFound();
            }

            return View(projectResponse);
        }

        // GET: ProjectResponses/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            return View();
        }

        // POST: ProjectResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,ProjectName,ProjectStartDate,ProjectEndDate,ProjectManagerName,ProjectManagerEmail,Emp_id")] ProjectResponse projectResponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectResponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", projectResponse.ProjectId);
            return View(projectResponse);
        }

        // GET: ProjectResponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectResponse == null)
            {
                return NotFound();
            }

            var projectResponse = await _context.ProjectResponse.FindAsync(id);
            if (projectResponse == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", projectResponse.ProjectId);
            return View(projectResponse);
        }

        // POST: ProjectResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,ProjectName,ProjectStartDate,ProjectEndDate,ProjectManagerName,ProjectManagerEmail,Emp_id")] ProjectResponse projectResponse)
        {
            if (id != projectResponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectResponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectResponseExists(projectResponse.Id))
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
            ViewData["ProjectId"] = new SelectList(_context.Project, "ProjectId", "ProjectId", projectResponse.ProjectId);
            return View(projectResponse);
        }

        // GET: ProjectResponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectResponse == null)
            {
                return NotFound();
            }

            var projectResponse = await _context.ProjectResponse
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectResponse == null)
            {
                return NotFound();
            }

            return View(projectResponse);
        }

        // POST: ProjectResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectResponse == null)
            {
                return Problem("Entity set 'CPMSContext.ProjectResponse'  is null.");
            }
            var projectResponse = await _context.ProjectResponse.FindAsync(id);
            if (projectResponse != null)
            {
                _context.ProjectResponse.Remove(projectResponse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectResponseExists(int id)
        {
          return (_context.ProjectResponse?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
