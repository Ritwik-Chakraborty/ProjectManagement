using CPMS.Models;
using CPMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CPMS.Controllers
{
    [ApiController]
    [Route("api/projects")]
    [Authorize]
    public class ApiProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ApiProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetProjects(int page = 1, int pageSize = 10)
        {
            var projects = await _projectService.GetProjectsAsync(page, pageSize);
            return Ok(new
            {
                data = projects,
                page,
                pageSize,
                hasMore = projects.Any(),
                totalItems = projects.Count()
            });
        }
    }
}
