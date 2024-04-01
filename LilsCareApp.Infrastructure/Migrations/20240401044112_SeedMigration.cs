using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LilsCareApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultAddressDeliveryId", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "45fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "fff926c9-5a4a-4fde-88c1-985eb404bde2", null, "admin@mail.com", true, "Admin", null, "Adminov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAIAAYagAAAAEFOuqKJhD5Thv4RR8bV2ouzYDsqKSKuQAlRDmoubKIZuPWZAd9i61m6dDmBHv02UBg==", null, false, "fa41b08c-661a-437d-a28c-67f01dc8dd1b", false, "admin@mail.com" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 0, "69f1c7b2-d28d-4a56-9d26-67a270729390", null, "test@softuni.bg", true, "Test", null, "Testov", false, null, "TEST@SOFTUNI.BG", "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEO31/o23/qoSCsPPmGy5IIopzEeQn9ZHIaRlN88qPOAC+Nt8zFCQDHblD77vp3FdBw==", null, false, "187d17d7-1e7a-4c9b-8b25-943ebd46544c", false, "test@softuni.bg" }
                });

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
                columns: new[] { "Id", "Description", "IngredientINCIs", "Ingredients", "IsShow", "Name", "Optional", "Price", "Purpose", "Quantity", "ShippingCondition" },
                values: new object[,]
                {
                    { 1, "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n\r\n \r\n\r\nБез парфюм и без етерични масла.\r\n\r\n \r\n\r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n\r\n \r\n\r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n\r\n \r\n\r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n\r\n \r\n\r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n\r\n \r\n\r\n100% натурален\r\n\r\n10 % от България\r\n\r\n78.4% био", "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n\r\n*Bio", "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n\r\nВитамин Е има антиоксидантен ефект.\r\n\r\nКокосово масло, масло от ший (карите) и пчелен восък.", true, "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ", "Тегло:  25 г.", 5.50m, "Вземете блокчето от кутийката и намажете подмишничите.\r\n\r\n \r\n\r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n\r\n \r\n\r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n\r\n \r\n\r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", 10, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед." },
                    { 2, "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n\r\n \r\n\r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\n\r\nВ два варианта:\r\n\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\n\r\nОбогатен с витамин Е и био масло от жожоба.\r\n\r\n \r\n\r\n100% натурален\r\n\r\n49% от България\r\n\r\n41% био", "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n\r\n \r\n\r\nМаслото от жожоба* ги подхранва.\r\n\r\n \r\n\r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n\r\n \r\n\r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n\r\n \r\n\r\n*Био 41% от състава", true, "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", "Тегло:  5 г.", 4.00m, "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n\r\n \r\n\r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.", 20, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед." },
                    { 3, "", "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n\r\n*Bio", "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n\r\n \r\n\r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n\r\n \r\n\r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n\r\n \r\n\r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n\r\n \r\n\r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n\r\n \r\n\r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n\r\n \r\n\r\n*Био", true, "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД", "Тегло:  50 г.", 12.00m, "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n\r\n \r\n\r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n\r\n \r\n\r\nИли върхъ суха кожа, за да я защитите.\r\n\r\n \r\n\r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", 30, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед." },
                    { 4, "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n\r\n \r\n\r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n\r\n \r\n\r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n\r\n \r\n\r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n\r\n \r\n\r\nВ удобно шишенце с попма за лесно използване.\r\n\r\n \r\n\r\n100% натурална\r\n\r\n94% от България", "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n\r\n*Био", "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n\r\n \r\n\r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n\r\n \r\n\r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n\r\n \r\n\r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n\r\n \r\n\r\nЕтерично масло грейпфрут - лек цитрусов аромат", true, "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА", "Тегло:  100 мл.", 10.00m, "Разклаете преди употреба.\r\n\r\n \r\n\r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n\r\n \r\n\r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.", 0, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед." },
                    { 5, "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n\r\n \r\n\r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n\r\n \r\n\r\n100% натурален\r\n\r\n45.7 % от България\r\n\r\n44.5% био", "", "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n\r\n \r\n\r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n\r\n \r\n\r\nВитамин Е има антиоксидантен ефект.\r\n\r\n \r\n\r\nА цялата комбинация от съставки държи неприятните миризми далеч.", true, "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", "Тегло:  50 г.", 8.50m, "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n\r\n \r\n\r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", 10, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед." },
                    { 6, "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n\r\n \r\n\r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n\r\n \r\n\r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\n\r\nНекомедогенен.\r\n\r\nНай-подходящ за суха кожа.\r\n\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\n\r\nПодхранва, заздравява и защитава кожната бариера.\r\n\r\n \r\n\r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n\r\n \r\n\r\n100% натурален\r\n\r\n80% от България\r\n\r\n31% био", "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла", "Масло от шипка - помога ревитализирането на кожата \r\n\r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\n\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\n\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\n\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\n\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n\r\n*Био", true, "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА", "Тегло:  20 мл.", 10.00m, "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\n\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\n\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n\r\n \r\n\r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n\r\n \r\n\r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", 20, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед." },
                    { 7, null, null, null, true, "Some name", null, 10.00m, null, 10, null }
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
                    { 1, "Заявена" },
                    { 2, "Отменена" },
                    { 3, "Изпратена" },
                    { 4, "Получена" }
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
                columns: new[] { "Id", "ImagePath", "ProductId" },
                values: new object[,]
                {
                    { 1, "/files/products/product-01-image-01.webp", 1 },
                    { 2, "/files/products/product-01-image-02.webp", 1 },
                    { 3, "/files/products/product-01-image-03.webp", 1 },
                    { 4, "/files/products/product-01-image-04.webp", 1 },
                    { 5, "/files/products/product-02-image-01.webp", 2 },
                    { 6, "/files/products/product-02-image-02.webp", 2 },
                    { 7, "/files/products/product-02-image-03.webp", 2 },
                    { 8, "/files/products/product-02-image-04.webp", 2 },
                    { 9, "/files/products/product-02-image-05.webp", 2 },
                    { 10, "/files/products/product-03-image-01.webp", 3 },
                    { 11, "/files/products/product-03-image-02.webp", 3 },
                    { 12, "/files/products/product-03-image-03.webp", 3 },
                    { 13, "/files/products/product-03-image-04.webp", 3 },
                    { 14, "/files/products/product-03-image-05.webp", 3 },
                    { 15, "/files/products/product-04-image-01.webp", 4 },
                    { 16, "/files/products/product-04-image-02.webp", 4 },
                    { 17, "/files/products/product-04-image-03.webp", 4 },
                    { 18, "/files/products/product-04-image-04.webp", 4 },
                    { 19, "/files/products/product-05-image-01.webp", 5 },
                    { 20, "/files/products/product-05-image-02.webp", 5 },
                    { 21, "/files/products/product-05-image-03.webp", 5 },
                    { 22, "/files/products/product-05-image-04.webp", 5 },
                    { 23, "/files/products/product-06-image-01.webp", 6 },
                    { 24, "/files/products/product-06-image-02.webp", 6 },
                    { 25, "/files/products/product-06-image-03.webp", 6 },
                    { 26, "/files/products/product-06-image-04.webp", 6 },
                    { 27, "/files/products/product-06-image-05.webp", 6 }
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
                table: "PromoCodes",
                columns: new[] { "Id", "AppUserId", "AppliedDate", "Code", "Discount", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, "-10 % за регистрация", 0.1m, new DateTime(2025, 4, 1, 4, 41, 10, 237, DateTimeKind.Utc).AddTicks(6633) },
                    { 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", null, "-20 % отстъпка", 0.2m, new DateTime(2025, 4, 1, 4, 41, 10, 237, DateTimeKind.Utc).AddTicks(6643) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "AuthorId", "ProductId", "Comment", "CreatedOn", "Rating", "Title" },
                values: new object[,]
                {
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2, "Great product, I love it!", new DateTime(2024, 4, 1, 7, 41, 10, 237, DateTimeKind.Local).AddTicks(6211), 4, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3, "Great product, I love it!", new DateTime(2024, 4, 1, 7, 41, 10, 237, DateTimeKind.Local).AddTicks(6272), 3, "Great product" },
                    { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4, "Great product, I love it!", new DateTime(2024, 4, 1, 7, 41, 10, 237, DateTimeKind.Local).AddTicks(6276), 3, "Great product" }
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
                columns: new[] { "Id", "AddressDeliveryId", "AppUserId", "CreatedOn", "DateShipping", "Discount", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PromoCodeId", "ShippingPrice", "StatusOrderId", "SubTotal", "Total", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, 1, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", new DateTime(2024, 4, 1, 4, 41, 9, 387, DateTimeKind.Utc).AddTicks(8029), new DateTime(2024, 4, 1, 4, 41, 9, 387, DateTimeKind.Utc).AddTicks(9384), 0m, null, null, 1, null, 0m, 1, 0m, 0m, "1234567890" },
                    { 2, 2, "85fbe739-6be0-429d-b44b-1ce6cf7eeef", new DateTime(2024, 4, 1, 4, 41, 9, 388, DateTimeKind.Utc).AddTicks(6693), new DateTime(2024, 4, 1, 4, 41, 9, 388, DateTimeKind.Utc).AddTicks(6700), 0m, null, null, 2, null, 0m, 2, 0m, 0m, "1234567890x" }
                });

            migrationBuilder.InsertData(
                table: "ProductOrder",
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
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "ProductOrder",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 7 });

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
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
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
