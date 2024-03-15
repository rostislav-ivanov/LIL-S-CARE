using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                comment: "App User");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The image of user");

            migrationBuilder.CreateTable(
                name: "AddressDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Address Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "First Name Recipient"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Last Name Recipient"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Phone Number Recipient"),
                    PostCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Post Code"),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Address"),
                    Town = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Town"),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "District"),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Country"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "App User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDeliveries_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                },
                comment: "Address Delivery");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The category's primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The category's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                },
                comment: "The category of the product");

            migrationBuilder.CreateTable(
                name: "MessagesFromClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailForResponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesFromClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagesFromClients_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Payment method id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Payment method type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                },
                comment: "Payment methods");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The product's primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The product's name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The product's price"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "The product's quantity"),
                    Weight = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "The product's weight"),
                    Purpose = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, comment: "Properties of the product"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, comment: "The product's description"),
                    IngredientINCIs = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, comment: "The product ingredients INCI"),
                    Ingredients = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true, comment: "The product ingredients")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                },
                comment: "The product model");

            migrationBuilder.CreateTable(
                name: "ShippingProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of shipping provider")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of shipping provider"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of shipping"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Description duration of shipping"),
                    IsDeliveryToAddress = table.Column<bool>(type: "bit", nullable: false, comment: "Is delivery to address")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingProviders", x => x.Id);
                },
                comment: "Shipping providers");

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of the status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                },
                comment: "Status of the order");

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscribers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BagsUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The user id"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "The product id"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "The quantity of the product that the user has added to his bag")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BagsUsers", x => new { x.AppUserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_BagsUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BagsUsers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This table contains the products that the user has added to his bag");

            migrationBuilder.CreateTable(
                name: "ImageProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The image id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "The path of the image"),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The image of the product");

            migrationBuilder.CreateTable(
                name: "ProductsCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "The product id"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "The category id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and categories");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "The identifier of the product."),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The identifier of the user that created the review."),
                    Rating = table.Column<int>(type: "int", nullable: false, comment: "The rating of the review."),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "The title of the review."),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true, comment: "The comment of the review."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date when the review was created.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => new { x.ProductId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This class represents a review of a product.");

            migrationBuilder.CreateTable(
                name: "WishesUsers",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The user id"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "The product id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishesUsers", x => new { x.AppUserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_WishesUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishesUsers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "This table contains the products that the user has added to his wish list");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of Order Creating"),
                    StatusOrderId = table.Column<int>(type: "int", nullable: false, comment: "Status of Order"),
                    AddressDeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Address Delivery Id"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "App User Id"),
                    ShippingProviderId = table.Column<int>(type: "int", nullable: true, comment: "Shipping Provider Id"),
                    DateShipping = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of Shipping Creating"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Tracking Number of Order"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true, comment: "Payment Method Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddressDeliveries_AddressDeliveryId",
                        column: x => x.AddressDeliveryId,
                        principalTable: "AddressDeliveries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShippingProviders_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "ShippingProviders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_StatusOrders_StatusOrderId",
                        column: x => x.StatusOrderId,
                        principalTable: "StatusOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Order");

            migrationBuilder.CreateTable(
                name: "ImageReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The image id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "The path of the image"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "The identifier of the product."),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "The identifier of the author.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageReviews_Reviews_ProductId_AuthorId",
                        columns: x => new { x.ProductId, x.AuthorId },
                        principalTable: "Reviews",
                        principalColumns: new[] { "ProductId", "AuthorId" });
                },
                comment: "The image of the review");

            migrationBuilder.CreateTable(
                name: "ProductOrder",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrder", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrder_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and orders");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImagePath", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ba594e7f-7821-4984-8d75-edb5800559c2", 0, "f156049b-c0a0-4bd5-b355-516620c8da84", null, false, null, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEOv/AFZNfF9eCfV8113pvZCwkpq/WrroiughE3ScdD9Jcok60hLQq9zkyMwTiUTCDg==", null, false, "4e408b42-6361-4fa4-a75f-d24964c64a63", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "за тяло" },
                    { 2, "за суха кожа" },
                    { 3, "за мазна кожа" },
                    { 4, "за лице" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Наложен платеж" },
                    { 2, "С карта" },
                    { 3, "Банков превод" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "IngredientINCIs", "Ingredients", "Name", "Price", "Purpose", "Quantity", "Weight" },
                values: new object[,]
                {
                    { 1, "<p>Част от лимитирана колекция празнични продукти, които може да закупите поотделно или като подаръчен комплект. 💝</p><p>Захарен скраб за тяло - натурален, био и ръчно изработен, с аромат на топли и уютни празници - стествен шоколадов аромат и леко цитрусов от етерично масло сладък портокал.</p><p>💛Този сладък скраб за тяло в два цвята е домашно приготвен с любов, масло от гроздови семки и какаово масло. Цвета му е натуралне от червена мика (минерален пигмент). Този скраб е прекрасен подарък за всеки, който се нуждае от малко повече релаксиращи моменти и грижа за себе си този сезон.</p><p>Обогатен с витамин Е.</p><p class=\"mb-0\">100% натурален</p><p class=\"mb-0\">86% от България</p><p class=\"mb-0\">13% Био</p>", "<p>Sucrose (Захар), Vitis Vinifera Seed Oil (Масло от гроздови семки), Theobroma Cacao Seed Butter (Какаово масло)*, Stearic Acid , Citrus Sinensis (Портокал) Peel Oil*, Limonene**,\r\nLinalool**, Citral**, Benzyl Alcohol, Ethylhexylglycerin, Tocopherol (Vit E), Mica***, CI 77491***. *Био **Компоненти на етерични масла ***Минерални пигменти От България 81,4% Био 14,5%</p>", "<p><strong>Какаовото масло* </strong>- придава лек и естествен шоколадов аромат и предпазва и подхранва кожата.</p>\r\n<p><strong>Етеричното масло от сладък </strong>- портокал придават лек празничен аромат*.</p>\r\n<p><strong>Масло от гроздови семки </strong>- подхранва кожата. То е леко, некомедогенно и попива бързо.</p>\r\n<p><strong>Стеаринова киселина </strong>- наситена мастна 'киселина' която в природата се намира в много масла. В натуралния състав на какаовото масло е 24-37%, а в масло от шеа / карите е между 20-50%.</p>\r\n<p><strong>Витамин Е </strong>- натурален антиоксидант, който предпазва и защитава кожата от свободни радикали, процеси на оксидация и вредни влияния от околната среда.</p>\r\n<p>*Био</p>", "СКРАБ ЗА ТЯЛО", 9.00m, "<p>Изцяло натурален, може да използвате 1-2 пъти седмично, когато желаете нежно да ексфолирате кожата и да я направите по-мека и гладка.</p>\r\n<p>Използвайте с чисти ръце върху чиста и мокра кожа. Нежно масажирайте за ексфолиращ ефект. Изплакнете.</p>\r\n<p>Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, защитено от пряка слънчева светлина.</p> ", 10, "150 г" },
                    { 2, "Description 2", "IngredientINCIs 2", "Ingredients 2", "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", 4.00m, "Purpose 2", 20, "200g" },
                    { 3, "Description 3", "IngredientINCIs 3", "Ingredients 3", "ХИДРАТИРАЩ КРЕМ С ШИПКА", 12.00m, "Purpose 3", 30, "50 g" },
                    { 4, "Description 4", "IngredientINCIs 4", "Ingredients 4", "НЕЖЕН ЛОСИОН С НЕВЕН", 4.00m, "Purpose 4", 0, "400g" },
                    { 5, "Description 5", "IngredientINCIs 5", "Ingredients 5", "ДВУФАЗНА МИЦЕЛАРНА ВОДА", 10.00m, "Purpose 5", 50, "100 мл" },
                    { 6, "Description 6", "IngredientINCIs 6", "Ingredients 6", "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", 8.50m, "Purpose 6", 70, "50 g" },
                    { 7, "Description 7", "IngredientINCIs 7", "Ingredients 7", "СЕРУМ МАСЛО С ШИПКА И ЖОЖОБА", 9.00m, "Purpose 7", 80, "20 мл" }
                });

            migrationBuilder.InsertData(
                table: "ShippingProviders",
                columns: new[] { "Id", "Description", "IsDeliveryToAddress", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "2-3 работни дни", false, "До офис Еконт / Спиди", 6.50m },
                    { 2, "2-3 работни дни", true, "До адрес - Еконт", 8.50m }
                });

            migrationBuilder.InsertData(
                table: "StatusOrders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Заявена" },
                    { 2, "Отменена" },
                    { 3, "Изпратена" },
                    { 4, "Получена" }
                });

            migrationBuilder.InsertData(
                table: "AddressDeliveries",
                columns: new[] { "Id", "Address", "AppUserId", "Country", "District", "FirstName", "LastName", "PhoneNumber", "PostCode", "Town" },
                values: new object[,]
                {
                    { 1, "bul. Vitosha", "ba594e7f-7821-4984-8d75-edb5800559c2", "Bulgaria", "Sofia", "Ivan", "Ivanov", "0888888888", "1000", "Sofia" },
                    { 2, "bul. Vitosha", "ba594e7f-7821-4984-8d75-edb5800559c2", "Bulgaria", "Sofia", "Petar", "Petrov", "0888888888", "1000", "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "BagsUsers",
                columns: new[] { "AppUserId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 1, 2 },
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 2, 3 },
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "ImageProducts",
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://static.wixstatic.com/media/a6694c_24a7b0d7f63d42048f5a05e97362f385~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_24a7b0d7f63d42048f5a05e97362f385~mv2.jpg", 1 },
                    { 2, "https://static.wixstatic.com/media/a6694c_263e877cdb774516bea29e2155049a0d~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_263e877cdb774516bea29e2155049a0d~mv2.jpg", 1 },
                    { 3, "https://static.wixstatic.com/media/a6694c_69a0f0f6f1cf4847983b2248749af6cc~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_69a0f0f6f1cf4847983b2248749af6cc~mv2.jpg", 1 },
                    { 4, "https://static.wixstatic.com/media/a6694c_57415abd6b2b4d1f86e4ed35cf155e0d~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_57415abd6b2b4d1f86e4ed35cf155e0d~mv2.jpg", 1 },
                    { 5, "https://video.wixstatic.com/video/a6694c_b61f40bc476a43578be260fce9fa6efa/1080p/mp4/file.mp4", 1 },
                    { 6, "https://static.wixstatic.com/media/a6694c_75d8524a8fb046db82d0090671364c15~mv2.jpg/v1/fill/w_886,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_75d8524a8fb046db82d0090671364c15~mv2.jpg", 2 },
                    { 7, "https://static.wixstatic.com/media/a6694c_2f611f06e55346e5b3b22c94c0bb8077~mv2.jpg/v1/fill/w_887,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_2f611f06e55346e5b3b22c94c0bb8077~mv2.jpg", 2 },
                    { 8, "https://static.wixstatic.com/media/a6694c_1b60760d6a9e46f6ba0be663ab0cd432~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_1b60760d6a9e46f6ba0be663ab0cd432~mv2.jpg", 2 },
                    { 9, "https://static.wixstatic.com/media/a6694c_7ce163b0f3e4461d9ee3ef5c16b972f4~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_7ce163b0f3e4461d9ee3ef5c16b972f4~mv2.jpg", 2 },
                    { 10, "https://static.wixstatic.com/media/a6694c_8cf53b5caa60466b86d7e1e71035a5c1~mv2.jpg/v1/fill/w_886,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_8cf53b5caa60466b86d7e1e71035a5c1~mv2.jpg", 2 },
                    { 11, "https://static.wixstatic.com/media/a6694c_dbfcc272e90a48f89dfa6930ee2b0355~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_dbfcc272e90a48f89dfa6930ee2b0355~mv2.jpg", 2 },
                    { 12, "https://static.wixstatic.com/media/a6694c_44172c09d7974734aed4b4fa6474bac2~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_44172c09d7974734aed4b4fa6474bac2~mv2.jpg", 2 },
                    { 13, "https://video.wixstatic.com/video/a6694c_688be81645b14d1f9707a985aad784fb/1080p/mp4/file.mp4", 2 },
                    { 14, "https://static.wixstatic.com/media/a6694c_40945dc6b1754f74ab2b9331a5d4c692~mv2.jpg/v1/fill/w_887,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_40945dc6b1754f74ab2b9331a5d4c692~mv2.jpg", 3 },
                    { 15, "https://static.wixstatic.com/media/a6694c_dcb7369410054c2b8ffc9fa2f7a7854c~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_dcb7369410054c2b8ffc9fa2f7a7854c~mv2.jpg", 3 },
                    { 16, "https://static.wixstatic.com/media/a6694c_5e4516f6b7294324b75d8577ed3b7112~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_5e4516f6b7294324b75d8577ed3b7112~mv2.jpg", 3 },
                    { 17, "https://static.wixstatic.com/media/a6694c_955cfb52005d4979a9d170045f3bf603~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_955cfb52005d4979a9d170045f3bf603~mv2.jpg", 3 },
                    { 18, "https://static.wixstatic.com/media/a6694c_22c2642fbcb14b9c83a1b7b5349cb654~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_22c2642fbcb14b9c83a1b7b5349cb654~mv2.png", 3 },
                    { 19, "https://static.wixstatic.com/media/a6694c_9feeef67f1174acb9d05de346a5380f3~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_9feeef67f1174acb9d05de346a5380f3~mv2.png", 4 },
                    { 20, "https://static.wixstatic.com/media/a6694c_331b7666ec214d1cb9eab348b23156e6~mv2.png/v1/fill/w_832,h_665,al_c,usm_0.66_1.00_0.01/a6694c_331b7666ec214d1cb9eab348b23156e6~mv2.png", 4 },
                    { 21, "https://static.wixstatic.com/media/a6694c_8c8ef3eb0c7b4c009a08aecabee93d26~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_8c8ef3eb0c7b4c009a08aecabee93d26~mv2.png", 4 },
                    { 22, "https://static.wixstatic.com/media/a6694c_f3173997361b4b1b83ad90f807bbaf85~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_f3173997361b4b1b83ad90f807bbaf85~mv2.png", 4 },
                    { 23, "https://static.wixstatic.com/media/a6694c_6180737a52184e20a160a44b8b00cbc6~mv2.png/v1/fill/w_832,h_665,al_c,usm_0.66_1.00_0.01/a6694c_6180737a52184e20a160a44b8b00cbc6~mv2.png", 4 },
                    { 24, "https://static.wixstatic.com/media/a6694c_0d7a1d6d29d0432b85ad84001ad13a9b~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_0d7a1d6d29d0432b85ad84001ad13a9b~mv2.png", 4 },
                    { 25, "https://static.wixstatic.com/media/a6694c_2485f5b6aa434f04a31a359a58f370ce~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_2485f5b6aa434f04a31a359a58f370ce~mv2.png", 4 },
                    { 26, "https://video.wixstatic.com/video/a6694c_84516f7e298844d7954c342ceedba433/1080p/mp4/file.mp4", 4 },
                    { 27, "https://static.wixstatic.com/media/a6694c_c3e384c8ca434dc6b7c2920f660579e3~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c3e384c8ca434dc6b7c2920f660579e3~mv2.png", 5 },
                    { 28, "https://static.wixstatic.com/media/a6694c_c4aefe2a5f294a0faf6a2f7c19af32db~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c4aefe2a5f294a0faf6a2f7c19af32db~mv2.png", 5 },
                    { 29, "https://static.wixstatic.com/media/a6694c_a730f2e789864a9cb75ce1dde1e52b07~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_a730f2e789864a9cb75ce1dde1e52b07~mv2.png", 5 },
                    { 30, "https://static.wixstatic.com/media/a6694c_35eeecadd7f6495c99a3db846af81148~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_35eeecadd7f6495c99a3db846af81148~mv2.jpg", 5 },
                    { 31, "https://video.wixstatic.com/video/a6694c_5b80835e03c94fd6b720fdd2ceaa8865/1080p/mp4/file.mp4", 5 },
                    { 32, "https://static.wixstatic.com/media/a6694c_e95ca1c8158d4caba5b6e7bedaa0eeab~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_e95ca1c8158d4caba5b6e7bedaa0eeab~mv2.png", 6 },
                    { 33, "https://static.wixstatic.com/media/a6694c_6381e01ae9c340d598e09ea221ff60f2~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_6381e01ae9c340d598e09ea221ff60f2~mv2.png", 6 },
                    { 34, "https://static.wixstatic.com/media/a6694c_48c50850bac34de3911eb25953af593d~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_48c50850bac34de3911eb25953af593d~mv2.png", 6 },
                    { 35, "https://static.wixstatic.com/media/a6694c_757ebf6a259740c19feb8b3a9a6bc8f5~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_757ebf6a259740c19feb8b3a9a6bc8f5~mv2.png", 6 },
                    { 36, "https://static.wixstatic.com/media/a6694c_dcd9e99fe4d44425b1f77612e83ac7c3~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_dcd9e99fe4d44425b1f77612e83ac7c3~mv2.png", 7 },
                    { 37, "https://static.wixstatic.com/media/a6694c_2fa731434bbc41df95694781b5de4092~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_2fa731434bbc41df95694781b5de4092~mv2.png", 7 },
                    { 38, "https://static.wixstatic.com/media/a6694c_1a21a0325bd2422081c51946789b8adf~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_1a21a0325bd2422081c51946789b8adf~mv2.png", 7 },
                    { 39, "https://static.wixstatic.com/media/a6694c_f5e3c9c920fe41f395dc3bbb35e0161d~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_f5e3c9c920fe41f395dc3bbb35e0161d~mv2.png", 7 },
                    { 40, "https://static.wixstatic.com/media/a6694c_ec1aa69e21ac48dc9cfd0bf0522f8caa~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_ec1aa69e21ac48dc9cfd0bf0522f8caa~mv2.png", 7 },
                    { 41, "https://video.wixstatic.com/video/a6694c_8570c70283b14cce830d5da15331979c/480p/mp4/file.mp4", 7 },
                    { 42, "https://video.wixstatic.com/video/a6694c_3e25a17da1ba451786a46aa4daee1698/480p/mp4/file.mp4", 7 },
                    { 43, "https://static.wixstatic.com/media/a6694c_c198248097424ec09f04d600b3ee3a40~mv2.png/v1/fill/w_886,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c198248097424ec09f04d600b3ee3a40~mv2.png", 7 }
                });

            migrationBuilder.InsertData(
                table: "ProductsCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 4 },
                    { 4, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 6 },
                    { 4, 6 },
                    { 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "AuthorId", "ProductId", "Comment", "CreatedOn", "Rating", "Title" },
                values: new object[,]
                {
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 2, "Great product, I love it!", new DateTime(2024, 3, 15, 17, 32, 10, 397, DateTimeKind.Local).AddTicks(18), 4, "Great product" },
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 3, "Great product, I love it!", new DateTime(2024, 3, 15, 17, 32, 10, 397, DateTimeKind.Local).AddTicks(79), 3, "Great product" },
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 4, "Great product, I love it!", new DateTime(2024, 3, 15, 17, 32, 10, 397, DateTimeKind.Local).AddTicks(82), 3, "Great product" }
                });

            migrationBuilder.InsertData(
                table: "WishesUsers",
                columns: new[] { "AppUserId", "ProductId" },
                values: new object[,]
                {
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 1 },
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 3 },
                    { "ba594e7f-7821-4984-8d75-edb5800559c2", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressDeliveryId", "AppUserId", "CreatedOn", "DateShipping", "PaymentMethodId", "ShippingProviderId", "StatusOrderId", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, 1, "ba594e7f-7821-4984-8d75-edb5800559c2", new DateTime(2024, 3, 15, 15, 32, 9, 935, DateTimeKind.Utc).AddTicks(9447), new DateTime(2024, 3, 15, 15, 32, 9, 936, DateTimeKind.Utc).AddTicks(886), 1, 1, 1, "1234567890" },
                    { 2, 2, "ba594e7f-7821-4984-8d75-edb5800559c2", new DateTime(2024, 3, 15, 15, 32, 9, 936, DateTimeKind.Utc).AddTicks(2037), new DateTime(2024, 3, 15, 15, 32, 9, 936, DateTimeKind.Utc).AddTicks(2040), 2, 2, 2, "1234567890x" }
                });

            migrationBuilder.InsertData(
                table: "ProductOrder",
                columns: new[] { "OrderId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 },
                    { 2, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 1, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDeliveries_AppUserId",
                table: "AddressDeliveries",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BagsUsers_ProductId",
                table: "BagsUsers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageProducts_ProductId",
                table: "ImageProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageReviews_ProductId_AuthorId",
                table: "ImageReviews",
                columns: new[] { "ProductId", "AuthorId" });

            migrationBuilder.CreateIndex(
                name: "IX_MessagesFromClients_AppUserId",
                table: "MessagesFromClients",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressDeliveryId",
                table: "Orders",
                column: "AddressDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingProviderId",
                table: "Orders",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrder_OrderId",
                table: "ProductOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_AppUserId",
                table: "Subscribers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishesUsers_ProductId",
                table: "WishesUsers",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BagsUsers");

            migrationBuilder.DropTable(
                name: "ImageProducts");

            migrationBuilder.DropTable(
                name: "ImageReviews");

            migrationBuilder.DropTable(
                name: "MessagesFromClients");

            migrationBuilder.DropTable(
                name: "ProductOrder");

            migrationBuilder.DropTable(
                name: "ProductsCategories");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "WishesUsers");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AddressDeliveries");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ShippingProviders");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba594e7f-7821-4984-8d75-edb5800559c2");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");

            migrationBuilder.AlterTable(
                name: "AspNetUsers",
                oldComment: "App User");
        }
    }
}
