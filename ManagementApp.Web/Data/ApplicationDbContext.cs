using ManagementApp.Web.Data.Enums;
using ManagementApp.Web.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;

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
            builder.Entity<Order>().HasOne(order => order.Invoice).WithOne(invoice => invoice.Order).HasForeignKey<Invoice>(i => i.OrderId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Order>().Property(order => order.Title).HasMaxLength(50);
            builder.Entity<Order>().Property(order => order.Description).HasMaxLength(500);

            builder.Entity<Invoice>().HasOne(invoice => invoice.Order).WithOne(order => order.Invoice).HasForeignKey<Order>(o => o.InvoiceId).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
            builder.Entity<Invoice>().Property(invoice => invoice.InvoiceNumber).HasMaxLength(11);
            builder.Entity<Invoice>().Property(invoice => invoice.AccountNumber).HasMaxLength(26);
            builder.Entity<Invoice>().Property(invoice => invoice.Description).HasMaxLength(500);
            builder.Entity<Invoice>().Property(invoice => invoice.PaymentWithoutTax).HasColumnType("decimal(8,2)");
            builder.Entity<Invoice>().Property(invoice => invoice.PaymentWithTax).HasColumnType("decimal(8,2)");
            builder.Entity<Invoice>().Property(invoice => invoice.TaxPayment).HasColumnType("decimal(8,2)");
            builder.Entity<Invoice>().Property(invoice => invoice.TaxPayment).HasColumnType("decimal(8,2)");

            builder.Entity<Client>().HasMany(client => client.Invoices).WithOne(invoice => invoice.Client).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Client>().HasMany(client => client.Orders).WithOne(order => order.Client).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Client>().Property(client => client.City).HasMaxLength(50);
            builder.Entity<Client>().Property(client => client.PostalCode).HasMaxLength(6);
            builder.Entity<Client>().Property(client => client.PESEL).HasMaxLength(11);
            builder.Entity<Client>().Property(client => client.REGON).HasMaxLength(14);
            builder.Entity<Client>().Property(client => client.NIP).HasMaxLength(10);
            builder.Entity<Client>().Property(client => client.Name).HasMaxLength(50);
            builder.Entity<Client>().Property(client => client.PhoneNumber).HasMaxLength(14);
            builder.Entity<Client>().Property(client => client.Street).HasMaxLength(50);
            builder.Entity<Client>().Property(client => client.Email).HasMaxLength(254);
        
            builder.Entity<Employee>().HasMany(employee => employee.Orders).WithOne(order => order.Employee).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Employee>().HasMany(employee => employee.Protocols).WithOne(protocol => protocol.Employee).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<Employee>().Property(employee => employee.City).HasMaxLength(50);
            builder.Entity<Employee>().Property(employee => employee.Email).HasMaxLength(254);
            builder.Entity<Employee>().Property(employee => employee.FirstName).HasMaxLength(50);
            builder.Entity<Employee>().Property(employee => employee.LastName).HasMaxLength(50);
            builder.Entity<Employee>().Property(employee => employee.PhoneNumber).HasMaxLength(14);
            builder.Entity<Employee>().Property(employee => employee.PostalCode).HasMaxLength(6);
            builder.Entity<Employee>().Property(employee => employee.Street).HasMaxLength(50);

            builder.Entity<EmployeesQualifications>().HasKey(eq => new { eq.EmployeeId, eq.QualificationId });
            builder.Entity<EmployeesQualifications>().HasOne(eq => eq.Employee).WithMany(employee => employee.EmployeesQualifications).HasForeignKey(eo => eo.EmployeeId);
            builder.Entity<EmployeesQualifications>().HasOne(eq => eq.Qualification).WithMany(qualification => qualification.EmployeesQualifications).HasForeignKey(eo => eo.QualificationId);

            builder.Entity<Product>().Property(product => product.Description).HasMaxLength(500);
            builder.Entity<Product>().Property(product => product.Name).HasMaxLength(50);
            builder.Entity<Product>().Property(product => product.Price).HasColumnType("decimal(8,2)");
            builder.Entity<Product>().HasMany(product => product.Orders).WithOne(order => order.Product).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Protocol>().Property(protocol => protocol.Name).HasMaxLength(50);
            builder.Entity<Protocol>().Property(protocol => protocol.Weather).HasMaxLength(50);
            builder.Entity<Protocol>().Property(protocol => protocol.Proclamation).HasMaxLength(500);
            builder.Entity<Protocol>().Property(protocol => protocol.Description).HasMaxLength(500);

            builder.Entity<Qualification>().Property(qualification => qualification.Description).HasMaxLength(500);
            builder.Entity<Qualification>().Property(qualification => qualification.Name).HasMaxLength(50);

            SeedData(builder);
        }

        private void SeedData(ModelBuilder builder)
        {
            var format = "yyyy-MM-dd";
            var culture = CultureInfo.InvariantCulture;

            var employesQuali = new EmployeesQualifications[]
            {
                new EmployeesQualifications()
                {
                    EmployeeId = 1,
                    QualificationId =1,
                },
                new EmployeesQualifications()
                {
                    EmployeeId =1,
                    QualificationId =3,
                },
                new EmployeesQualifications()
                {
                    EmployeeId =1,
                    QualificationId =2,
                },
                new EmployeesQualifications()
                {
                    EmployeeId=2,
                    QualificationId = 1,
                },
                new EmployeesQualifications()
                {
                    EmployeeId=2,
                    QualificationId = 2,
                },
                new EmployeesQualifications()
                {
                    EmployeeId=3,
                    QualificationId = 1,
                },
                new EmployeesQualifications()
                {
                    EmployeeId=4,
                    QualificationId = 2,
                },
                new EmployeesQualifications()
                {
                    EmployeeId=5,
                    QualificationId = 2,
                },
            };
            var productList = new Product[]
            {
                new Product()
                {
                    Id=1,
                    Name = "Badania okresowe instalacji",
                    Description = "Badania okresowe instalacji elektrycznej",
                    Price = 1000,
                    QualificationType = QualificationType.Inne,
                },
                new Product()
                {
                    Id=2,
                    Name = "Położenie przewodów",
                    Description = "Położenie przewodów pod wymiane istalacji lektrycznej",
                    Price = 500,
                    QualificationType = QualificationType.Instalacyjne,
                },
                new Product()
                {
                    Id = 3,
                    Name = "Instalacja gniazda trójfazowego",
                    Description = "Instalacja gniazda trójfazowego w domu jednorodzinnym",
                    Price = 300,
                    QualificationType = QualificationType.Elektryczne,
                },
                new Product()
                {
                    Id=4,
                    Name = "Wymiana bezpieczników",
                    Description = "Wymiana bezpieczników w skrzynce rozdzielczej",
                    Price = 350,
                    QualificationType = QualificationType.Inne
                },
                new Product()
                {
                    Id =5,
                    Name = "Wymiana lamp",
                    Description = "Wymiana oświetlenia w budynku szkoły podstawowej w Jednorożcu",
                    Price = 800,
                    QualificationType = QualificationType.Instalacyjne,

                }
            };

            var protocolList = new Protocol[]
            {
                new Protocol()
                {
                    Id=1,
                    Name = "Protkół instalacji",
                    Description = "Protokół odbioru instalacji lektrycznej",
                    OrderId = 1,
                    EmployeeId = 1,
                    DateOfIssue = DateTime.ParseExact("2019-01-25", format, culture).Date,
                    IsSuccessfull = true,
                    Proclamation = "Badania zakończone pozytywnie, instalacja spełnia wymogi ",
                    ProtocolType = ProtocolType.Odbioru,
                    Weather = "Słoneczna",
                }
            };
            var invocieList = new Invoice[]
            {
                new Invoice()
                {
                    Id = 1,
                    InvoiceNumber = "20190125001",
                    Description = "Faktura za: Zlecenie badań istalacji",
                    AccountNumber = "2210101111222215202015",
                    PaymentType = PaymentType.Przelew,
                    DateOfIssue =DateTime.ParseExact("2019-01-25", format, culture).Date,
                    TaxRate = 23,
                    PaymentWithoutTax = 1000,
                    PaymentWithTax = 1230,
                    TaxPayment = 230,
                    OrderId = 1,
                    ClientId = 1,
                },
                new Invoice()
                {
                    Id = 2,
                    InvoiceNumber = "20190118001",
                    PaymentType = PaymentType.Gotówka,
                    DateOfIssue = DateTime.ParseExact("2019-01-25", format, culture).Date,
                    TaxRate = 23,
                    PaymentWithoutTax = 500,
                    PaymentWithTax = 615,
                    TaxPayment = 115,
                    OrderId =2,
                    ClientId =2,
                },

            };
            var orderList = new Order[]
            {
                new Order()
                {
                    Id = 1,
                    Title = "Zlecenie badań istalacji",
                    Description = "Zlecenie na badania isntalacji elektrycznej w celu odbioru budynku",
                    OrderStatus = OrderStatus.Zakończone,
                    OrderPriority = OrderPriority.Średni,
                    StartDate = DateTime.ParseExact("2019-01-15", format, culture).Date,
                    PlannedFinishDate = DateTime.ParseExact("2019-01-25", format, culture).Date,
                    AcutalFinishDate = DateTime.ParseExact("2019-01-25", format, culture).Date,
                    InvoiceId = 1,
                    ClientId =1,
                    ProductId = 1,
                    EmployeeId = 1,
                },
                new Order()
                {
                    Id = 2,
                    Title = "Zlecenie wymiany przewodów",
                    Description = "Zlecenie wymiany przewodów pod wymiane instalacji elektrycznej",
                    OrderStatus = OrderStatus.Zakończone,
                    OrderPriority = OrderPriority.Średni,
                    StartDate = DateTime.ParseExact("2019-02-15", format, culture).Date,
                    PlannedFinishDate = DateTime.ParseExact("2019-01-17", format, culture).Date,
                    AcutalFinishDate = DateTime.ParseExact("2019-01-18", format, culture).Date,
                    InvoiceId =2,
                    ClientId=2,
                    ProductId=2,
                    EmployeeId =2,
                },
                new Order()
                {
                    Id= 3,
                    Title ="Zlecenie na instalacje gniazda trójfazowego",
                    Description = "Zlecenie na instalacje gniazda trojfazowego w domu jednorodzinnym" ,
                    OrderStatus = OrderStatus.Zaczęte,
                    OrderPriority = OrderPriority.Niski,
                    StartDate = DateTime.ParseExact("2019-03-15", format, culture).Date,
                    PlannedFinishDate = DateTime.ParseExact("2019-03-17", format, culture).Date,
                    ClientId = 3,
                    ProductId = 3,
                    EmployeeId= 3,
                },
                new Order()
                {
                    Id = 4,
                    Title = "Zlecenie na wymiane bezpieczników",
                    Description = "Zlecenie na wymiane bezpieczników",
                    OrderStatus = OrderStatus.Zaplanowane,
                    OrderPriority = OrderPriority.Niski,
                    StartDate = DateTime.ParseExact("2019-04-18", format, culture).Date,
                    ClientId = 2,
                    ProductId = 4,
                    EmployeeId = 4,
                },
                new Order()
                {
                    Id=5,
                    Title = "Zlecenie na wymiane lamp",
                    Description = "Zlecenie wymiany lamp w budybku szkoły podstawowej w Jednorożcu",
                    OrderStatus = OrderStatus.Zaplanowane,
                    OrderPriority = OrderPriority.Wysoki,
                    StartDate = DateTime.ParseExact("2019-04-20", format, culture).Date,
                    ClientId =4,
                    ProductId=5,
                    EmployeeId= 4,
                }
            };
            var qualificationList = new Qualification[]
            {
                new Qualification()
                {
                    Id = 1,
                    Name = "SEP G1 D",
                    Description = "Osoba posiadająca świadectwo D moze nadzorować i organizować prace osób posiadających świadectwo “E”.",
                    QualificationType = QualificationType.Elektryczne,

                },
                new Qualification()
                {
                    Id =2,
                    Name = "SEP G1 E",
                    Description = "Osoba posiadająca świadectwo E może wykonywać prace w zakresie: obsługi, konserwacji, remontu, montażu i kontrolno-pomiarowym.",

                    QualificationType = QualificationType.Instalacyjne,

                },
                new Qualification()
                {
                    Id = 3,
                    Name = "UB",
                    Description = "Uprawnienia budowlane (UB) w specjalności instalacyjnej w zakresie sieci, instalacji i urządzeń elektrycznych i elektroenegetycznych",
                    QualificationType = QualificationType.Inne,

                }
            };


            var employeesList = new Employee[]
            {
                new Employee()
                {
                    Id = 1,
                    FirstName = "Andrzej",
                    LastName = "Duda",
                    City="Warszawa",
                    PostalCode ="00-001",
                    Street ="Lecha Kaczyńskiego 1",
                    Email ="adnrzej69@gmail.com",
                    PhoneNumber ="0700123456",
                    IsOccupied = true
                },
                new Employee()
                {
                    Id = 2,
                    FirstName = "Michał",
                    LastName = "Mucha",
                    City="Olsztyn",
                    PostalCode ="10-402",
                    Street ="Żołnierska 5",
                    Email ="mmucha@wp.pl",
                    PhoneNumber ="500501502",
                    IsOccupied = false
                },

                new Employee()
                {
                    Id = 3,
                    FirstName = "Wojtek",
                    LastName = "Konrad",
                    City="Przasnysz",
                    PostalCode ="06-300",
                    Street ="Polna 10",
                    Email ="wostask@o2.pl",
                    PhoneNumber ="536457852",
                    IsOccupied = false
                },

                new Employee()
                {
                    Id = 4 ,
                    FirstName = "Bartosz",
                    LastName = "Baprodzki",
                    City="Warszawa",
                    PostalCode ="00-002",
                    Street ="Długa 12",
                    Email ="bbaprodzki@wp.pl",
                    PhoneNumber ="604414524",
                    IsOccupied = false
                },
                new Employee()
                {
                    Id = 5 ,
                    FirstName = "Mariusz",
                    LastName = "Nowak",
                    City="Olsztyn",
                    PostalCode ="10-402",
                    Street ="Dworcowa 8",
                    Email ="mnowak@wp.pl",
                    PhoneNumber ="508258852",
                    IsOccupied = false
                }

            };
            var clientList = new Client[]
            {
                new Client()
                {
                    Id =1,
                    Name = "Henryk Kania",
                    REGON = "",
                    NIP = "",
                    PESEL = "62050604875",
                    PhoneNumber = "500201212",
                    Street = "Marcepanowa 54",
                    City = "Przasnysz",
                },
                new Client()
                {
                    Id =2,
                    Name = "Orlen",
                    REGON = "12345678912345",
                    NIP = "",
                    PESEL = "",
                    PhoneNumber = "500201212",
                    Street = "Marcepanowa 54",
                    City = "Przasnysz",
                },
                new Client()
                {
                    Id =3,
                    Name = "Marek Kowalski",
                    REGON = "",
                    NIP = "6523214529",
                    PESEL = "75030501963",
                    PhoneNumber = "685245652",
                    Street = "Leśna 4",
                    City = "Przasnysz",
                },
                new Client()
                {
                    Id=4,
                    Name = "Urząd Gminy Jednorożec",
                    NIP = "6254145289",
                    PhoneNumber = "297514858",
                    Street = "Odrodzenia 15",
                    City = "Jednorożec",
                }
            };


            builder.Entity<Client>().HasData(clientList);
            builder.Entity<Employee>().HasData(employeesList);
            builder.Entity<Product>().HasData(productList);
            builder.Entity<Protocol>().HasData(protocolList);
            builder.Entity<Qualification>().HasData(qualificationList);
            builder.Entity<EmployeesQualifications>().HasData(employesQuali);
            builder.Entity<Invoice>().HasData(invocieList);
            builder.Entity<Order>().HasData(orderList);
            
        }
    }
}
