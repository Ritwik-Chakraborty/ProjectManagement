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
        [NotMapped]
        public ICollection<int>? EmployeeIds { get; init; }
    }
}
