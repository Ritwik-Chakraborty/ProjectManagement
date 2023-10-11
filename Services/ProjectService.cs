using CPMS.Data;
using CPMS.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

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
        var projectResponses = await _dbContext.ProjectResponse
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(p => new ProjectResponse
            {
                ProjectId = p.ProjectId,
                ProjectName = p.ProjectName,
                ProjectStartDate = p.ProjectStartDate,
                ProjectEndDate = p.ProjectEndDate,
                ProjectManagerName = p.ProjectManagerName,
                ProjectManagerEmail = p.ProjectManagerEmail,
                Emp_id= p.Emp_id,
                Employees = p.Employees.Select(e=> new Employee
                {
                    Name = "hello",
                    Email = "hello@1.com",
                    DateOfJoining = e.DateOfJoining,
                    DepartmentName = "Test"
                }).ToList()
            })
            .ToListAsync();



        return projectResponses;
    }
}
