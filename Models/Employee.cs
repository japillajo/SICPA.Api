namespace SICPA.Api.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }  
        public string ModifiedBy { get; set; }

        public List<DepartmentEmployee> DepartmentEmployees { get; set; }
    }
}
