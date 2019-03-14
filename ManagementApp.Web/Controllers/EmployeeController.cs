using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using ManagementApp.Web.ViewModel.Employee;
using ManagementApp.Web.ViewModel.Protocol;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        private readonly IQualificationService qualificationService;

        public EmployeeController(IEmployeeService employeeService, IQualificationService qualificationService)
        {
            this.employeeService = employeeService;
            this.qualificationService = qualificationService;
        }

        [HttpGet]
        public IActionResult Index(string filter)
        {
            var employees = EmployeeMapper.MapManyToViewModel(employeeService.GetEmployees()).ToList();
            if(string.IsNullOrEmpty(filter)) return View(employees);
            
            return View(
                employees.Where(employee =>
                employee.FirstName.ToLower().Contains(filter.ToLower()) ||
                employee.LastName.ToLower().Contains(filter.ToLower())).ToList());
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid) return View(employee);
            try
            {
                employeeService.AddEmployee(EmployeeMapper.MapToDomainModel(employee));

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id < 1) return NotFound();
            try
            {
                var employee = (employeeService.GetEmployeeById(id));

                var protocols = new List<ProtocolViewModel>();
                if (employee.Protocols != null && employee.Protocols.Any())
                    protocols = ProtocolMapper.MapManyToViewModel(employee.Protocols).ToList();

                var orders = new List<OrderViewModel>();
                if(employee.Orders != null && employee.Orders.Any())
                    orders = OrderMapper.MapManyToViewModel(employee.Orders).ToList();
                
                var mappedEmployee = EmployeeMapper.MapToViewModel(employee, employee.EmployeesQualifications, protocols, orders);

                var result = new EmployeeDetailsViewModel(QualificationMapper.MapManyToViewModel(qualificationService.GetQualifications()).ToList())
                {
                    Employee = mappedEmployee,
                };

                return View(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPost]
        public IActionResult Update(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid) return View(employee);
            try
            {
                employeeService.UpdateEmployee(EmployeeMapper.MapToDomainModel(employee));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id < 1) return BadRequest();
            try
            {
                employeeService.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
