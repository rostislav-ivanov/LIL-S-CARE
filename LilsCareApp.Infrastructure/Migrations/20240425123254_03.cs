using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                table: "AddressDeliveries");

            migrationBuilder.AlterColumn<int>(
                name: "ShippingOfficeId",
                table: "AddressDeliveries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AddressDeliveries",
                columns: new[] { "Id", "Address", "AppUserId", "Country", "District", "Email", "FirstName", "IsShippingToOffice", "LastName", "PhoneNumber", "PostCode", "ShippingOfficeId", "Town" },
                values: new object[,]
                {
                    { 1, null, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, null, null, "Ivan", true, "Ivanov", "0888888888", null, 1, null },
                    { 2, "bul. Vitosha", "85fbe739-6be0-429d-b44b-1ce6cf7eeef", "Bulgaria", "Sofia", null, "Petar", false, "Petrov", "0888888888", "1000", null, "Sofia" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bb6131c-b813-4e31-afbc-b6fb533db74a", "AQAAAAIAAYagAAAAEOflOli0lIMYHlfUUr1dbbgMgVkJb0dGErsNA4Zc8ouG4erlB68NySQuWhO9jMfo9A==", "4c906e21-f51c-4345-9e33-8edc58697643" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46345fcc-1cc1-4fca-b667-0bd1ffeaeee8", "AQAAAAIAAYagAAAAEJpbc45eRKwqbGwBQ7muXu6Z6B8WKLZCBjj7Qx1SZvOJeIhWWtzHDa5GLJGSBZQ0vg==", "be17529f-8381-495c-b61e-a6ea4b3c23b8" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 25, 12, 32, 52, 181, DateTimeKind.Utc).AddTicks(7735));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 25, 12, 32, 52, 181, DateTimeKind.Utc).AddTicks(7746));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 32, 52, 181, DateTimeKind.Local).AddTicks(6805));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 32, 52, 181, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 32, 52, 181, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                table: "AddressDeliveries",
                column: "ShippingOfficeId",
                principalTable: "ShippingOffices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                table: "AddressDeliveries");

            migrationBuilder.DeleteData(
                table: "AddressDeliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressDeliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "ShippingOfficeId",
                table: "AddressDeliveries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bacb9fc-aa63-458b-8e61-297070588fc8", "AQAAAAIAAYagAAAAEJ79w49/R3p+NipRf4XIk9aXKvsfQF8GvZvKEfHIUYzuviQNWQXdYRvH14b4cqPUeQ==", "a7f06ee2-fe04-4412-a243-371c160d4b52" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dae2efd3-fa68-4b1d-999e-24e8e4d0c680", "AQAAAAIAAYagAAAAEN5oIPOKOsFdTI269ulJcOjmQukfH0dXt3f3oRVUmKo+oxbeowA2dC2mwBv9C/mPLA==", "4fdf3a0c-0121-428f-9113-0d2ed344e213" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 25, 12, 25, 3, 140, DateTimeKind.Utc).AddTicks(3961));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 25, 12, 25, 3, 140, DateTimeKind.Utc).AddTicks(3978));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 25, 3, 140, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 25, 3, 140, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 25, 3, 140, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                table: "AddressDeliveries",
                column: "ShippingOfficeId",
                principalTable: "ShippingOffices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
