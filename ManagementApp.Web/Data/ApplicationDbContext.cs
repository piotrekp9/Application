using ManagementApp.Web.Data.Enums;
using ManagementApp.Web.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ManagementApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeesOrders> EmployeesOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeesOrders>().HasKey(eo => new { eo.EmployeeId, eo.OrderId });
            builder.Entity<EmployeesOrders>().HasOne(eo => eo.Employee).WithMany(employee => employee.EmployeesOrders).HasForeignKey(eo => eo.EmployeeId);
            builder.Entity<EmployeesOrders>().HasOne(eo => eo.Order).WithMany(order => order.EmployeesOrders).HasForeignKey(eo => eo.OrderId);



            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            var employeesList = new Employee[]
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "Andrzej",
                    LastName = "Duda",
                    Address = new Address(){City="Warszawa", PostalCode="00-000", Street="W dupie"},
                    ContactInfo = new ContactInfo(){Email ="adnrzej69@gmail.com", PhoneNumber="0700123456"},
                    EmployeeType = EmployeeType.Electrician,
                    IsOccupied = false
                }
            };

            builder.Entity<Employee>().HasData(employeesList);
        }
    }
}
