using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        ApplicationDbContext context;

        public EmployeeService(ApplicationDbContext context) => this.context = context;

        public IEnumerable<Employee> GetEmployees() => context.Employees.ToList();

        public Employee GetEmployeeById(int employeeId) => context.Employees.Find(employeeId);

        public void DeleteEmployee(int employeeId)
        {
            var employeeToRemove = context.Employees.Find(employeeId);
            context.Remove(employeeToRemove);
            context.SaveChanges();
        }

        public void AddEmployee(Employee employee) => context.Add(employee);

        public void UpdateEmployee(Employee employee) => context.Update(employee);
    }
}
