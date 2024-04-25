using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeShipping = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price at which the shipping is free."),
                    AddressDeliveryPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The price at which the delivery to an address is paid."),
                    ExchangeRateEUR = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The exchange rate of the euro."),
                    ExchangeRateBGN = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The exchange rate of the leva."),
                    ExchangeRateRON = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "The exchange rate of the lei.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "DeliveryNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The delivery name Id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The delivery name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The delivery name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The delivery name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Payment name id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The payment name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The payment name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The payment name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The product's name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The product's name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The product's name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptionals",
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
                    table.PrimaryKey("PK_ProductOptionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodeNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Promo code name id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The promo code name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The promo code name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The promo code name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionEN = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "The section's description in English"),
                    DescriptionBG = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "The section's description in Bulgarian"),
                    DescriptionRO = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "The section's description in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleEN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The section's title in English"),
                    TitleBG = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The section's title in Bulgarian"),
                    TitleRO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The section's title in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionTitles", x => x.Id);
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
                name: "StatusOrderNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Status order name id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The status order name in English"),
                    NameBG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The status order name in Bulgarian"),
                    NameRO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The status order name in Romanian")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrderNames", x => x.Id);
                });

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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The category's primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false, comment: "The category's name Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_CategoryNames_NameId",
                        column: x => x.NameId,
                        principalTable: "CategoryNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "The category of the product");

            migrationBuilder.CreateTable(
                name: "DeliveryMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Delivery method id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false, comment: "Delivery method name Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryMethods_DeliveryNames_NameId",
                        column: x => x.NameId,
                        principalTable: "DeliveryNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Payment method id")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false, comment: "Payment method name Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentMethods_PaymentNames_NameId",
                        column: x => x.NameId,
                        principalTable: "PaymentNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Payment methods");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "The product's primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false, comment: "The product's name Id"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "The product's price"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "The product's quantity"),
                    OptionalId = table.Column<int>(type: "int", nullable: false, comment: "The product's optional Id"),
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
                    table.ForeignKey(
                        name: "FK_Products_ProductOptionals_OptionalId",
                        column: x => x.OptionalId,
                        principalTable: "ProductOptionals",
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
                    ShippingProviderId = table.Column<int>(type: "int", nullable: false, comment: "Shipping Provider Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingOffices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingOffices_ShippingProviders_ShippingProviderId",
                        column: x => x.ShippingProviderId,
                        principalTable: "ShippingProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StatusOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameId = table.Column<int>(type: "int", nullable: false, comment: "Name of the status Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusOrders_StatusOrderNames_NameId",
                        column: x => x.NameId,
                        principalTable: "StatusOrderNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Status of the order");

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
                    TitleId = table.Column<int>(type: "int", nullable: false, comment: "The section's title Id"),
                    DescriptionId = table.Column<int>(type: "int", nullable: false, comment: "The section's description Id"),
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
                    table.ForeignKey(
                        name: "FK_Sections_SectionDescriptions_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "SectionDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_SectionTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "SectionTitles",
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
                    ShippingOfficeId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "App User Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressDeliveries_ShippingOffices_ShippingOfficeId",
                        column: x => x.ShippingOfficeId,
                        principalTable: "ShippingOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CodeId = table.Column<int>(type: "int", nullable: false, comment: "Promo Code Id"),
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
                    table.ForeignKey(
                        name: "FK_PromoCodes_PromoCodeNames_CodeId",
                        column: x => x.CodeId,
                        principalTable: "PromoCodeNames",
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
                    DeliveryMethodId = table.Column<int>(type: "int", nullable: false, comment: "Method of Delivery"),
                    AddressDeliveryId = table.Column<int>(type: "int", nullable: true, comment: "Address Delivery Id"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "App User Id"),
                    DateShipping = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of Shipping Creating"),
                    TrackingNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "Tracking Number of Order"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false, comment: "Payment Method Id"),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false, comment: "Is Paid Order"),
                    NoteForDelivery = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "Note for Delivery"),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,4)", nullable: false, comment: "Exchange Rate of the Prices"),
                    Language = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Language of Order, determinate the currency of the prices"),
                    ShippingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Shipping Price"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Absolute Discount value"),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Sub Total Price of Order"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total Price of Order"),
                    PromoCodeId = table.Column<int>(type: "int", nullable: true, comment: "Promo Code Id"),
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
                    ShippingOfficeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AddressDeliveries_AddressDeliveryId",
                        column: x => x.AddressDeliveryId,
                        principalTable: "AddressDeliveries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryMethods_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PromoCodes_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ShippingOffices_ShippingOfficeId",
                        column: x => x.ShippingOfficeId,
                        principalTable: "ShippingOffices",
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
                name: "IX_Categories_NameId",
                table: "Categories",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethods_NameId",
                table: "DeliveryMethods",
                column: "NameId");

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
                name: "IX_Orders_DeliveryMethodId",
                table: "Orders",
                column: "DeliveryMethodId");

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
                name: "IX_Orders_ShippingOfficeId",
                table: "Orders",
                column: "ShippingOfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderId",
                table: "Orders",
                column: "StatusOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_NameId",
                table: "PaymentMethods",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NameId",
                table: "Products",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OptionalId",
                table: "Products",
                column: "OptionalId");

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
                name: "IX_PromoCodes_CodeId",
                table: "PromoCodes",
                column: "CodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AuthorId",
                table: "Reviews",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DescriptionId",
                table: "Sections",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ProductId",
                table: "Sections",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TitleId",
                table: "Sections",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOffices_ShippingProviderId",
                table: "ShippingOffices",
                column: "ShippingProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_StatusOrders_NameId",
                table: "StatusOrders",
                column: "NameId");

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
                name: "AppConfigs");

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
                name: "SectionDescriptions");

            migrationBuilder.DropTable(
                name: "SectionTitles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CategoryNames");

            migrationBuilder.DropTable(
                name: "DeliveryMethods");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropTable(
                name: "StatusOrders");

            migrationBuilder.DropTable(
                name: "ProductNames");

            migrationBuilder.DropTable(
                name: "ProductOptionals");

            migrationBuilder.DropTable(
                name: "DeliveryNames");

            migrationBuilder.DropTable(
                name: "PaymentNames");

            migrationBuilder.DropTable(
                name: "PromoCodeNames");

            migrationBuilder.DropTable(
                name: "StatusOrderNames");

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
