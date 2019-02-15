using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApp.Web.Services.Interfaces
{
    public interface IInvoiceService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int employeeId);
        void DeleteEmployee(int employeeId);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
