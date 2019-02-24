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
                City = employee.City,
                Email = employee.Email,
                IsOccupied = employee.IsOccupied,
                PhoneNumber = employee.PhoneNumber,
                PostalCode = employee.PostalCode,
                Street = employee.Street,
            };
        }

        public static IEnumerable<EmployeeViewModel> MapManyToViewModel(IEnumerable<Employee> employees)
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
                City = employeeViewModel.City,
                Email = employeeViewModel.Email,
                IsOccupied = employeeViewModel.IsOccupied,
                PhoneNumber = employeeViewModel.PhoneNumber,
                PostalCode = employeeViewModel.PostalCode,
                Street = employeeViewModel.Street,
            };
        }
    }
}
