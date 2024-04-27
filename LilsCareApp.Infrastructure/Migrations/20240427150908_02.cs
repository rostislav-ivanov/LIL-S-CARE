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
            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Orders",
                newName: "Currency");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "411a0be6-e4fc-48b1-8f90-84775de6fbd8", "AQAAAAIAAYagAAAAEMGLE3YgUs+tM+4949hTdn401+0ROyCLG/JFmhd8FD0Xq4dpGfVL/Miz53gaAeijxw==", "7c94d325-8006-472f-9511-caa62a5093b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4c3f3d9-1845-40fc-8a35-c4431d2e2cea", "AQAAAAIAAYagAAAAELrk/J2uOysXJLVHUO48f287zrdQIhXy3GRVV8PRB4uKvMhSm1NKYfyVQcFEMV//7w==", "fa92c284-23a4-4a32-b3d5-b232e9be722f" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 15, 9, 5, 332, DateTimeKind.Utc).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 15, 9, 5, 332, DateTimeKind.Utc).AddTicks(2662));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 27, 18, 9, 5, 332, DateTimeKind.Local).AddTicks(1818));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 27, 18, 9, 5, 332, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 27, 18, 9, 5, 332, DateTimeKind.Local).AddTicks(1901));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Currency",
                table: "Orders",
                newName: "Language");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0a50d3c-2d69-43c6-8660-e7ececf4fcd8", "AQAAAAIAAYagAAAAEJbeTk8rvFwzIQHcvuzsquw/c46h5w4IwRUEk23YCYZaWM+2c+FTydNDqKYDIOxdJQ==", "3f08a752-c18f-45a5-9257-c5bb6198d994" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ea205e9-77f1-4a42-80d8-987413b41a07", "AQAAAAIAAYagAAAAENO018wjcpe71vfbnYludCoSlStraZLb1Mk7BpR33Esltios6eA/REO9GRk4Rbz1fA==", "5c865cc6-ff9b-42c4-b53a-607ff562a7c7" });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 5, 50, 29, 409, DateTimeKind.Utc).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 27, 5, 50, 29, 409, DateTimeKind.Utc).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 27, 8, 50, 29, 409, DateTimeKind.Local).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 27, 8, 50, 29, 409, DateTimeKind.Local).AddTicks(2351));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 27, 8, 50, 29, 409, DateTimeKind.Local).AddTicks(2354));
        }
    }
}
