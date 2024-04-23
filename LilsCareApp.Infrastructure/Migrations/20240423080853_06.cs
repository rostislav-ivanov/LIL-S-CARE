using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeShipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price at which the shipping is free."),
                    AddressDeliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price at which the delivery to an address is paid."),
                    ExchangeRateEUR = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The exchange rate of the euro."),
                    ExchangeRateBGN = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The exchange rate of the leva."),
                    ExchangeRateRON = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The exchange rate of the lei.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppConfigs",
                columns: new[] { "Id", "AddressDeliveryPrice", "ExchangeRateBGN", "ExchangeRateEUR", "ExchangeRateRON", "FreeShipping" },
                values: new object[] { 1, 8.00m, 1m, 1.9558m, 0.3930m, 35.00m });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6473e56a-8c7a-479a-b918-634f439e509e", "AQAAAAIAAYagAAAAEPx8WU1MC0bEjaxxwzGfrri+G5NaohgLBzTJfbyKFpTaUM1kjc9N0QZ/Qz1X94EeVA==", "332c8418-6c58-4b95-8eff-60deaf0da0e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "855f1219-6050-4397-87fd-d46fb8da0b3e", "AQAAAAIAAYagAAAAEGX91T19tvJLXX2XP8MeypDnidfESErRxqp5BwzPnMVhkiiTt5Kn+cZLRabvwzbqbA==", "285fbae3-baa3-4733-95ee-5951afd4ca66" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 23, 8, 8, 51, 133, DateTimeKind.Utc).AddTicks(2398), new DateTime(2024, 4, 23, 8, 8, 51, 133, DateTimeKind.Utc).AddTicks(3436) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 23, 8, 8, 51, 133, DateTimeKind.Utc).AddTicks(4452), new DateTime(2024, 4, 23, 8, 8, 51, 133, DateTimeKind.Utc).AddTicks(4454) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 23, 8, 8, 51, 970, DateTimeKind.Utc).AddTicks(7699));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 23, 8, 8, 51, 970, DateTimeKind.Utc).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 23, 11, 8, 51, 970, DateTimeKind.Local).AddTicks(6971));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 23, 11, 8, 51, 970, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 23, 11, 8, 51, 970, DateTimeKind.Local).AddTicks(7037));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

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
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 16, 23, 40, 424, DateTimeKind.Utc).AddTicks(3313));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 16, 23, 40, 424, DateTimeKind.Utc).AddTicks(3348));

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
        }
    }
}
