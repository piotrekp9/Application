using System;
using System.Collections.Generic;
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
                //Address = employee.Address,
                //ContactInfo = employee.ContactInfo,
            };
        }

        public static IEnumerable<EmployeeViewModel> MapToViewModel(IEnumerable<Employee> employees)
        {
            var result = new List<EmployeeViewModel>();

            foreach (Employee employee in employees)
            {
                result.Add(MapToViewModel(employee));
            }

            return result;
        }

        public static Employee MapToDomainModel(EmployeeViewModel employeeViewModel)
        {
            return new Employee()
            {
                FirstName = employeeViewModel.FirstName,
                LastName = employeeViewModel.LastName,
                //Address = employeeViewModel.Address,
                //ContactInfo = employeeViewModel.ContactInfo,
            };
        }
    }
}
