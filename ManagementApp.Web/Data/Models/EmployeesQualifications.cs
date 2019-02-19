namespace ManagementApp.Web.Data.Models
{
    public class EmployeesQualifications
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }
    }
}
