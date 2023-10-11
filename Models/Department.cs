namespace CPMS.Models
{
    public class Department
    {
        public int DepartmentId { get; init; }
        public string? Name { get; init; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
