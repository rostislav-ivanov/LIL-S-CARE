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
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

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
                name: "ProductNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameRO = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippingProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Unique identifier of shipping provider")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Name of shipping provider")
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The product's primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", maxLength: 100, nullable: false, comment: "The product's nameId"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The product's price"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "The product's quantity"),
                    Optional = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "The optional property of product"),
                    IsShow = table.Column<bool>(type: "bit", nullable: false, comment: "Is the product show on online store")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductNames_NameId",
                        column: x => x.NameId,
                        principalTable: "ProductNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The product model");

            migrationBuilder.CreateTable(
                name: "ShippingOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of shipping"),
                    ShippingDuration = table.Column<int>(type: "int", nullable: false, comment: "Duration of shipping"),
                    ShippingProviderId = table.Column<int>(type: "int", nullable: true, comment: "Shipping Provider Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingOffices_ShippingProviders_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "ShippingProviders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ImageProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The image id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImagePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false, comment: "The path of the image"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageOrder = table.Column<int>(type: "int", nullable: false, comment: "The order of the image in the product")
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
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The section's primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The section's title"),
                    Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "The section's description"),
                    SectionOrder = table.Column<int>(type: "int", nullable: false, comment: "The section's order in page"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "The product's primary key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The section model. Keeping descriptions of product");

            migrationBuilder.CreateTable(
                name: "AddressDeliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Address Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "First Name Recipient"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Last Name Recipient"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Phone Number Recipient"),
                    PostCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Post Code"),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "Address"),
                    Town = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Town"),
                    District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "District"),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Country"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Email"),
                    IsShippingToOffice = table.Column<bool>(type: "bit", nullable: false),
                    ShippingOfficeId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "App User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                        column: x => x.ShippingOfficeId,
                        principalTable: "ShippingOffices",
                        principalColumn: "Id");
                },
                comment: "Address Delivery");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "First Name"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Last Name"),
                    ImagePath = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "The image of user"),
                    DefaultAddressDeliveryId = table.Column<int>(type: "int", nullable: true, comment: "Default Address Delivery Id"),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AddressDeliveries_DefaultAddressDeliveryId",
                        column: x => x.DefaultAddressDeliveryId,
                        principalTable: "AddressDeliveries",
                        principalColumn: "Id");
                },
                comment: "App User");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Promo Code Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Promo Code"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Discount of Total Price Order"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Expiration Date of Promo Code"),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Owner of Promo Code")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Promo Code for one User");

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
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Order Number"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of Order Creating"),
                    StatusOrderId = table.Column<int>(type: "int", nullable: false, comment: "Status of Order"),
                    AddressDeliveryId = table.Column<int>(type: "int", nullable: false, comment: "Address Delivery Id"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "App User Id"),
                    DateShipping = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of Shipping Creating"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Tracking Number of Order"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true, comment: "Payment Method Id"),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, comment: "Is Paid Order"),
                    NoteForDelivery = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Note for Delivery"),
                    ShippingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Shipping Price"),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Sub Total"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Absolute Discount value"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total"),
                    PromoCodeId = table.Column<int>(type: "int", nullable: true, comment: "Promo Code Id")
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
                        name: "FK_Orders_PromoCodes_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCodes",
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
                name: "ProductsOrders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "The quantity of the product in the order"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price of the product at the time of the order"),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The image path of the product at the time of the order")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Many to many relation between products and orders");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultAddressDeliveryId", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "319da0d7-d311-4a2e-bbed-0854529e25ce", null, "admin@mail.com", true, "Admin", null, "Adminov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEMucDOJ6lkGlP65PeuD8dmoNo1gr5Gy+T+PQ9QVhyVnxVYDyD9foYKk++JdEOKjA1w==", null, false, "46a01e90-a10a-4063-9ccb-8062de8bd28c", false, "admin@mail.com" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "fa33b6b6-f0db-4d81-bcea-dbbcd108bf4f", null, "test@softuni.bg", true, "Test", null, "Testov", false, null, "TEST@SOFTUNI.BG", "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEH4ThB8peoVjbiljzg43+UF5qCmNeWpctPdIknWKyvUjFRCKgdhcKtl9ensb4qThQA==", null, false, "b16f9f67-5f98-4ce1-bf84-e08f3ad7b79a", false, "test@softuni.bg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "всички" },
                    { 2, "за тяло" },
                    { 3, "за суха кожа" },
                    { 4, "за мазна кожа" },
                    { 5, "за лице" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Плащане при доставка" },
                    { 2, "С карта" },
                    { 3, "Банков превод" }
                });

            migrationBuilder.InsertData(
                table: "ProductNames",
                columns: new[] { "Id", "NameBG", "NameEN", "NameRO" },
                values: new object[,]
                {
                    { 1, "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ", "NATURAL DRY DEODORANT", "DEODORANT NATURAL USCAT" },
                    { 2, "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", "LIP BALM WITH JOJOBA, COCOA AND BEESWAX", "BALSAM DE BUZE CU JOJOBA, CACAO SI CEARA DE ALBINE" },
                    { 3, "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД", "MOISTURIZING CREAM WITH ROSE BODY AND NIACINAMIDE", "CREMA HIDRATANTE CU CORP DE TRANDAFIRI SI NIACINAMIDA" },
                    { 4, "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА", "TWO PHASE GREEN TEA AND JOJOBA MICELLAR WATER", "CEAI VERDE BIFAZICAL ȘI APA MICELARĂ DE JOJOBA" },
                    { 5, "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", "NATURAL CREAM DEODORANT", "DEODORANT CREMA NATURAL" },
                    { 6, "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ", "SERUM OIL WITH ROSE BODY, JOJOBA, ARGAN AND STRAWBERRY SEEDS", "ULEI DE SER CU CORP DE TRANDAFIRI, SEMINTE DE JOJOBA, ARGAN SI CAPSUNI" },
                    { 7, "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "ShippingProviders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Еконт" },
                    { 2, "Спиди" }
                });

            migrationBuilder.InsertData(
                table: "StatusOrders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Неизпълнена" },
                    { 2, "Отменена" },
                    { 3, "Изпълнена" },
                    { 4, "Получена" },
                    { 5, "Върната" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsShow", "NameId", "Optional", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, true, 1, "Тегло:  25 г.", 5.50m, 10 },
                    { 2, true, 2, "Тегло:  5 г.", 4.00m, 20 },
                    { 3, true, 3, "Тегло:  50 г.", 12.00m, 30 },
                    { 4, true, 4, "Тегло:  100 мл.", 10.00m, 0 },
                    { 5, true, 5, "Тегло:  50 г.", 8.50m, 10 },
                    { 6, true, 6, "Тегло:  20 мл.", 10.00m, 20 },
                    { 7, true, 7, "", 10.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "AppUserId", "AppliedDate", "Code", "Discount", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, "-10 % за регистрация", 0.1m, new DateTime(2025, 4, 21, 14, 33, 59, 987, DateTimeKind.Utc).AddTicks(3329) },
                    { 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, "-20 % отстъпка", 0.2m, new DateTime(2025, 4, 21, 14, 33, 59, 987, DateTimeKind.Utc).AddTicks(3340) }
                });

            migrationBuilder.InsertData(
                table: "ShippingOffices",
                columns: new[] { "Id", "City", "OfficeAddress", "Price", "ShippingDuration", "ShippingProviderId" },
                values: new object[,]
                {
                    { 1, "Sofia", "bul. Vitosha 100", 5.00m, 2, 1 },
                    { 2, "Sofia", "bul. Hristo Botev 20", 5.00m, 2, 1 },
                    { 3, "Varna", "bul. Vitosha 100", 5.00m, 2, 1 },
                    { 4, "Burgas", "bul. Vitosha 100", 5.00m, 2, 1 },
                    { 5, "Ruse", "bul. Vitosha 100", 5.00m, 2, 1 },
                    { 6, "Sofia", "bul. Vitosha 200", 5.00m, 2, 2 },
                    { 7, "Sofia", "bul. Hristo Botev 30", 5.00m, 2, 2 },
                    { 8, "Sofia", "bul. Bozveli 200", 5.00m, 2, 2 },
                    { 9, "Burgas", "bul. Vitosha 200", 5.00m, 2, 2 },
                    { 10, "Ruse", "bul. Vitosha 200", 5.00m, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "AddressDeliveries",
                columns: new[] { "Id", "Address", "AppUserId", "Country", "District", "Email", "FirstName", "IsShippingToOffice", "LastName", "PhoneNumber", "PostCode", "ShippingOfficeId", "Town" },
                values: new object[,]
                {
                    { 1, "bul. Vitosha", "85fbe739-6be0-429d-b44b-1ce6cf7eeef", "Bulgaria", "Sofia", null, "Ivan", false, "Ivanov", "0888888888", "1000", 1, "Sofia" },
                    { 2, "bul. Vitosha", "85fbe739-6be0-429d-b44b-1ce6cf7eeef", "Bulgaria", "Sofia", null, "Petar", false, "Petrov", "0888888888", "1000", 2, "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "BagsUsers",
                columns: new[] { "AppUserId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1, 2 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2, 3 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "ImageProducts",
                columns: new[] { "Id", "ImageOrder", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "/files/products/product-01-image-01.webp", 1 },
                    { 2, 2, "/files/products/product-01-image-02.webp", 1 },
                    { 3, 3, "/files/products/product-01-image-03.webp", 1 },
                    { 4, 4, "/files/products/product-01-image-04.webp", 1 },
                    { 5, 1, "/files/products/product-02-image-01.webp", 2 },
                    { 6, 2, "/files/products/product-02-image-02.webp", 2 },
                    { 7, 3, "/files/products/product-02-image-03.webp", 2 },
                    { 8, 4, "/files/products/product-02-image-04.webp", 2 },
                    { 9, 5, "/files/products/product-02-image-05.webp", 2 },
                    { 10, 1, "/files/products/product-03-image-01.webp", 3 },
                    { 11, 2, "/files/products/product-03-image-02.webp", 3 },
                    { 12, 3, "/files/products/product-03-image-03.webp", 3 },
                    { 13, 4, "/files/products/product-03-image-04.webp", 3 },
                    { 14, 5, "/files/products/product-03-image-05.webp", 3 },
                    { 15, 1, "/files/products/product-04-image-01.webp", 4 },
                    { 16, 2, "/files/products/product-04-image-02.webp", 4 },
                    { 17, 3, "/files/products/product-04-image-03.webp", 4 },
                    { 18, 4, "/files/products/product-04-image-04.webp", 4 },
                    { 19, 1, "/files/products/product-05-image-01.webp", 5 },
                    { 20, 2, "/files/products/product-05-image-02.webp", 5 },
                    { 21, 3, "/files/products/product-05-image-03.webp", 5 },
                    { 22, 4, "/files/products/product-05-image-04.webp", 5 },
                    { 23, 1, "/files/products/product-06-image-01.webp", 6 },
                    { 24, 2, "/files/products/product-06-image-02.webp", 6 },
                    { 25, 3, "/files/products/product-06-image-03.webp", 6 },
                    { 26, 4, "/files/products/product-06-image-04.webp", 6 },
                    { 27, 5, "/files/products/product-06-image-05.webp", 6 }
                });

            migrationBuilder.InsertData(
                table: "ProductsCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 5, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 3, 4 },
                    { 5, 4 },
                    { 1, 5 },
                    { 3, 5 },
                    { 5, 5 },
                    { 1, 6 },
                    { 3, 6 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "AuthorId", "ProductId", "Comment", "CreatedOn", "Rating", "Title" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2, "Great product, I love it!", new DateTime(2024, 4, 21, 17, 33, 59, 987, DateTimeKind.Local).AddTicks(611), 4, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3, "Great product, I love it!", new DateTime(2024, 4, 21, 17, 33, 59, 987, DateTimeKind.Local).AddTicks(664), 3, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4, "Great product, I love it!", new DateTime(2024, 4, 21, 17, 33, 59, 987, DateTimeKind.Local).AddTicks(669), 3, "Great product" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Description", "ProductId", "SectionOrder", "Title" },
                values: new object[,]
                {
                    { 1, "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био", 1, 1, "ОПИСАНИЕ" },
                    { 2, "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.", 1, 2, "ЗА СЪСТАВКИТЕ" },
                    { 3, "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", 1, 3, "УПОТРЕБА" },
                    { 4, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", 1, 4, "ИЗПАЩАНЕ И ДОСТАВКА" },
                    { 5, "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", 1, 5, "СЪСТАВ, INCI" },
                    { 6, "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био", 2, 1, "ОПИСАНИЕ" },
                    { 7, "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава", 2, 2, "ЗА СЪСТАВКИТЕ" },
                    { 8, "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.", 2, 3, "УПОТРЕБА" },
                    { 9, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", 2, 4, "ИЗПАЩАНЕ И ДОСТАВКА" },
                    { 10, "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", 2, 5, "СЪСТАВ, INCI" },
                    { 11, "", 3, 1, "ОПИСАНИЕ" },
                    { 12, "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n \r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n \r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n \r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n \r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n \r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n \r\n*Био", 3, 2, "ЗА СЪСТАВКИТЕ" },
                    { 13, "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n \r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n \r\nИли върхъ суха кожа, за да я защитите.\r\n \r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", 3, 3, "УПОТРЕБА" },
                    { 14, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", 3, 4, "ИЗПАЩАНЕ И ДОСТАВКА" },
                    { 15, "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n*Bio", 3, 5, "СЪСТАВ, INCI" },
                    { 16, "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n \r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n \r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n \r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n \r\nВ удобно шишенце с попма за лесно използване.\r\n \r\n100% натурална\r\n94% от България", 4, 1, "ОПИСАНИЕ" },
                    { 17, "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n \r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n \r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n \r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n \r\nЕтерично масло грейпфрут - лек цитрусов аромат", 4, 2, "ЗА СЪСТАВКИТЕ" },
                    { 18, "Разклаете преди употреба.\r\n \r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.", 4, 3, "УПОТРЕБА" },
                    { 19, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", 4, 4, "ИЗПАЩАНЕ И ДОСТАВКА" },
                    { 20, "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n*Био", 4, 5, "СЪСТАВ, INCI" },
                    { 21, "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n \r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n \r\n100% натурален\r\n45.7 % от България\r\n44.5% био", 5, 1, "ОПИСАНИЕ" },
                    { 22, "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n \r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n \r\nВитамин Е има антиоксидантен ефект.\r\n \r\nА цялата комбинация от съставки държи неприятните миризми далеч.", 5, 2, "ЗА СЪСТАВКИТЕ" },
                    { 23, "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", 5, 3, "УПОТРЕБА" },
                    { 24, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", 5, 4, "ИЗПАЩАНЕ И ДОСТАВКА" },
                    { 25, "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil*, Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Компоненти на етерини масла", 5, 5, "СЪСТАВ, INCI" },
                    { 26, "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n \r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n \r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\nНекомедогенен.\r\nНай-подходящ за суха кожа.\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\nПодхранва, заздравява и защитава кожната бариера.\r\n \r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n \r\n100% натурален\r\n80% от България\r\n31% био", 6, 1, "ОПИСАНИЕ" },
                    { 27, "Масло от шипка - помога ревитализирането на кожата \r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n*Био", 6, 2, "ЗА СЪСТАВКИТЕ" },
                    { 28, "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n \r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", 6, 3, "УПОТРЕБА" },
                    { 29, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", 6, 4, "ИЗПАЩАНЕ И ДОСТАВКА" },
                    { 30, "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла", 6, 5, "СЪСТАВ, INCI" }
                });

            migrationBuilder.InsertData(
                table: "WishesUsers",
                columns: new[] { "AppUserId", "ProductId" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressDeliveryId", "AppUserId", "CreatedOn", "DateShipping", "Discount", "IsPaid", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PromoCodeId", "ShippingPrice", "StatusOrderId", "SubTotal", "Total", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(7047), new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(8085), 0m, false, null, "123456", 1, null, 0m, 1, 0m, 0m, "1234567890" },
                    { 2, 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(9116), new DateTime(2024, 4, 21, 14, 33, 59, 339, DateTimeKind.Utc).AddTicks(9118), 0m, false, null, "123456x", 2, null, 0m, 2, 0m, 0m, "1234567890x" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AddressDeliveries_AppUserId",
                table: "AddressDeliveries",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDeliveries_ShippingOfficeId",
                table: "AddressDeliveries",
                column: "ShippingOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DefaultAddressDeliveryId",
                table: "AspNetUsers",
                column: "DefaultAddressDeliveryId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_Orders_PromoCodeId",
                table: "Orders",
                column: "PromoCodeId",
                unique: true,
                filter: "[PromoCodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameId",
                table: "Products",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_CategoryId",
                table: "ProductsCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsOrders_OrderId",
                table: "ProductsOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_AppUserId",
                table: "PromoCodes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ProductId",
                table: "Sections",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOffices_ShippingProviderId",
                table: "ShippingOffices",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscribers_AppUserId",
                table: "Subscribers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishesUsers_ProductId",
                table: "WishesUsers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDeliveries_AspNetUsers_AppUserId",
                table: "AddressDeliveries",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressDeliveries_AspNetUsers_AppUserId",
                table: "AddressDeliveries");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BagsUsers");

            migrationBuilder.DropTable(
                name: "ImageProducts");

            migrationBuilder.DropTable(
                name: "ImageReviews");

            migrationBuilder.DropTable(
                name: "MessagesFromClients");

            migrationBuilder.DropTable(
                name: "ProductsCategories");

            migrationBuilder.DropTable(
                name: "ProductsOrders");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "WishesUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DropTable(
                name: "ProductNames");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AddressDeliveries");

            migrationBuilder.DropTable(
                name: "ShippingOffices");

            migrationBuilder.DropTable(
                name: "ShippingProviders");
        }
    }
}
