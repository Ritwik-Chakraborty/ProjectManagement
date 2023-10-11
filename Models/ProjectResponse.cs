namespace CPMS.Models
{
    public class ProjectResponse
    {
       
        public int Id { get; set; }
        public int ProjectId { get; set; }

        public Project? Project { get; set; }
        public string? ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public string? ProjectManagerName { get; set; }
        public string? ProjectManagerEmail { get; set; }

        public int Emp_id { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
