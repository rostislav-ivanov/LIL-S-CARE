using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "StatusOrders");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "StatusOrders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Name of the status Id");

            migrationBuilder.AddColumn<int>(
                name: "CodeId",
                table: "PromoCodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Promo Code Id");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "PaymentMethods",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Payment method type Id");

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Payment type id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The payment type in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The payment type in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The payment type in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodeNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Promo code name id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The promo code name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The promo code name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The promo code name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrderNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Status order name id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The status order name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The status order name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The status order name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrderNames", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65edfe19-e3cb-4b0c-8be3-c8174388402d", "AQAAAAIAAYagAAAAENm66+QQQzybKRcPLppw4BotQUrp6vVavUv9b85mb0Xr61A1FrfGPFJt71jIivT1Kg==", "bfd6b824-8089-40ae-85e2-77e33112cf0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f77de1c2-8fab-47fc-8c33-a74110715e39", "AQAAAAIAAYagAAAAENVZeAcidZVjRg4Tv9wb5a6agAjJhN7Wp+url7n6P6WEvLkz3ktVdVqt/A92F3STwA==", "531f1674-3867-46ba-aad0-49530b887a2f" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 23, 39, 241, DateTimeKind.Utc).AddTicks(1542), new DateTime(2024, 4, 22, 16, 23, 39, 241, DateTimeKind.Utc).AddTicks(2859) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 16, 23, 39, 241, DateTimeKind.Utc).AddTicks(9781), new DateTime(2024, 4, 22, 16, 23, 39, 241, DateTimeKind.Utc).AddTicks(9782) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "TypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "TypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "TypeId",
                value: 3);

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, "Плащане при доставка", "Cash on delivery", "Plata la livrare" },
                    { 2, "С карта", "With card", "Cu cardul" },
                    { 3, "Банков превод", "Bank transfer", "Transfer bancar" }
                });

            migrationBuilder.InsertData(
                table: "PromoCodeNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, "-10 % за регистрация", "-10 % for registration", "-10 % pentru inregistrare" },
                    { 2, "-20 % отстъпка", "-20 % discount", "-20 % reducere" }
                });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodeId", "ExpirationDate" },
                values: new object[] { 1, new DateTime(2025, 4, 22, 16, 23, 40, 424, DateTimeKind.Utc).AddTicks(3313) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CodeId", "ExpirationDate" },
                values: new object[] { 2, new DateTime(2025, 4, 22, 16, 23, 40, 424, DateTimeKind.Utc).AddTicks(3348) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 19, 23, 40, 424, DateTimeKind.Local).AddTicks(2111));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 19, 23, 40, 424, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 19, 23, 40, 424, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.InsertData(
                table: "StatusOrderNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, "Неизпълнена", "Unfulfilled", "Neîndeplinită" },
                    { 2, "Отменена", "Canceled", "Anulat" },
                    { 3, "Изпълнена", "Fulfilled", "Îndeplinit" },
                    { 4, "Получена", "Received", "Primit" },
                    { 5, "Върната", "Returned", "Returnat" }
                });

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "NameId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "NameId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "NameId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "NameId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "NameId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_StatusOrders_NameId",
                table: "StatusOrders",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_CodeId",
                table: "PromoCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_TypeId",
                table: "PaymentMethods",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_PaymentTypes_TypeId",
                table: "PaymentMethods",
                column: "TypeId",
                principalTable: "PaymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_PromoCodeNames_CodeId",
                table: "PromoCodes",
                column: "CodeId",
                principalTable: "PromoCodeNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StatusOrders_StatusOrderNames_NameId",
                table: "StatusOrders",
                column: "NameId",
                principalTable: "StatusOrderNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_PaymentTypes_TypeId",
                table: "PaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_PromoCodeNames_CodeId",
                table: "PromoCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_StatusOrders_StatusOrderNames_NameId",
                table: "StatusOrders");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "PromoCodeNames");

            migrationBuilder.DropTable(
                name: "StatusOrderNames");

            migrationBuilder.DropIndex(
                name: "IX_StatusOrders_NameId",
                table: "StatusOrders");

            migrationBuilder.DropIndex(
                name: "IX_PromoCodes_CodeId",
                table: "PromoCodes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_TypeId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "StatusOrders");

            migrationBuilder.DropColumn(
                name: "CodeId",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StatusOrders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Name of the status");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "PromoCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Promo Code");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Payment method type");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e06c1a9-3e7b-4639-a0c0-88c38d0b326a", "AQAAAAIAAYagAAAAEMSijOIjzLj8gBWrhzJyNFspdmXK8T18UWqk9uTgmbywfLXQbcIVOjExA4Ivv8OvmA==", "99608813-eee8-492b-9006-0558a1e7e96f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1063ce9f-4443-4a52-a3e3-901a848192f2", "AQAAAAIAAYagAAAAEK6UkmKX1bmfCaUZeteKUNu7e08q7i3MiL03avJmrj5HhdYP0741s7dvvBKjIgQtWg==", "56298213-c7c0-4b7e-aded-5beef8cbb1b7" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 12, 12, 42, 297, DateTimeKind.Utc).AddTicks(7729), new DateTime(2024, 4, 22, 12, 12, 42, 297, DateTimeKind.Utc).AddTicks(9203) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 12, 12, 42, 298, DateTimeKind.Utc).AddTicks(7095), new DateTime(2024, 4, 22, 12, 12, 42, 298, DateTimeKind.Utc).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Плащане при доставка");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "С карта");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Банков превод");

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Code", "ExpirationDate" },
                values: new object[] { "-10 % за регистрация", new DateTime(2025, 4, 22, 12, 12, 43, 335, DateTimeKind.Utc).AddTicks(8543) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Code", "ExpirationDate" },
                values: new object[] { "-20 % отстъпка", new DateTime(2025, 4, 22, 12, 12, 43, 335, DateTimeKind.Utc).AddTicks(8557) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 15, 12, 43, 335, DateTimeKind.Local).AddTicks(7807));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 15, 12, 43, 335, DateTimeKind.Local).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 15, 12, 43, 335, DateTimeKind.Local).AddTicks(7883));

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Неизпълнена");

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Отменена");

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Изпълнена");

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Получена");

            migrationBuilder.UpdateData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Върната");
        }
    }
}
