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
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "698f301d-4872-4646-a0ce-4daf0fd39bad", "AQAAAAIAAYagAAAAENHXgUk27/JZGMzjjv8sV4P+yQnRv8DEKIg7dChjd57CtDIxsYE4ivbhJUr43Czivg==", "37912df8-1bcb-4ad2-b99a-60b0367af1e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8371f046-ef43-4c93-9716-8b4f946ede0d", "AQAAAAIAAYagAAAAEPVFFxQ+0fMlyJhjBwptTrc1tsSntsVvxJj37QSojVgzKy2R5YSBIs6ZxcdyzVVwbw==", "d4bdf7d2-0c7d-4fba-8d0d-eb6778d678a7" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "AddressDeliveryId", "AppUserId", "Country", "CreatedOn", "DateShipping", "DeliveryMethodId", "Discount", "District", "Email", "ExchangeRate", "FirstName", "IsPaid", "IsShippingToOffice", "Language", "LastName", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PhoneNumber", "PostCode", "PromoCodeId", "ShippingOfficeId", "ShippingPrice", "StatusOrderId", "SubTotal", "Total", "Town", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, null, 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10.00m, null, null, 1.00m, "John", false, false, "bg", "Doe", null, "123456", 1, "1234567890", null, null, null, 5.00m, 1, 0m, 0m, null, "1234567890" },
                    { 2, null, 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0.00m, null, null, 1.95m, "Jane", false, false, "en", "Doe", null, "123456x", 2, "1234567890x", null, null, null, 5.00m, 2, 0m, 0m, null, null }
                });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 25, 12, 33, 53, 2, DateTimeKind.Utc).AddTicks(6773));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 25, 12, 33, 53, 2, DateTimeKind.Utc).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 33, 53, 2, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 33, 53, 2, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 25, 15, 33, 53, 2, DateTimeKind.Local).AddTicks(6146));

            migrationBuilder.InsertData(
                table: "ProductsOrders",
                columns: new[] { "OrderId", "ProductId", "ImagePath", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "/files/products/product-01-image-01.webp", 5.00m, 2 },
                    { 2, 1, "/files/products/product-01-image-01.webp", 5.50m, 3 },
                    { 1, 2, "/files/products/product-02-image-01.webp", 6.50m, 4 },
                    { 1, 3, "/files/products/product-03-image-01.webp", 5.50m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

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
        }
    }
}
