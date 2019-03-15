using System.Collections.Generic;
using System.Linq;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.ViewModel;
using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Order;
using ManagementApp.Web.ViewModel.Protocol;

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

        public static EmployeeViewModel MapToViewModel(Employee employee, IEnumerable<EmployeesQualifications> employeesQualifications, IEnumerable<ProtocolViewModel> protocols, IEnumerable<OrderViewModel> orders)
        {
            var employeeQualifications = new List<QualificationViewModel>();

            if (employeesQualifications != null && employeesQualifications.Any())
            {

                foreach (var item in employeesQualifications)
                {
                    employeeQualifications.Add(QualificationMapper.MapToViewModel(item.Qualification));
                }
            }

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
                Orders = orders,
                Protocols = protocols,
                Qualifictaions= employeeQualifications
            };
        }
    }
}
