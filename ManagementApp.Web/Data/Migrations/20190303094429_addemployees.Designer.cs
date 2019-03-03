﻿// <auto-generated />
using System;
using ManagementApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagementApp.Web.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190303094429_addemployees")]
    partial class addemployees
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                });

            modelBuilder.Entity("ManagementApp.Web.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber")
                        .HasMaxLength(26);

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("DateOfIssue");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int>("InvoiceNumber")
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

                    b.Property<int>("InvoiceId");

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
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.ToTable("Orders");
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
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
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