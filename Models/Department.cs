namespace SICPA.Api.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public int EnterpriseId { get; set; }
        public Enterprise Enterprise { get; set; }
        //public List<DepartmentEmployee> DepartmentEmployees { get; set; }

    }
}
