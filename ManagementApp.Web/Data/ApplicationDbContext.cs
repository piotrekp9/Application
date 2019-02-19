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
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<EmployeesQualifications> EmployeesQualifications { get; set; }
        //public DbSet<EmployeesOrders> EmployeesOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<EmployeesOrders>().HasKey(eo => new { eo.EmployeeId, eo.OrderId });
            //builder.Entity<EmployeesOrders>().HasOne(eo => eo.Employee).WithMany(employee => employee.EmployeesOrders).HasForeignKey(eo => eo.EmployeeId);
            //builder.Entity<EmployeesOrders>().HasOne(eo => eo.Order).WithMany(order => order.EmployeesOrders).HasForeignKey(eo => eo.OrderId);
            builder.Entity<Order>().HasOne(order => order.Protocol).WithOne(protocol => protocol.Order).HasForeignKey<Protocol>(p => p.OrderId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Invoice>().HasOne(invoice => invoice.Order).WithOne(order => order.Invoice).HasForeignKey<Order>(i => i.InvoiceId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Client>().HasMany(client => client.Invoices).WithOne(invoice => invoice.Client).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Client>().HasMany(client => client.Orders).WithOne(order => order.Client).OnDelete(DeleteBehavior.SetNull);
        
            builder.Entity<Employee>().HasMany(employee => employee.Orders).WithOne(order => order.Employee).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Employee>().HasMany(employee => employee.Protocols).WithOne(protocol => protocol.Employee).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<EmployeesQualifications>().HasKey(eq => new { eq.EmployeeId, eq.QualificationId });
            builder.Entity<EmployeesQualifications>().HasOne(eq => eq.Employee).WithMany(employee => employee.EmployeesQualifications).HasForeignKey(eo => eo.EmployeeId);
            builder.Entity<EmployeesQualifications>().HasOne(eq => eq.Qualification).WithMany(qualification => qualification.EmployeesQualifications).HasForeignKey(eo => eo.QualificationId);

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
                    //Address = new Address(){City="Warszawa", PostalCode="00-000", Street="W dupie"},
                    //ContactInfo = new ContactInfo(){Email ="adnrzej69@gmail.com", PhoneNumber="0700123456"},
                    IsOccupied = false
                }
            };

            builder.Entity<Employee>().HasData(employeesList);
        }
    }
}
