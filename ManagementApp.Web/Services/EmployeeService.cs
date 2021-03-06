﻿using ManagementApp.Web.Data;
using ManagementApp.Web.Data.Models;
using ManagementApp.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApp.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly ApplicationDbContext context;

        public EmployeeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees
                //.Include(employee => employee.EmployeesQualifications)
                //    .ThenInclude(eq => eq.Qualification)
                //.Include(employee => employee.Orders)
                //.Include(employee => employee.Protocols)
                .ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return context.Employees
                .Include(emplo => emplo.EmployeesQualifications)
                    .ThenInclude(eq => eq.Qualification)
                .Include(em => em.Orders)
                .FirstOrDefault(employee => employee.Id == employeeId);
        }

        public void DeleteEmployee(int employeeId)
        {
            var employeeToRemove = context.Employees.Find(employeeId);

            if (employeeToRemove == null) throw new ArgumentException($"There is no employee of that Id{employeeId}, to delete");

            context.Employees.Remove(employeeToRemove);
            context.SaveChanges();
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null) throw new ArgumentException("The employee object is empty!");

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var employeeToUpdate = context.Employees.Find(employee.Id);

            if (employeeToUpdate == null) throw new ArgumentException($"Cannot find employee of ID:{employee.Id}, that could be found");

            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.IsOccupied = employee.IsOccupied;
            employeeToUpdate.City = employee.City;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;
            employeeToUpdate.PostalCode = employee.PostalCode;
            employeeToUpdate.Street = employee.Street;

            context.SaveChanges();
        }
    }
}
