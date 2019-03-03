using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApp.Web.Data.Migrations
{
    public partial class addclients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "NIP", "Name", "PESEL", "PhoneNumber", "PostalCode", "REGON", "Street" },
                values: new object[] { 1, "Przasnysz", null, "", "Henryk Kania", "62050604875", "500201212", null, "", "Marcepanowa 54" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "NIP", "Name", "PESEL", "PhoneNumber", "PostalCode", "REGON", "Street" },
                values: new object[] { 2, "Przasnysz", null, "", "Orlen", "", "500201212", null, "12345678912345", "Marcepanowa 54" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "NIP", "Name", "PESEL", "PhoneNumber", "PostalCode", "REGON", "Street" },
                values: new object[] { 3, "Przasnysz", null, "6523214529", "Marek Kowalski", "75030501963", "685245652", null, "", "Leśna 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
