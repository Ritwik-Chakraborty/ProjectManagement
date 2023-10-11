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
    public class ProjectEmployeesController : Controller
    {
        private readonly CPMSContext _context;

        public ProjectEmployeesController(CPMSContext context)
        {
            _context = context;
        }

        // GET: ProjectEmployees
        public async Task<IActionResult> Index()
        {
            var cPMSContext = _context.ProjectEmployee.Include(p => p.Employee).Include(p => p.Project);
            return View(await cPMSContext.ToListAsync());
        }

        // GET: ProjectEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectEmployee == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployee
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Emp_Id == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Create
        public IActionResult Create()
        {
            ViewData["Emp_Id"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId");
            ViewData["Project_Id"] = new SelectList(_context.Project, "ProjectId", "ProjectId");
            return View();
        }

        // POST: ProjectEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Project_Id,Emp_Id")] ProjectEmployee projectEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Emp_Id"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", projectEmployee.Emp_Id);
            ViewData["Project_Id"] = new SelectList(_context.Project, "ProjectId", "ProjectId", projectEmployee.Project_Id);
            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectEmployee == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployee.FindAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }
            ViewData["Emp_Id"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", projectEmployee.Emp_Id);
            ViewData["Project_Id"] = new SelectList(_context.Project, "ProjectId", "ProjectId", projectEmployee.Project_Id);
            return View(projectEmployee);
        }

        // POST: ProjectEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Project_Id,Emp_Id")] ProjectEmployee projectEmployee)
        {
            if (id != projectEmployee.Emp_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectEmployeeExists(projectEmployee.Emp_Id))
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
            ViewData["Emp_Id"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeId", projectEmployee.Emp_Id);
            ViewData["Project_Id"] = new SelectList(_context.Project, "ProjectId", "ProjectId", projectEmployee.Project_Id);
            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectEmployee == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployee
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.Emp_Id == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // POST: ProjectEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectEmployee == null)
            {
                return Problem("Entity set 'CPMSContext.ProjectEmployee'  is null.");
            }
            var projectEmployee = await _context.ProjectEmployee.FindAsync(id);
            if (projectEmployee != null)
            {
                _context.ProjectEmployee.Remove(projectEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectEmployeeExists(int id)
        {
          return (_context.ProjectEmployee?.Any(e => e.Emp_Id == id)).GetValueOrDefault();
        }
    }
}
