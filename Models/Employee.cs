namespace CPMS.Models
{
    public class Employee
    {
        public int EmployeeId { get; init; }
        public string? Name { get; init; }
        public string? Email { get; init; }
        public DateTime DateOfJoining { get; init; }
        public int DepartmentId { get; init; }
        public Department? Department { get; init; }
        public string? DepartmentName { get; init; }
        public ICollection<Project>? Projects { get; init;}
    }
}
