using ManagementApp.Web.Data.Models;
using System.Collections.Generic;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int employeeId);
        void DeleteEmployee(int employeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
