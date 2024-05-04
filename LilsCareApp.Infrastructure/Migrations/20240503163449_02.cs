using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69a2654d-5401-4080-8385-a76d55ad2cae", "AQAAAAIAAYagAAAAEG5pPNClFlFrD0J7XynxOWz7cTkiq/d3fnacwyg9YDRHS/A2iMyB2HhDymLXp1N1Hg==", "234a0adc-6ebe-4cae-b039-82aa9118f476" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "059185df-dc17-4efa-8a72-46726af7bb3c", "AQAAAAIAAYagAAAAENqb2QrWclZKqymC9K3W1Nw38/GBXGz7hbTe6ZrLGL/7HZlzNGO/1RdBu4fHqfgPeQ==", "0a16e9df-5297-4e75-937f-8731d5e1bb2d" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 3, 16, 34, 48, 316, DateTimeKind.Utc).AddTicks(9767));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 3, 16, 34, 48, 316, DateTimeKind.Utc).AddTicks(9779));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 19, 34, 48, 316, DateTimeKind.Local).AddTicks(4948));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 19, 34, 48, 316, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 19, 34, 48, 316, DateTimeKind.Local).AddTicks(5044));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700df44e-fb67-40df-9330-46979991415b", "AQAAAAIAAYagAAAAEDyUdGenxirPyPB7k8fPW9NaWyJMS2PR8xjsa1/AB5T57hwN6DZDMC69T4tHo9i7Yg==", "c61f401d-9a69-4f0b-8448-e2bc6371e509" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed0c7702-2ef0-4d10-90ab-00f6da3728c0", "AQAAAAIAAYagAAAAEGqp1EoBYi7lkF8aibDaeWyKPOMofS5bNaSvH3UFpNM3eELDzKaEfRybZDzKcsJfyw==", "03bf68c6-5088-456d-8f6f-a7908122bfb8" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 3, 13, 0, 20, 26, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 3, 13, 0, 20, 26, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 16, 0, 20, 26, DateTimeKind.Local).AddTicks(1345));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 16, 0, 20, 26, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 3, 16, 0, 20, 26, DateTimeKind.Local).AddTicks(1435));
        }
    }
}
