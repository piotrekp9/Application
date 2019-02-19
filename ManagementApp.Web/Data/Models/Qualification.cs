using ManagementApp.Web.Data.Enums;
using System.Collections.Generic;

namespace ManagementApp.Web.Data.Models
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public QualificationType QualificationType { get; set; }

        public ICollection<EmployeesQualifications> EmployeesQualifications { get; set; }
    }
}
