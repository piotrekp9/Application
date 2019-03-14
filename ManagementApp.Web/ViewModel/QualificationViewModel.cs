using ManagementApp.Web.Data.Enums;
using ManagementApp.Web.ViewModel.Employee;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel
{
    public class QualificationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public QualificationType QualificationType { get; set; }

        public IEnumerable<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
    }
}
