using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ManagementApp.Web.ViewModel.Employee
{
    public class EmployeeDetailsViewModel
    {
        public EmployeeDetailsViewModel(IEnumerable<QualificationViewModel> qualifications)
        {
            Qualifications = new SelectList(qualifications, "Id","Name");
        }
        public EmployeeViewModel Employee { get; set; }
        public SelectList Qualifications { get; set; }
    }
}
