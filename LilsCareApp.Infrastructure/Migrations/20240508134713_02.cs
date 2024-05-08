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
            migrationBuilder.AddColumn<int>(
                name: "OfficeAddressId",
                table: "ShippingOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cd622c4-e272-4f8f-a30d-2c51d61db128", "AQAAAAIAAYagAAAAEJYkAzeuU7jYhqkGD/sjctIZVGvRWPiNxAkdDXwLlYaD6+4sh2K3YCVFZRZLE0XEJQ==", "f9218e29-a12f-4d7b-b73b-aba8d135d770" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d6a3434-f42e-41cc-8281-89ca7db0301c", "AQAAAAIAAYagAAAAECIYML355j0jthwBipGVTtqlxhKG86wTgY5To9W+OmQLGETUtBlqOCp9VcKJ5Zz/FQ==", "9c15bc3b-da23-44da-aa40-00b5667f95d2" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 8, 13, 47, 9, 919, DateTimeKind.Utc).AddTicks(1960));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 8, 13, 47, 9, 919, DateTimeKind.Utc).AddTicks(1973));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 8, 16, 47, 9, 919, DateTimeKind.Local).AddTicks(1064));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 8, 16, 47, 9, 919, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 8, 16, 47, 9, 919, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 1,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 2,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 3,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 4,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 5,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 6,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 7,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 8,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 9,
                column: "OfficeAddressId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 10,
                column: "OfficeAddressId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeAddressId",
                table: "ShippingOffices");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3fa5fb3-50a8-4262-a2cb-6e820ee0086a", "AQAAAAIAAYagAAAAEMtaFDTCPnDh3aMSB6kBkcW+S60aPdFQytNZcJsu+MlmJzg/CG5TufCFMGap6wDmUw==", "8a920062-6f95-4b1d-9b0c-6e7e42c6a1b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8018332b-44ac-4ad4-a0db-96bc9ca5a10a", "AQAAAAIAAYagAAAAEHc9eNs79b+i3Rde8O58vqD7MavwLn4+KyouDjtJcKHK9nlA1L2ucYSVHLCxztytJg==", "5da0f29f-acf2-4a01-970e-d2c194b13914" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 5, 7, 16, 53, 57, DateTimeKind.Utc).AddTicks(9847));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 5, 5, 7, 16, 53, 57, DateTimeKind.Utc).AddTicks(9857));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 5, 10, 16, 53, 57, DateTimeKind.Local).AddTicks(8991));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 5, 10, 16, 53, 57, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 5, 5, 10, 16, 53, 57, DateTimeKind.Local).AddTicks(9066));
        }
    }
}
