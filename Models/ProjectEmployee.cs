namespace CPMS.Models
{
    public class ProjectEmployee
    {
        public int Project_Id { get; set; }
        public Project? Project { get; set; }
        public int Emp_Id { get; set; }
        public Employee? Employee { get; set; }
    }
}
