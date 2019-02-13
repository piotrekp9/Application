using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;

namespace ManagementApp.Web.Mappers
{
    public class EmployeeMapper
    {
        public static EmployeeViewModel MapToViewModel(Employee employee)
        {
            return new EmployeeViewModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Address = employee.Address,
                ContactInfo = employee.ContactInfo,
                EmployeeType = employee.EmployeeType
            };
        }

        public static Employee MapToDomainModel(EmployeeViewModel employeeViewModel)
        {
            return new Employee()
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                Address = employeeViewModel.Address,
                ContactInfo = employeeViewModel.ContactInfo,
                EmployeeType = employeeViewModel.EmployeeType
            };
        }
    }
}
