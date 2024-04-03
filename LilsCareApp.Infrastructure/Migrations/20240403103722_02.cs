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
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Orders_OrderId",
                table: "ProductOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrder_Products_ProductId",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.RenameTable(
                name: "ProductOrder",
                newName: "ProductsOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ProductOrder_OrderId",
                table: "ProductsOrders",
                newName: "IX_ProductsOrders_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsOrders",
                table: "ProductsOrders",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f69c945f-b94f-4f8a-b589-3ba278fe7a09", "AQAAAAIAAYagAAAAEIKsnEIJw/byJWFvdcS558D0L4jfCZpdcu/bLorKKavJjSvdMVBau3MHT9blwR0BGA==", "a49922c7-e37f-4189-92e2-9160b7101f6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34a28d48-580a-4b6e-b4f9-8d358b09eebc", "AQAAAAIAAYagAAAAEJzs3RjuWWJMNjJNLBRXoyG0sYaLj4KjqcTwiHCxdKwVGUJ/0A81aokFBVxxi5xNWg==", "f9038918-944b-422e-a9c0-d2399857059e" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 3, 10, 37, 20, 359, DateTimeKind.Utc).AddTicks(7578), new DateTime(2024, 4, 3, 10, 37, 20, 359, DateTimeKind.Utc).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 3, 10, 37, 20, 360, DateTimeKind.Utc).AddTicks(3314), new DateTime(2024, 4, 3, 10, 37, 20, 360, DateTimeKind.Utc).AddTicks(3317) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 3, 10, 37, 21, 87, DateTimeKind.Utc).AddTicks(2346));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 3, 10, 37, 21, 87, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 37, 21, 87, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 37, 21, 87, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 3, 13, 37, 21, 87, DateTimeKind.Local).AddTicks(1825));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrders_Orders_OrderId",
                table: "ProductsOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsOrders_Products_ProductId",
                table: "ProductsOrders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrders_Orders_OrderId",
                table: "ProductsOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsOrders_Products_ProductId",
                table: "ProductsOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsOrders",
                table: "ProductsOrders");

            migrationBuilder.RenameTable(
                name: "ProductsOrders",
                newName: "ProductOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductOrder",
                newName: "IX_ProductOrder_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                columns: new[] { "ProductId", "OrderId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64a0ade4-28e5-449d-94a2-cdb743d6636b", "AQAAAAIAAYagAAAAEFAc5TExRW5WlolqWSTQ0ppjP4mX3mJfm0okz0u+jHMSIkWMGbpZInNXx9NhKUl87g==", "a4076b35-f265-4589-83db-9a7de2f01059" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60a40ad3-cc7d-40c6-a5c9-6baacfdde8a4", "AQAAAAIAAYagAAAAEFhw60llp4BnOvJ6ONvGpzVHIMScd9pxVzEYtSzqdkFo08Iz6avghvOeMGs4j2VG4w==", "30cb04e6-38e2-4d9e-8a3d-d9dbf9717391" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 4, 20, 579, DateTimeKind.Utc).AddTicks(5010), new DateTime(2024, 4, 2, 15, 4, 20, 579, DateTimeKind.Utc).AddTicks(6262) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 2, 15, 4, 20, 580, DateTimeKind.Utc).AddTicks(6633), new DateTime(2024, 4, 2, 15, 4, 20, 580, DateTimeKind.Utc).AddTicks(6635) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 2, 15, 4, 21, 308, DateTimeKind.Utc).AddTicks(8598));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 2, 15, 4, 21, 308, DateTimeKind.Utc).AddTicks(8607));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 18, 4, 21, 308, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 18, 4, 21, 308, DateTimeKind.Local).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 18, 4, 21, 308, DateTimeKind.Local).AddTicks(8019));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Orders_OrderId",
                table: "ProductOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrder_Products_ProductId",
                table: "ProductOrder",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
