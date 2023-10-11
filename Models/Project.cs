using System.ComponentModel.DataAnnotations.Schema;

namespace CPMS.Models
{
    public class Project
    {
        public int ProjectId { get; init; }
        public String? Name { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public int ProjectManagerId { get; init; }

        public string? ProjectManagerName { get; init; }

        public string? ProjectManagerEmail { get; init; }

        public ICollection<Employee>? Employees { get; init; }
    }
}
