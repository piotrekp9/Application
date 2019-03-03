using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApp.Web.Data.Migrations
{
    public partial class addemployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "City", "Email", "FirstName", "IsOccupied", "LastName", "PhoneNumber", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "adnrzej69@gmail.com", "Andrzej", true, "Duda", "0700123456", "00-001", "Lecha Kaczyńskiego 1" },
                    { 2, "Olsztyn", "mmucha@wp.pl", "Michał", false, "Mucha", "500501502", "10-402", "Żołnierska 5" },
                    { 3, "Przasnysz", "wostask@o2.pl", "Wojtek", false, "Konrad", "536457852", "06-300", "Polna 10" },
                    { 4, "Warszawa", "bbaprodzki@wp.pl", "Bartosz", false, "Baprodzki", "604414524", "00-002", "Długa 12" },
                    { 5, "Olsztyn", "mnowak@wp.pl", "Mariusz", false, "Nowak", "508258852", "10-402", "Dworcowa 8" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
