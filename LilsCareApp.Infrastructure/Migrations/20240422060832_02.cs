using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Optional",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "NameId",
                table: "Products",
                type: "int",
                nullable: false,
                comment: "The product's name Id",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 100,
                oldComment: "The product's nameId");

            migrationBuilder.AddColumn<int>(
                name: "OptionalId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The product's optional Id");

            migrationBuilder.AlterColumn<string>(
                name: "NameRO",
                table: "ProductNames",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The product's name in Romanian",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "ProductNames",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The product's name in English",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NameBG",
                table: "ProductNames",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "The product's name in Bulgarian",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProductOptional",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionalEN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The product's optional in English"),
                    OptionalBG = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The product's optional in Bulgarian"),
                    OptionalRO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The product's optional in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptional", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "743950c4-d654-4d15-aa19-2a460f14bb3f", "AQAAAAIAAYagAAAAEM5rP2W21k1UwHLvj/saah+lchT/Q0lCDc963uhA8N7XF6Mfe3Pv1oU3506LedPILg==", "4bd317e4-8034-4b38-ad84-d28a99fe1ede" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "921bc3c2-2ba6-4b7c-82ea-a88311e8137c", "AQAAAAIAAYagAAAAEML84ppg4hw9JQfkJfn5QpBQyykiSiILQpwT55xQ5cH1LTLqixf64hxPZGrSIPeVLA==", "fb045396-3b8e-4bbc-9aab-573239087746" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 6, 8, 29, 780, DateTimeKind.Utc).AddTicks(9534), new DateTime(2024, 4, 22, 6, 8, 29, 781, DateTimeKind.Utc).AddTicks(743) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 6, 8, 29, 781, DateTimeKind.Utc).AddTicks(4667), new DateTime(2024, 4, 22, 6, 8, 29, 781, DateTimeKind.Utc).AddTicks(4670) });

            migrationBuilder.InsertData(
                table: "ProductOptional",
                columns: new[] { "Id", "OptionalBG", "OptionalEN", "OptionalRO" },
                values: new object[,]
                {
                    { 1, "Тегло:  25 г.", "Weight:  25 g.", "Greutate:  25 g." },
                    { 2, "Тегло:  5 г.", "Weight:  5 g.", "Greutate:  5 g." },
                    { 3, "Тегло:  50 г.", "Weight:  50 g.", "Greutate:  50 g." },
                    { 4, "Тегло:  100 мл.", "Weight:  100 ml.", "Greutate:  100 ml." },
                    { 5, "Тегло:  50 г.", "Weight:  50 g.", "Greutate:  50 g." },
                    { 6, "Тегло:  20 мл.", "Weight:  20 ml.", "Greutate:  20 ml." },
                    { 7, "", "", "" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "OptionalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "OptionalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "OptionalId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "OptionalId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "OptionalId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "OptionalId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "OptionalId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 6, 8, 30, 628, DateTimeKind.Utc).AddTicks(1636));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 6, 8, 30, 628, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 9, 8, 30, 628, DateTimeKind.Local).AddTicks(1129));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 9, 8, 30, 628, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 9, 8, 30, 628, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.CreateIndex(
                name: "IX_Products_OptionalId",
                table: "Products",
                column: "OptionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductOptional_OptionalId",
                table: "Products",
                column: "OptionalId",
                principalTable: "ProductOptional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductOptional_OptionalId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductOptional");

            migrationBuilder.DropIndex(
                name: "IX_Products_OptionalId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OptionalId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "NameId",
                table: "Products",
                type: "int",
                maxLength: 100,
                nullable: false,
                comment: "The product's nameId",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "The product's name Id");

            migrationBuilder.AddColumn<string>(
                name: "Optional",
                table: "Products",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                comment: "The optional property of product");

            migrationBuilder.AlterColumn<string>(
                name: "NameRO",
                table: "ProductNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The product's name in Romanian");

            migrationBuilder.AlterColumn<string>(
                name: "NameEN",
                table: "ProductNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The product's name in English");

            migrationBuilder.AlterColumn<string>(
                name: "NameBG",
                table: "ProductNames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "The product's name in Bulgarian");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "319da0d7-d311-4a2e-bbed-0854529e25ce", "AQAAAAIAAYagAAAAEMucDOJ6lkGlP65PeuD8dmoNo1gr5Gy+T+PQ9QVhyVnxVYDyD9foYKk++JdEOKjA1w==", "46a01e90-a10a-4063-9ccb-8062de8bd28c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa33b6b6-f0db-4d81-bcea-dbbcd108bf4f", "AQAAAAIAAYagAAAAEH4ThB8peoVjbiljzg43+UF5qCmNeWpctPdIknWKyvUjFRCKgdhcKtl9ensb4qThQA==", "b16f9f67-5f98-4ce1-bf84-e08f3ad7b79a" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(7047), new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(8085) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(9116), new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(9118) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Optional",
                value: "Тегло:  25 г.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Optional",
                value: "Тегло:  5 г.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Optional",
                value: "Тегло:  50 г.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Optional",
                value: "Тегло:  100 мл.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Optional",
                value: "Тегло:  50 г.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Optional",
                value: "Тегло:  20 мл.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Optional",
                value: "");

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 21, 14, 33, 59, 987, DateTimeKind.Utc).AddTicks(3329));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 21, 14, 33, 59, 987, DateTimeKind.Utc).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 21, 17, 33, 59, 987, DateTimeKind.Local).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 21, 17, 33, 59, 987, DateTimeKind.Local).AddTicks(664));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 21, 17, 33, 59, 987, DateTimeKind.Local).AddTicks(669));
        }
    }
}
