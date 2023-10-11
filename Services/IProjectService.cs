using CPMS.Models;

namespace CPMS.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectResponse>> GetProjectsAsync(int page, int pageSize);
    }
}
