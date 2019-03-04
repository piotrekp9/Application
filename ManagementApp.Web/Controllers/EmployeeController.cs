using ManagementApp.Web.Mappers;
using ManagementApp.Web.Models;
using ManagementApp.Web.Services.Interfaces;
using ManagementApp.Web.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace ManagementApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService) => this.employeeService = employeeService;

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
                var employee = EmployeeMapper.MapToViewModel(employeeService.GetEmployeeById(id));

                return View(employee);
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
