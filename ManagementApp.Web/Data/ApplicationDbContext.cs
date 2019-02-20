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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Order>().HasOne(order => order.Protocol).WithOne(protocol => protocol.Order).HasForeignKey<Protocol>(p => p.OrderId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Order>().Property(order => order.Title).HasMaxLength(50);
            builder.Entity<Order>().Property(order => order.Description).HasMaxLength(500);

            builder.Entity<Invoice>().HasOne(invoice => invoice.Order).WithOne(order => order.Invoice).HasForeignKey<Order>(i => i.InvoiceId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Invoice>().Property(invoice => invoice.InvoiceNumber).HasMaxLength(11);
            builder.Entity<Invoice>().Property(invoice => invoice.AccountNumber).HasMaxLength(26);
            builder.Entity<Invoice>().Property(invoice => invoice.PaymentWithoutTax).HasColumnType("decimal(8,2)");
            builder.Entity<Invoice>().Property(invoice => invoice.PaymentWithTax).HasColumnType("decimal(8,2)");
            builder.Entity<Invoice>().Property(invoice => invoice.TaxPayment).HasColumnType("decimal(8,2)");
            builder.Entity<Invoice>().Property(invoice => invoice.TaxPayment).HasColumnType("decimal(8,2)");

            builder.Entity<Client>().HasMany(client => client.Invoices).WithOne(invoice => invoice.Client).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Client>().HasMany(client => client.Orders).WithOne(order => order.Client).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Client>().Property(client => client.City).HasMaxLength(30);
            builder.Entity<Client>().Property(client => client.PostalCode).HasMaxLength(5);
            builder.Entity<Client>().Property(client => client.PESEL).HasMaxLength(11);
            builder.Entity<Client>().Property(client => client.REGON).HasMaxLength(14);
            builder.Entity<Client>().Property(client => client.NIP).HasMaxLength(10);
            builder.Entity<Client>().Property(client => client.Name).HasMaxLength(50);
            builder.Entity<Client>().Property(client => client.PhoneNumber).HasMaxLength(11);
            builder.Entity<Client>().Property(client => client.Street).HasMaxLength(30);
            builder.Entity<Client>().Property(client => client.Email).HasMaxLength(254);
        
            builder.Entity<Employee>().HasMany(employee => employee.Orders).WithOne(order => order.Employee).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Employee>().HasMany(employee => employee.Protocols).WithOne(protocol => protocol.Employee).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Employee>().Property(employee => employee.City).HasMaxLength(30);
            builder.Entity<Employee>().Property(employee => employee.Email).HasMaxLength(254);
            builder.Entity<Employee>().Property(employee => employee.FirstName).HasMaxLength(30);
            builder.Entity<Employee>().Property(employee => employee.LastName).HasMaxLength(30);
            builder.Entity<Employee>().Property(employee => employee.PhoneNumber).HasMaxLength(11);
            builder.Entity<Employee>().Property(employee => employee.PostalCode).HasMaxLength(5);
            builder.Entity<Employee>().Property(employee => employee.Street).HasMaxLength(30);

            builder.Entity<EmployeesQualifications>().HasKey(eq => new { eq.EmployeeId, eq.QualificationId });
            builder.Entity<EmployeesQualifications>().HasOne(eq => eq.Employee).WithMany(employee => employee.EmployeesQualifications).HasForeignKey(eo => eo.EmployeeId);
            builder.Entity<EmployeesQualifications>().HasOne(eq => eq.Qualification).WithMany(qualification => qualification.EmployeesQualifications).HasForeignKey(eo => eo.QualificationId);

            builder.Entity<Product>().Property(product => product.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(product => product.Name).HasMaxLength(50);
            builder.Entity<Product>().Property(product => product.Price).HasColumnType("decimal(8,2)");

            builder.Entity<Protocol>().Property(protocol => protocol.Name).HasMaxLength(30);
            builder.Entity<Protocol>().Property(protocol => protocol.Weather).HasMaxLength(30);
            builder.Entity<Protocol>().Property(protocol => protocol.Proclamation).HasMaxLength(500);
            builder.Entity<Protocol>().Property(protocol => protocol.Description).HasMaxLength(500);

            builder.Entity<Qualification>().Property(qualification => qualification.Description).HasMaxLength(500);
            builder.Entity<Qualification>().Property(qualification => qualification.Name).HasMaxLength(50);

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
