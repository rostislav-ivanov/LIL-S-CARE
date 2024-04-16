using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultAddressDeliveryId", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "475e879e-5ef2-43ac-9dbe-097a024d2e0a", null, "admin@mail.com", true, "Admin", null, "Adminov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEEnsDfA3oK7wGhMzYU5sw8oSI0E6/Yo5Aip2C5VQDRXh7wWKvAOJlidNnHYB1306aQ==", null, false, "3cd61d81-dec4-4275-92c0-910f57b03d77", false, "admin@mail.com" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "42fa6574-c753-4af1-b6ca-b3f2f168efcc", null, "test@softuni.bg", true, "Test", null, "Testov", false, null, "TEST@SOFTUNI.BG", "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAENeOV9+4klsC4/k7H1UUW0uZOIcwnE/4410rsaC/Iqn0UGW61BdbyKb6xTp5QlMABw==", null, false, "acf14a3e-424c-4a38-b226-56b370caf0da", false, "test@softuni.bg" }
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
                    { 1, "Наложен платеж" },
                    { 2, "С карта" },
                    { 3, "Банков превод" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "IsShow", "Name", "Optional", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, true, "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ", "Тегло:  25 г.", 5.50m, 10 },
                    { 2, true, "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", "Тегло:  5 г.", 4.00m, 20 },
                    { 3, true, "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД", "Тегло:  50 г.", 12.00m, 30 },
                    { 4, true, "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА", "Тегло:  100 мл.", 10.00m, 0 },
                    { 5, true, "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", "Тегло:  50 г.", 8.50m, 10 },
                    { 6, true, "СЕРУМ МАСЛО С ШИПКА, ЖОЖОБА, АРГАН И ЯГОДОВИ СЕМКИ", "Тегло:  20 мл.", 10.00m, 20 },
                    { 7, true, "", "", 10.00m, 0 }
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
                table: "PromoCodes",
                columns: new[] { "Id", "AppUserId", "AppliedDate", "Code", "Discount", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, "-10 % за регистрация", 0.1m, new DateTime(2025, 4, 16, 17, 44, 34, 518, DateTimeKind.Utc).AddTicks(7104) },
                    { 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, "-20 % отстъпка", 0.2m, new DateTime(2025, 4, 16, 17, 44, 34, 518, DateTimeKind.Utc).AddTicks(7123) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "AuthorId", "ProductId", "Comment", "CreatedOn", "Rating", "Title" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2, "Great product, I love it!", new DateTime(2024, 4, 16, 20, 44, 34, 518, DateTimeKind.Local).AddTicks(5793), 4, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3, "Great product, I love it!", new DateTime(2024, 4, 16, 20, 44, 34, 518, DateTimeKind.Local).AddTicks(5867), 3, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4, "Great product, I love it!", new DateTime(2024, 4, 16, 20, 44, 34, 518, DateTimeKind.Local).AddTicks(5873), 3, "Great product" }
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
                table: "WishesUsers",
                columns: new[] { "AppUserId", "ProductId" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 }
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
                table: "Orders",
                columns: new[] { "Id", "AddressDeliveryId", "AppUserId", "CreatedOn", "DateShipping", "Discount", "IsPaid", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PromoCodeId", "ShippingPrice", "StatusOrderId", "SubTotal", "Total", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", new DateTime(2024, 4, 16, 17, 44, 33, 731, DateTimeKind.Utc).AddTicks(2934), new DateTime(2024, 4, 16, 17, 44, 33, 731, DateTimeKind.Utc).AddTicks(4104), 0m, false, null, "123456", 1, null, 0m, 1, 0m, 0m, "1234567890" },
                    { 2, 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", new DateTime(2024, 4, 16, 17, 44, 33, 731, DateTimeKind.Utc).AddTicks(5302), new DateTime(2024, 4, 16, 17, 44, 33, 731, DateTimeKind.Utc).AddTicks(5303), 0m, false, null, "123456x", 2, null, 0m, 2, 0m, 0m, "1234567890x" }
                });

            migrationBuilder.InsertData(
                table: "ProductsOrders",
                columns: new[] { "OrderId", "ProductId", "ImagePath", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "", 0m, 0 },
                    { 2, 1, "", 0m, 0 },
                    { 1, 2, "", 0m, 0 },
                    { 1, 3, "", 0m, 0 },
                    { 2, 3, "", 0m, 0 },
                    { 1, 4, "", 0m, 0 },
                    { 2, 5, "", 0m, 0 },
                    { 1, 6, "", 0m, 0 },
                    { 2, 6, "", 0m, 0 },
                    { 1, 7, "", 0m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef");

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1 });

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 });

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 });

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 6 });

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
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 });

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 1 });

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 });

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AddressDeliveries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AddressDeliveries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StatusOrders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef");

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingOffices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
