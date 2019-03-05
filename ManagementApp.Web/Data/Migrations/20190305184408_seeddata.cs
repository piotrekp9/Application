using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementApp.Web.Data.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "Invoices",
                maxLength: 26,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 26);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "NIP", "Name", "PESEL", "PhoneNumber", "PostalCode", "REGON", "Street" },
                values: new object[] { 4, "Jednorożec", null, "6254145289", "Urząd Gminy Jednorożec", null, "297514858", null, null, "Odrodzenia 15" });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "AccountNumber", "ClientId", "DateOfIssue", "Description", "InvoiceNumber", "OrderId", "PaymentType", "PaymentWithTax", "PaymentWithoutTax", "TaxPayment", "TaxRate" },
                values: new object[,]
                {
                    { 1, "2210101111222215202015", 1, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faktura za: Zlecenie badań istalacji", "20190125001", 1, 1, 1230m, 1000m, 230m, 23 },
                    { 2, null, 2, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "20190118001", 2, 0, 615m, 500m, 115m, 23 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "QualificationType" },
                values: new object[,]
                {
                    { 1, "Badania okresowe instalacji elektrycznej", "Badania okresowe instalacji", 1000m, 2 },
                    { 2, "Położenie przewodów pod wymiane istalacji lektrycznej", "Położenie przewodów", 500m, 1 },
                    { 3, "Instalacja gniazda trójfazowego w domu jednorodzinnym", "Instalacja gniazda trójfazowego", 300m, 0 },
                    { 4, "Wymiana bezpieczników w skrzynce rozdzielczej", "Wymiana bezpieczników", 350m, 2 },
                    { 5, "Wymiana oświetlenia w budynku szkoły podstawowej w Jednorożcu", "Wymiana lamp", 800m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Description", "Name", "QualificationType" },
                values: new object[,]
                {
                    { 1, "Osoba posiadająca świadectwo D moze nadzorować i organizować prace osób posiadających świadectwo “E”.", "SEP G1 D", 0 },
                    { 2, "Osoba posiadająca świadectwo E może wykonywać prace w zakresie: obsługi, konserwacji, remontu, montażu i kontrolno-pomiarowym.", "SEP G1 E", 1 },
                    { 3, "Uprawnienia budowlane (UB) w specjalności instalacyjnej w zakresie sieci, instalacji i urządzeń elektrycznych i elektroenegetycznych", "UB", 2 }
                });

            migrationBuilder.InsertData(
                table: "EmployeesQualifications",
                columns: new[] { "EmployeeId", "QualificationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AcutalFinishDate", "ClientId", "Description", "EmployeeId", "InvoiceId", "OrderPriority", "OrderStatus", "PlannedFinishDate", "ProductId", "ProtocolId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zlecenie na badania isntalacji elektrycznej w celu odbioru budynku", 1, 1, 1, 2, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zlecenie badań istalacji" },
                    { 2, new DateTime(2019, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Zlecenie wymiany przewodów pod wymiane instalacji elektrycznej", 2, 2, 1, 2, new DateTime(2019, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, new DateTime(2019, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zlecenie wymiany przewodów" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Zlecenie na instalacje gniazda trojfazowego w domu jednorodzinnym", 3, null, 0, 1, new DateTime(2019, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, new DateTime(2019, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zlecenie na instalacje gniazda trójfazowego" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Zlecenie na wymiane bezpieczników", 4, null, 0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, new DateTime(2019, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zlecenie na wymiane bezpieczników" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Zlecenie wymiany lamp w budybku szkoły podstawowej w Jednorożcu", 4, null, 2, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zlecenie na wymiane lamp" }
                });

            migrationBuilder.InsertData(
                table: "Protocols",
                columns: new[] { "Id", "DateOfIssue", "Description", "EmployeeId", "IsSuccessfull", "Name", "OrderId", "Proclamation", "ProtocolType", "Weather" },
                values: new object[] { 1, new DateTime(2019, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Protokół odbioru instalacji lektrycznej", 1, true, "Protkół instalacji", 1, "Badania zakończone pozytywnie, instalacja spełnia wymogi ", 1, "Słoneczna" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                unique: true,
                filter: "[InvoiceId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeesQualifications",
                keyColumns: new[] { "EmployeeId", "QualificationId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Protocols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvoiceNumber",
                table: "Invoices",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Invoices",
                maxLength: 26,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 26,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_InvoiceId",
                table: "Orders",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
