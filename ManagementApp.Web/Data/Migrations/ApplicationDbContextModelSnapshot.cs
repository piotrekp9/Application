﻿// <auto-generated />
using System;
using ManagementApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagementApp.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasMaxLength(254);

                    b.Property<string>("NIP")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("PESEL")
                        .HasMaxLength(11);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(14);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(6);

                    b.Property<string>("REGON")
                        .HasMaxLength(14);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new { Id = 1, City = "Przasnysz", NIP = "", Name = "Henryk Kania", PESEL = "62050604875", PhoneNumber = "500201212", REGON = "", Street = "Marcepanowa 54" },
                        new { Id = 2, City = "Przasnysz", NIP = "", Name = "Orlen", PESEL = "", PhoneNumber = "500201212", REGON = "12345678912345", Street = "Marcepanowa 54" },
                        new { Id = 3, City = "Przasnysz", NIP = "6523214529", Name = "Marek Kowalski", PESEL = "75030501963", PhoneNumber = "685245652", REGON = "", Street = "Leśna 4" },
                        new { Id = 4, City = "Jednorożec", NIP = "6254145289", Name = "Urząd Gminy Jednorożec", PhoneNumber = "297514858", Street = "Odrodzenia 15" }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasMaxLength(254);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<bool>("IsOccupied");

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(14);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(6);

                    b.Property<string>("Street")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new { Id = 1, City = "Warszawa", Email = "adnrzej69@gmail.com", FirstName = "Andrzej", IsOccupied = true, LastName = "Duda", PhoneNumber = "0700123456", PostalCode = "00-001", Street = "Lecha Kaczyńskiego 1" },
                        new { Id = 2, City = "Olsztyn", Email = "mmucha@wp.pl", FirstName = "Michał", IsOccupied = false, LastName = "Mucha", PhoneNumber = "500501502", PostalCode = "10-402", Street = "Żołnierska 5" },
                        new { Id = 3, City = "Przasnysz", Email = "wostask@o2.pl", FirstName = "Wojtek", IsOccupied = false, LastName = "Konrad", PhoneNumber = "536457852", PostalCode = "06-300", Street = "Polna 10" },
                        new { Id = 4, City = "Warszawa", Email = "bbaprodzki@wp.pl", FirstName = "Bartosz", IsOccupied = false, LastName = "Baprodzki", PhoneNumber = "604414524", PostalCode = "00-002", Street = "Długa 12" },
                        new { Id = 5, City = "Olsztyn", Email = "mnowak@wp.pl", FirstName = "Mariusz", IsOccupied = false, LastName = "Nowak", PhoneNumber = "508258852", PostalCode = "10-402", Street = "Dworcowa 8" }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.EmployeesQualifications", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("QualificationId");

                    b.HasKey("EmployeeId", "QualificationId");

                    b.HasIndex("QualificationId");

                    b.ToTable("EmployeesQualifications");

                    b.HasData(
                        new { EmployeeId = 1, QualificationId = 1 },
                        new { EmployeeId = 1, QualificationId = 3 },
                        new { EmployeeId = 1, QualificationId = 2 },
                        new { EmployeeId = 2, QualificationId = 1 },
                        new { EmployeeId = 2, QualificationId = 2 },
                        new { EmployeeId = 3, QualificationId = 1 },
                        new { EmployeeId = 4, QualificationId = 2 },
                        new { EmployeeId = 5, QualificationId = 2 }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(26);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("InvoiceNumber")
                        .HasMaxLength(11);

                    b.Property<int>("OrderId");

                    b.Property<int>("PaymentType");

                    b.Property<decimal>("PaymentWithTax")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("PaymentWithoutTax")
                        .HasColumnType("decimal(8,2)");

                    b.Property<decimal>("TaxPayment")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("TaxRate");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Invoices");

                    b.HasData(
                        new { Id = 1, AccountNumber = "2210101111222215202015", ClientId = 1, DateOfIssue = new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Faktura za: Zlecenie badań istalacji", InvoiceNumber = "20190125001", OrderId = 1, PaymentType = 1, PaymentWithTax = 1230m, PaymentWithoutTax = 1000m, TaxPayment = 230m, TaxRate = 23 },
                        new { Id = 2, ClientId = 2, DateOfIssue = new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), InvoiceNumber = "20190118001", OrderId = 2, PaymentType = 0, PaymentWithTax = 615m, PaymentWithoutTax = 500m, TaxPayment = 115m, TaxRate = 23 }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AcutalFinishDate");

                    b.Property<int>("ClientId");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("EmployeeId");

                    b.Property<int?>("InvoiceId");

                    b.Property<int>("OrderPriority");

                    b.Property<int>("OrderStatus");

                    b.Property<DateTime>("PlannedFinishDate");

                    b.Property<int>("ProductId");

                    b.Property<int?>("ProtocolId");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InvoiceId")
                        .IsUnique()
                        .HasFilter("[InvoiceId] IS NOT NULL");

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");

                    b.HasData(
                        new { Id = 1, AcutalFinishDate = new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), ClientId = 1, Description = "Zlecenie na badania isntalacji elektrycznej w celu odbioru budynku", EmployeeId = 1, InvoiceId = 1, OrderPriority = 1, OrderStatus = 2, PlannedFinishDate = new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), ProductId = 1, StartDate = new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Zlecenie badań istalacji" },
                        new { Id = 2, AcutalFinishDate = new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), ClientId = 2, Description = "Zlecenie wymiany przewodów pod wymiane instalacji elektrycznej", EmployeeId = 2, InvoiceId = 2, OrderPriority = 1, OrderStatus = 2, PlannedFinishDate = new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), ProductId = 2, StartDate = new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Zlecenie wymiany przewodów" },
                        new { Id = 3, AcutalFinishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ClientId = 3, Description = "Zlecenie na instalacje gniazda trojfazowego w domu jednorodzinnym", EmployeeId = 3, OrderPriority = 0, OrderStatus = 1, PlannedFinishDate = new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), ProductId = 3, StartDate = new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Zlecenie na instalacje gniazda trójfazowego" },
                        new { Id = 4, AcutalFinishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ClientId = 2, Description = "Zlecenie na wymiane bezpieczników", EmployeeId = 4, OrderPriority = 0, OrderStatus = 0, PlannedFinishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ProductId = 4, StartDate = new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Zlecenie na wymiane bezpieczników" },
                        new { Id = 5, AcutalFinishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ClientId = 4, Description = "Zlecenie wymiany lamp w budybku szkoły podstawowej w Jednorożcu", EmployeeId = 4, OrderPriority = 2, OrderStatus = 0, PlannedFinishDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ProductId = 5, StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Title = "Zlecenie na wymiane lamp" }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(8,2)");

                    b.Property<int>("QualificationType");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Description = "Badania okresowe instalacji elektrycznej", Name = "Badania okresowe instalacji", Price = 1000m, QualificationType = 2 },
                        new { Id = 2, Description = "Położenie przewodów pod wymiane istalacji lektrycznej", Name = "Położenie przewodów", Price = 500m, QualificationType = 1 },
                        new { Id = 3, Description = "Instalacja gniazda trójfazowego w domu jednorodzinnym", Name = "Instalacja gniazda trójfazowego", Price = 300m, QualificationType = 0 },
                        new { Id = 4, Description = "Wymiana bezpieczników w skrzynce rozdzielczej", Name = "Wymiana bezpieczników", Price = 350m, QualificationType = 2 },
                        new { Id = 5, Description = "Wymiana oświetlenia w budynku szkoły podstawowej w Jednorożcu", Name = "Wymiana lamp", Price = 800m, QualificationType = 1 }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Protocol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("IsSuccessfull");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("OrderId");

                    b.Property<string>("Proclamation")
                        .HasMaxLength(500);

                    b.Property<int>("ProtocolType");

                    b.Property<string>("Weather")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Protocols");

                    b.HasData(
                        new { Id = 1, DateOfIssue = new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "Protokół odbioru instalacji lektrycznej", EmployeeId = 1, IsSuccessfull = true, Name = "Protkół instalacji", OrderId = 1, Proclamation = "Badania zakończone pozytywnie, instalacja spełnia wymogi ", ProtocolType = 1, Weather = "Słoneczna" }
                    );
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int>("QualificationType");

                    b.HasKey("Id");

                    b.ToTable("Qualifications");

                    b.HasData(
                        new { Id = 1, Description = "Osoba posiadająca świadectwo D moze nadzorować i organizować prace osób posiadających świadectwo “E”.", Name = "SEP G1 D", QualificationType = 0 },
                        new { Id = 2, Description = "Osoba posiadająca świadectwo E może wykonywać prace w zakresie: obsługi, konserwacji, remontu, montażu i kontrolno-pomiarowym.", Name = "SEP G1 E", QualificationType = 1 },
                        new { Id = 3, Description = "Uprawnienia budowlane (UB) w specjalności instalacyjnej w zakresie sieci, instalacji i urządzeń elektrycznych i elektroenegetycznych", Name = "UB", QualificationType = 2 }
                    );
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.EmployeesQualifications", b =>
                {
                    b.HasOne("ManagementApp.Web.Data.Models.Employee", "Employee")
                        .WithMany("EmployeesQualifications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ManagementApp.Web.Data.Models.Qualification", "Qualification")
                        .WithMany("EmployeesQualifications")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Invoice", b =>
                {
                    b.HasOne("ManagementApp.Web.Data.Models.Client", "Client")
                        .WithMany("Invoices")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Order", b =>
                {
                    b.HasOne("ManagementApp.Web.Data.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ManagementApp.Web.Data.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ManagementApp.Web.Data.Models.Invoice", "Invoice")
                        .WithOne("Order")
                        .HasForeignKey("ManagementApp.Web.Data.Models.Order", "InvoiceId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ManagementApp.Web.Data.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Protocol", b =>
                {
                    b.HasOne("ManagementApp.Web.Data.Models.Employee", "Employee")
                        .WithMany("Protocols")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ManagementApp.Web.Data.Models.Order", "Order")
                        .WithOne("Protocol")
                        .HasForeignKey("ManagementApp.Web.Data.Models.Protocol", "OrderId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
