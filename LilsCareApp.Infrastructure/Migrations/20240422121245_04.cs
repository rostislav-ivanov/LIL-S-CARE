using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "NameId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The category's name Id");

            migrationBuilder.CreateTable(
                name: "CategoryNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The category's name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The category's name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The category's name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNames", x => x.Id);
                });

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "NameId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "NameId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "NameId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "NameId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "NameId",
                value: 5);

            migrationBuilder.InsertData(
                table: "CategoryNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, "всички", "all", "toate" },
                    { 2, "за тяло", "body", "pentru corp" },
                    { 3, "за суха кожа", "dry skin", "pentru piele uscata" },
                    { 4, "за мазна кожа", "oily skin", "pentru piele grasa" },
                    { 5, "за лице", "face", "pentru fata" }
                });

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
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 12, 12, 43, 335, DateTimeKind.Utc).AddTicks(8543));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 12, 12, 43, 335, DateTimeKind.Utc).AddTicks(8557));

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_NameId",
                table: "Categories",
                column: "NameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryNames_NameId",
                table: "Categories",
                column: "NameId",
                principalTable: "CategoryNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryNames_NameId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryNames");

            migrationBuilder.DropIndex(
                name: "IX_Categories_NameId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "The category's name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b9be100-5a8f-4709-85df-d226d57f08cd", "AQAAAAIAAYagAAAAEB3KfcGQFfrwzLf65Sw00b1Q/SnDLC9H08heFdYEaP2bPcbU4JxC2xLboN0IjjtCyg==", "4f002716-2d9d-4408-8aea-78a6eea0331a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d359383c-f9b1-4a43-89cd-e35b3de56bf6", "AQAAAAIAAYagAAAAELg8TdgQplC8dvFeMTNUHV5x7mYjyO4lGuySxuyPZGHGpOGSTtfpbBDqpxMD8nuu1A==", "e8baa58b-408d-4be0-8c5f-d173899c676f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "всички");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "за тяло");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "за суха кожа");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "за мазна кожа");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "за лице");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 8, 2, 25, 23, DateTimeKind.Utc).AddTicks(917), new DateTime(2024, 4, 22, 8, 2, 25, 23, DateTimeKind.Utc).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 8, 2, 25, 24, DateTimeKind.Utc).AddTicks(3374), new DateTime(2024, 4, 22, 8, 2, 25, 24, DateTimeKind.Utc).AddTicks(3376) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 8, 2, 25, 814, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 8, 2, 25, 814, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 11, 2, 25, 814, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 11, 2, 25, 814, DateTimeKind.Local).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 11, 2, 25, 814, DateTimeKind.Local).AddTicks(8849));
        }
    }
}
