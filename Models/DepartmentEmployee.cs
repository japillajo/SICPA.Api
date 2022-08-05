namespace SICPA.Api.Models
{
    public class DepartmentEmployee
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
