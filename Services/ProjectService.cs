using CPMS.Data;
using CPMS.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CPMS.Services;
public class ProjectService : IProjectService
{
    private readonly CPMSContext _dbContext;

    public ProjectService(CPMSContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProjectResponse>> GetProjectsAsync(int page, int pageSize)
    {
        var projectResponses = await _dbContext.Project
            .Skip((page - 1) * pageSize)
            .Include(p => p.Employees)
            .Take(pageSize)
            .Select(p => new ProjectResponse
            {
                ProjectId = p.ProjectId,
                ProjectName = p.Name,
                ProjectStartDate = p.StartDate,
                ProjectEndDate = p.EndDate,
                ProjectManagerName = p.ProjectManagerName,
                ProjectManagerEmail = p.ProjectManagerEmail,
                Employees = p.Employees.Select(e => new Employee
                {
                    Name = e.Name,
                    Email = e.Email,
                    DateOfJoining = e.DateOfJoining,
                    DepartmentName = e.DepartmentName
                }).ToList()
            })
            .ToListAsync();



        return projectResponses;
    }
}
