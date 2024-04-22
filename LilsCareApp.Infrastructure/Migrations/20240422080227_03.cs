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
                name: "FK_Products_ProductOptional_OptionalId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOptional",
                table: "ProductOptional");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "ProductOptional",
                newName: "ProductOptionals");

            migrationBuilder.AddColumn<int>(
                name: "DescriptionId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The section's description Id");

            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The section's title Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOptionals",
                table: "ProductOptionals",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b9be100-5a8f-4709-85df-d226d57f08cd", "AQAAAAIAAYagAAAAEB3KfcGQFfrwzLf65Sw00b1Q/SnDLC9H08heFdYEaP2bPcbU4JxC2xLboN0IjjtCyg==", "4f002716-2d9d-4408-8aea-78a6eea0331a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d359383c-f9b1-4a43-89cd-e35b3de56bf6", "AQAAAAIAAYagAAAAELg8TdgQplC8dvFeMTNUHV5x7mYjyO4lGuySxuyPZGHGpOGSTtfpbBDqpxMD8nuu1A==", "e8baa58b-408d-4be0-8c5f-d173899c676f" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 8, 2, 25, 23, DateTimeKind.Utc).AddTicks(917), new DateTime(2024, 4, 22, 8, 2, 25, 23, DateTimeKind.Utc).AddTicks(2041) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DateShipping" },
                values: new object[] { new DateTime(2024, 4, 22, 8, 2, 25, 24, DateTimeKind.Utc).AddTicks(3374), new DateTime(2024, 4, 22, 8, 2, 25, 24, DateTimeKind.Utc).AddTicks(3376) });

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 8, 2, 25, 814, DateTimeKind.Utc).AddTicks(9238));

            migrationBuilder.UpdateData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpirationDate",
                value: new DateTime(2025, 4, 22, 8, 2, 25, 814, DateTimeKind.Utc).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 2 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 11, 2, 25, 814, DateTimeKind.Local).AddTicks(8776));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 3 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 11, 2, 25, 814, DateTimeKind.Local).AddTicks(8844));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "85fbe739-6be0-429d-b44b-1ce6cf7eeef", 4 },
                column: "CreatedOn",
                value: new DateTime(2024, 4, 22, 11, 2, 25, 814, DateTimeKind.Local).AddTicks(8849));

            migrationBuilder.InsertData(
                table: "SectionDescriptions",
                columns: new[] { "Id", "DescriptionBG", "DescriptionEN", "DescriptionRO" },
                values: new object[,]
                {
                    { 1, "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био", "Gentle, all-natural and handmade dry deodorant. Suitable for daily use.\r\n \r\nNo perfume and no essential oils.\r\n \r\nIn a new hard version for easier application and direct application.\r\n \r\nOr you can use an old deodorant stick pack to melt the bar for convenient daily use.\r\n \r\nCut the bar into pieces and put them in a stick pack. And microwave on low and for short intervals until the block melts. Let it cool and harden and it's done!\r\n \r\nIf you don't have a microwave, you can melt it in a water bath in a stick. Wrap the stick fitting tightly with stretch film to prevent water from entering the fitting and the product.\r\n \r\n100% natural\r\n10% from Bulgaria\r\n78.4% organic", "Deodorant uscat blând, natural și realizat manual. Potrivit pentru utilizarea zilnică.\r\n \r\nFără parfum și fără uleiuri esențiale.\r\n \r\nÎntr-o nouă versiune hard pentru aplicare mai ușoară și aplicare directă.\r\n \r\nSau puteți utiliza un pachet vechi de deodorant pentru a topi batonul pentru o utilizare zilnică convenabilă.\r\n \r\nTăiați batonul în bucăți și puneți-le într-un pachet de bețișoare. Și puneți la microunde la foc mic și pentru intervale scurte până când blocul se topește. Se lasa sa se raceasca si sa se intareasca si gata!\r\n \r\nDaca nu ai cuptor cu microunde il poti topi in baie de apa intr-un bat. Înveliți strâns garnitura cu folie extensibilă pentru a preveni intrarea apei în fiting și în produs.\r\n \r\n100% natural\r\n10% din Bulgaria\r\n78,4% organic" },
                    { 2, "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.", "Dry ingredients such as organic tapioca keep the underarms dry during the day.\r\nVitamin E has an antioxidant effect.\r\nCoconut oil, shea butter and beeswax.", "Ingredientele uscate precum tapioca organică mențin axile uscate în timpul zilei.\r\nVitamina E are efect antioxidant.\r\nUleiul de cocos, untul de shea și ceara de albine." },
                    { 3, "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", "Take the stick out of the box and apply to your underarms.\r\n \r\nOr gently melt it into a deodorant stick pack for easier and more convenient daily use.\r\n \r\nYou can reuse an old pack from a previous deodorant.\r\n r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed in a dry place protected from direct sunlight.", "Scoateți batonul din cutie și aplicați-l pe axile.\r\n \r\nSau topește-l ușor într-un pachet de deodorant pentru o utilizare zilnică mai ușoară și mai convenabilă.\r\n \r\nPuteți reutiliza un pachet vechi. dintr-un deodorant anterior.\r\n r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis intr-un loc uscat ferit de lumina directa a soarelui." },
                    { 4, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată." },
                    { 5, "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio" },
                    { 6, "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био", "An all-natural and hand-crafted lip balm that feels cozy and soft. Designed to be gentle and protective.\r\n \r\nOrganic Cocoa Butter\r\nNatural what a fragrance\r\nCombined with natural vanilla butter\r\nBeeswax\r\n \r\nIn two variants:\r \nLight and shiny transparent color\r\nCompletely colorless\r\n \r\nEnriched with vitamin E and organic jojoba oil.\r\n \r\n100% natural\r\n49% from Bulgaria\r\n41% bio", "Un balsam de buze natural și realizat manual, care se simte confortabil și moale. Conceput să fie blând și protector.\r\n \r\nUnt de cacao organic\r\nNatural ce parfum\r\nCombinat cu unt natural de vanilie\r\nCeară de albine\r\n \r\nÎn două variante:\r\nCuloare transparentă deschisă și strălucitoare\r\nComplet incolor\r\n \r\nÎmbogățit cu vitamina E și ulei organic de jojoba.\r\n \r\n100% natural\r\n49% din Bulgaria\r\n41% bio" },
                    { 7, "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава", "Cocoa butter* gives a light and natural chocolate aroma and protects the lips.\r\n \r\nJojoba oil* nourishes them.\r\n \r\nBeeswax* protects the lips, makes the balm last both on the lips and in the tube not to end quickly. Gives a feeling of cushion and softness on the lips.\r\n \r\nVitamin E - a natural antioxidant that protects against harmful environmental influences.\r\n \r\n*Bio 41% of the composition", "Untul de cacao* confera o aroma usoara si naturala de ciocolata si protejeaza buzele.\r\n \r\nUleiul de jojoba* le hraneste.\r\n \r\nCera de albine* protejeaza buzele, face ca balsamul sa reziste atat pe buze cat si în tub să nu se termine repede. Oferă o senzație de perniță și catifelare pe buze.\r\n \r\nVitamina E - un antioxidant natural care protejează împotriva influențelor nocive ale mediului.\r\n \r\n*Bio 41% din compoziție" },
                    { 8, "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.", "All natural, you can use it whenever you want to nourish and protect your lips or just give them a slight shine to complete your look.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store with the cap closed, in a dry place and protected from direct sunlight.", "În totalitate naturală, îl poți folosi oricând vrei să-ți hrănești și să-ți protejezi buzele sau doar să le dai o ușoară strălucire pentru a-ți completa aspectul.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra cu capacul inchis, la loc uscat si ferit de lumina directa a soarelui." },
                    { 9, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată." },
                    { 10, "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%" },
                    { 11, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 12, "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n \r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n \r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n \r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n \r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n \r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n \r\n*Био", "Bulgarian cold-pressed rosehip oil* - a natural source of vitamin A, nourishes and stimulates skin regeneration.\r\n \r\nRosehip extract - botanical glycerine extract, which in this cream is a wonderful combination with rosehip oil.\r \n \r\nShea Butter* - The lightest and lowest comedogenic rating (0-2) of all solid oils. This means it has a low chance of clogging pores on a scale of 0 to 5.\r\n \r\nVitamin B3 - Niacinamide - An antioxidant that evens out the complexion, regulates sebum, aids hydration and smoothes fine lines. Naistirna sounds incredible, a is doaxrno.\r\n \r\nVitamin E - has an effective and natural antioxidant effect: it forgets aging by helping to restore the skin and protects it from free radicals and environmental damage.\r\n \r\nVegetable glycerin and hyaluronic - humectants - attract water and hydrate the skin. Concentration is key! Too much of these can dry out the skin by starting to pull moisture from the deeper layers of the skin when the air is dry. The balance between water and humectants in the product is important.\r\n \r\n*Bio", "Uleiul bulgar de macese presat la rece* - o sursa naturala de vitamina A, hraneste si stimuleaza regenerarea pielii.\r\n \r\nExtract de macese - extract de glicerina botanica, care in aceasta crema este o combinatie minunata cu uleiul de macese.\r\n \r\nUnt de Shea* - Cel mai ușor și cel mai scăzut rating comedogen (0-2) dintre toate uleiurile solide. Aceasta înseamnă că are o șansă scăzută de a înfunda porii pe o scară de la 0 la 5.\r\n \r\nVitamina B3 - Niacinamidă - Un antioxidant care uniformizează tenul, reglează sebumul, ajută la hidratare și netezește liniile fine. Naistirna sună incredibil, a is doaxrno.\r\n \r\nVitamina E - are un efect antioxidant eficient și natural: uită de îmbătrânire ajutând la refacerea pielii și o protejează de radicalii liberi și daunele mediului.\r\n \r\nGlicerina vegetală și hialuronicul - umectanți - atrag apa și hidratează pielea. Concentrarea este cheia! Prea multe dintre acestea pot usca pielea, pornind să atragă umezeala din straturile mai profunde ale pielii atunci când aerul este uscat. Echilibrul dintre apă și umectanți din produs este important.\r\n \r\n*Bio" },
                    { 13, "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n \r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n \r\nИли върхъ суха кожа, за да я защитите.\r\n \r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", "Apply to dry or damp skin. A small amount is enough for the whole face and neck. Use 1-2 times daily as needed and skin dryness.\r\n \r\nCan be applied to damp skin, such as after shower and gel wash to lock in hydration.\r\n \r\nOr to dry skin , to protect it.\r\n \r\nApply to well-cleansed skin with clean hands. For external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed, in a dry place, protected from direct sunlight.", "Aplicați pe pielea uscată sau umedă. O cantitate mică este suficientă pentru toată fața și gâtul. Utilizați de 1-2 ori pe zi după cum este necesar și pielea uscată.\r\n \r\nPoate fi aplicat pe pielea umedă, cum ar fi după duș și spălare cu gel pentru a menține hidratarea.\r\n \r\nSau pe pielea uscată , pentru a-l proteja.\r\n \r\nAplicați pe pielea bine curățată cu mâinile curate. Doar pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis, intr-un loc uscat, ferit de lumina directa a soarelui." },
                    { 14, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată." },
                    { 15, "Aqua (apă), ulei de semințe de Rosa Canina* (ulei de măceș, 10%), unt de Butyrospermum Parkii* (unt de shea), glicerină (glicerină), extract de fructe Rosa Canina (extract de măceș), niacinamidă (vitamina B3), olivat de cetearil, Olivat de sorbitan (emulgatori), hialuronat de sodiu (acid hialuronic), tocoferol (vitamina E), ulei de semințe de Helianthus Annuus (floarea-soarelui)*, benzoat de sodiu, sorbat de potasiu (conservanți), acid lactic (acid lactic, AHA, reglează pH-ul) produs).\r\n*Bio", "Aqua (Water), Rosa Canina Seed Oil* (rosehip oil, 10%), Butyrospermum Parkii Butter* (shea butter), Glycerin (glycerin), Rosa Canina Fruit Extract (rosehip extract), Niacinamide (vitamin B3 ), Cetearyl Olivate, Sorbitan Olivate (emulsifiers), Sodium Hyaluronate (hyaluronic acid), Tocopherol (vitamin E), Helianthus Annuus (Sunflower) Seed Oil*, Sodium Benzoate, Potassium Sorbate (preservatives), Lactic Acid (lactic acid, AHA, adjusts the pH of the product).\r\n*Bio", "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n*Bio" },
                    { 16, "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n \r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n \r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n \r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n \r\nВ удобно шишенце с попма за лесно използване.\r\n \r\n100% натурална\r\n94% от България", "Natural micellar water with two components. Shake before use to mix the two phases. It is ideal for the gentle removal of make-up at the end of the day.\r\n \r\nIt has a double action as a facial toner with green tea extract and vitamin E.\r\n \r\nPhase 1 is extremely gentle. It has a soothing and antioxidant effect thanks to green tea extract, squalene and panthenol (provitamin B3).\r\n \r\nPhase 2 is with organic jojoba oil and helps to dissolve makeup. Leaves the skin soft, nourished and protected.\r\n \r\nIn a convenient bottle with a popma for easy use.\r\n \r\n100% natural\r\n94% from Bulgaria", "Apa micelara naturala cu doua componente. Agitați înainte de utilizare pentru a amesteca cele două faze. Este ideal pentru demachierea blândă la sfârșitul zilei.\r\n \r\nAre dublă acțiune ca tonic facial cu extract de ceai verde și vitamina E.\r\n \r\nFază 1 este extrem de blând. Are un efect calmant si antioxidant datorita extractului de ceai verde, squalenului si pantenolului (provitamina B3).\r\n \r\nFaza 2 este cu ulei de jojoba organic si ajuta la dizolvarea machiajului. Lasă pielea moale, hrănită și protejată.\r\n \r\nÎntr-o sticlă convenabilă cu popma pentru utilizare ușoară.\r\n \r\n100% natural\r\n94% din Bulgaria" },
                    { 17, "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n \r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n \r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n \r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n \r\nЕтерично масло грейпфрут - лек цитрусов аромат", "Green tea extract - antioxidant and soothing action, helps against the appearance of acne\r\n \r\nBio Jojoba oil - helps to gently dissolve make-up and nourishes the skin\r\n \r\nVitamin E - antioxidant, soothes irritations , fights free radicals and slows skin aging\r\n \r\nPanthenol - provitamin B5 - with plant origin. Hydrates and nourishes\r\n \r\nGrapefruit essential oil - light citrus scent", "Extract de ceai verde - actiune antioxidanta si calmanta, ajuta impotriva aparitiei acneei\r\n \r\nUlei de jojoba Bio - ajuta la dizolvarea delicata a machiajului si hraneste pielea\r\n \r\nVitamina E - antioxidant, calmeaza iritatii, combate radicalii liberi si incetineste imbatranirea pielii\r\n \r\nPantenol - provitamina B5 - cu origine vegetala. Hidratează și hrănește\r\n \r\nUlei esențial de grapefruit - parfum ușor de citrice" },
                    { 18, "Разклаете преди употреба.\r\n \r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.", "Shake before use.\r\n \r\nCan be used whenever you want to gently remove makeup. Shake before use and soak a cotton pad. Gently press into skin to wet and begin to dissolve makeup. Then remove the makeup with light movements from the center of the face to the sides.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store in a dry place away from direct sunlight.", "Agitați înainte de utilizare.\r\n \r\nPoate fi folosit oricând doriți să îndepărtați ușor machiajul. Agitați înainte de utilizare și înmuiați un tampon de bumbac. Apăsați ușor pielea pentru a uda și începe să dizolveți machiajul. Apoi indeparteaza machiajul cu miscari usoare din centrul fetei spre laterale.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra intr-un loc uscat ferit de lumina directa a soarelui." },
                    { 19, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată." },
                    { 20, "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n*Био", "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract, Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based ), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool .\r\n*Bio", "Aqua, ulei de semințe de Vitis Vinifera (struguri), extract de frunze de Camellia Sinensis (ceai verde), glicerină, trigliceride caprilice/caprice (ulei de cocos fracționat), ulei de semințe de Simmondsia Chinensis (jojoba)*, D-pantenol (provitamina B5, pe bază de plante) ), glucozid de coco, squalan, surfactin de sodiu, tocoferol (Vit E), ulei de semințe de Helianthus Annuus (floarea-soarelui)*, sorbat de potasiu, benzoat de sodiu, alcool benzilic, acid citric, ulei de coajă de Citrus Paradisi (grapefruit), limonen, citral, .\r\n*Bio" },
                    { 21, "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n \r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n \r\n100% натурален\r\n45.7 % от България\r\n44.5% био", "Gentle, all-natural and handmade deodorant. Suitable for daily use. The essential oils of sweet orange and eucalyptus impart a light citrus aroma.\r\n \r\nWe chose these essential oils not only for their pleasant aroma. They also have a better antibacterial effect than most essential oils. They even prevent the development of different types of fungi. This means it can naturally reduce the bad smell of sweat caused by underarm bacteria.\r\n \r\n100% natural\r\n45.7% from Bulgaria\r\n44.5% organic", "Deodorant blând, natural și realizat manual. Potrivit pentru uz zilnic. Uleiurile esențiale de portocală dulce și eucalipt conferă o aromă ușoară de citrice.\r\n \r\nAm ales aceste uleiuri esențiale nu numai pentru aroma lor plăcută. De asemenea, au un efect antibacterian mai bun decât majoritatea uleiurilor esențiale. Ele previn chiar și dezvoltarea diferitelor tipuri de ciuperci. Aceasta înseamnă că poate reduce în mod natural mirosul urât al transpirației cauzat de bacteriile de la subrat.\r\n \r\n100% natural\r\n45,7% din Bulgaria\r\n44,5% organic" },
                    { 22, "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n \r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n \r\nВитамин Е има антиоксидантен ефект.\r\n \r\nА цялата комбинация от съставки държи неприятните миризми далеч.", "The essential oils of sweet orange and eucalyptus give a fresh, slightly minty citrus aroma and have an antibacterial effect.\r\n \r\nDry ingredients such as organic tapioca keep the underarms dry during the day.\r\n \r\nVitamin E has an antioxidant effect. \r\n \r\nAnd the whole combination of ingredients keeps unpleasant odors away.", "Uleiurile esențiale de portocală dulce și eucalipt conferă o aromă de citrice proaspătă, ușor mentată și au efect antibacterian.\r\n \r\nIngredientele uscate precum tapioca organică mențin axilele uscate în timpul zilei.\r\n \r\nVitamina E are efect antioxidant \r\n \r\nIar intreaga combinatie de ingrediente tine la distanta mirosurile neplacute." },
                    { 23, "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", "Take a very small amount (smaller than a pea) on the fingertips, warm it slightly between the fingers and spread it well under the armpits.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Store tightly closed in a dry place protected from direct sunlight.", "Luați o cantitate foarte mică (mai mică decât un bob de mazăre) pe vârful degetelor, încălziți-o ușor între degete și întindeți-o bine sub axile.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. A se pastra bine inchis intr-un loc uscat ferit de lumina directa a soarelui." },
                    { 24, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată." },
                    { 25, "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil*, Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Компоненти на етерини масла", "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil* , Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Essential Oil Components", "Ulei de semințe de Vitis Vinifera (struguri), amidon de tapioca*, unt de semințe de cacao (cacao) de Theobroma*, Copernicia Cerifera Cera (ceară de carnauba)*, bicarbonat de sodiu, stearat de gliceril, ulei de coajă de Citrus Sinensis (portocale)*, globul de eucalipt* , Limonene**, Linalool**, Citral**, Tocoferol (Vit E), Ulei de semințe de Helianthus Annuus (floarea-soarelui)*\r\n*Bio\r\n**Componente ale uleiului esențial" },
                    { 26, "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n \r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n \r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\nНекомедогенен.\r\nНай-подходящ за суха кожа.\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\nПодхранва, заздравява и защитава кожната бариера.\r\n \r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n \r\n100% натурален\r\n80% от България\r\n31% био", "Created to pamper yourself - with organic oils from: rosehip, strawberry seeds, argan and jojoba. Nourishes and protects the skin. Preserves hydration by protecting the skin from water loss and leaving it soft and smooth.\r\n \r\nEnriched with vitamin E for a good antioxidant effect that protects cells from the harmful effects of the environment, free radicals and oxidative processes. In this way, it keeps the skin young and elastic.\r\n \r\nRosehip oil is a natural source of vitamin A. Argan oil and strawberry seed oil nourish the skin, and jojoba oil contains natural ceramides, strengthen the skin barrier and strengthen bonds between cells.\r\n\r\nNon-comedogenic.\r\nBest for dry skin.\r\nOr as protection after a more exhausting routine, e.g. after a chemical peel.\r\nNourishes, strengthens and protects the skin barrier.\r\n \r\nUse a few drops on dry or damp skin (for example after a shower) or after a moisturizing lotion to 'lock in' hydration and protect the skin. \r\n \r\n100% natural\r\n80% from Bulgaria\r\n31% organic", "Creat pentru a te rasfata - cu uleiuri organice din: macese, seminte de capsuni, argan si jojoba. Hraneste si protejeaza pielea. Păstrează hidratarea protejând pielea de pierderea apei și lăsând-o moale și netedă.\r\n \r\nÎmbogățit cu vitamina E pentru un bun efect antioxidant care protejează celulele de efectele nocive ale mediului, radicalilor liberi și proceselor oxidative. În acest fel, menține pielea tânără și elastică.\r\n \r\nUleiul de măceș este o sursă naturală de vitamina A. Uleiul de argan și uleiul de semințe de căpșuni hrănesc pielea, iar uleiul de jojoba conține ceramide naturale, întăresc bariera pielii și întărește legăturile dintre celule.\r\n\r\nNon-comedogenic.\r\nCel mai bun pentru pielea uscată.\r\nSau ca protecție după o rutină mai obositoare, de ex. după un peeling chimic.\r\nHrănește, întărește și protejează bariera cutanată.\r\n \r\nFolosește câteva picături pe pielea uscată sau umedă (de exemplu după un duș) sau după o loțiune hidratantă pentru a „bloca” hidratează și protejează pielea. \r\n \r\n100% natural\r\n80% din Bulgaria\r\n31% organic" },
                    { 27, "Масло от шипка - помога ревитализирането на кожата \r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n*Био", "Rosehip oil - helps revitalize the skin \r\nStrawberry seed oil - deeply hydrates and has an anti-inflammatory effect\r\nJojoba oil* - naturally contains over 95% ceramides, nourishes the skin and strengthens the skin barrier\r\nArgan oil* - nourishes, protects and improves the hydration and elasticity of the skin\r\nTangerine and ylang-ylang oils* - give a light, fresh and relaxing aroma to make the most of the skin care moment\r\nVitamin E* - antioxidant - soothes irritated skin and slows aging by fighting free radicals, UV damage and oxidation processes\r\n*Bio", "Ulei de măceș - ajută la revitalizarea pielii \r\nUlei din semințe de căpșuni - hidratează profund și are efect antiinflamator\r\nUlei de jojoba* - conține în mod natural peste 95% ceramide, hrănește pielea și întărește bariera pielii\r\nUlei de argan * - hrănește, protejează și îmbunătățește hidratarea și elasticitatea pielii\r\nUleiuri de mandarine și ylang-ylang* - oferă o aromă ușoară, proaspătă și relaxantă pentru a profita la maximum de momentul de îngrijire a pielii\r\nVitamina E* - antioxidant - calmează pielea iritată și încetinește îmbătrânirea prin combaterea radicalilor liberi, a daunelor UV și a proceselor de oxidare\r\n*Bio" },
                    { 28, "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n \r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", "For example, after a light moisturizing lotion to lock in hydration and beneficial ingredients.\r\nDirectly on damp skin for better absorption and protection.\r\nOr on dry skin to prevent transepidermal water loss from the skin.\r\n \r\nSuitable for skin protection at the end of the routine. Blends well after exfoliating and/or hydrating products.\r\n \r\nFor external use only. Keep out of reach of children. Do not use if allergic to any of the ingredients. Use with clean hands and skin. Store tightly closed, in a dry place, protected from direct sunlight.", "De exemplu, după o loțiune ușoară hidratantă pentru a bloca hidratarea și ingredientele benefice.\r\nDirect pe pielea umedă pentru o mai bună absorbție și protecție.\r\nSau pe pielea uscată pentru a preveni pierderea transepidermică de apă din piele.\r\n \r\nPotrivit pentru protecția pielii la sfârșitul rutinei. Se amestecă bine după produsele de exfoliere și/sau hidratare.\r\n \r\nNumai pentru uz extern. A nu se lăsa la îndemâna copiilor. A nu se utiliza dacă este alergic la oricare dintre ingrediente. Utilizați cu mâinile și pielea curate. A se pastra bine inchis, intr-un loc uscat, ferit de lumina directa a soarelui." },
                    { 29, "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "Once a shipping address or Econt or Speedy courier office is specified in the address fields when ordering, products are carefully packed in a recycled cardboard box and paper padding for a seal and sent by inspected delivery.", "Odată ce o adresă de expediere sau un birou de curierat Econt sau Speedy este specificată în câmpurile de adresă în momentul comenzii, produsele sunt ambalate cu grijă într-o cutie de carton reciclat și căptușeală de hârtie pentru sigilare și trimise prin livrare inspectată." },
                    { 30, "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла", "Vitis Vinifera Seed Oil, Rosa Canina Seed Oil, Fragaria Ananassa Seed Oil, Argania Spinosa Kernel Oil, Simmondsia Chinensis Seed Oil (Jojoba Oil)*, Tocopherol (Vitamin E), Helianthus Annuus Seed Oil (Sunflower Oil <0.2%) *, Citrus Reticulata Oil (Mandarin Essential Oil), Limonene**, Linalool**, Cananga Odorata flower Oil (Ylang Ylanf essential oil) *.\r\n*Bio, 31%\r\n**Essential oil components", "Ulei de semințe de Vitis Vinifera, ulei de semințe de Rosa Canina, ulei de semințe de Fragaria Ananassa, ulei de semințe de Argania Spinosa, ulei de semințe de Simmondsia Chinensis (ulei de jojoba)*, tocoferol (vitamina E), ulei de semințe de Helianthus annuus (ulei de floarea soarelui <0,2%) *, citrice Ulei de reticulata (ulei esential de mandarina), limonene**, linalool**, ulei de flori de cananga odorata (ulei esential de Ylang Ylanf) *.\r\n*Bio, 31%\r\n**Componente ale uleiului esential" },
                    { 31, "", "", "" },
                    { 32, "", "", "" },
                    { 33, "", "", "" },
                    { 34, "", "", "" },
                    { 35, "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "SectionTitles",
                columns: new[] { "Id", "TitleBG", "TitleEN", "TitleRO" },
                values: new object[,]
                {
                    { 1, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 2, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 3, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 4, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 5, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 6, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 7, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 8, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 9, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 10, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 11, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 12, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 13, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 14, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 15, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 16, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 17, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 18, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 19, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 20, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 21, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 22, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 23, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 24, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 25, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 26, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 27, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 28, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 29, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 30, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" },
                    { 31, "ОПИСАНИЕ", "DESCRIPTION", "DESCRIERE" },
                    { 32, "ЗА СЪСТАВКИТЕ", "ABOUT THE INGREDIENTS", "DESPRE INGREDIENTE" },
                    { 33, "УПОТРЕБА", "USE", "UTILIZARE" },
                    { 34, "ИЗПРАЩАНЕ И ДОСТАВКА", "PICKUP AND DELIVERY", "RIDICARE ȘI LIVRARE" },
                    { 35, "СЪСТАВ, INCI", "COMPOSITION, INCI", "COMPOZIȚIE, INCI" }
                });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 4, 4 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 5, 5 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 7, 7 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 8, 8 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 9, 9 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 10, 10 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 11, 11 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 12, 12 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 13, 13 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 14, 14 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 15, 15 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 16, 16 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 17, 17 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 18, 18 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 19, 19 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 20, 20 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 21, 21 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 22, 22 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 23, 23 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 24, 24 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 26, 26 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 27, 27 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 28, 28 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 29, 29 });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "DescriptionId", "TitleId" },
                values: new object[] { 30, 30 });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "DescriptionId", "ProductId", "SectionOrder", "TitleId" },
                values: new object[,]
                {
                    { 31, 31, 7, 1, 31 },
                    { 32, 32, 7, 2, 32 },
                    { 33, 33, 7, 3, 33 },
                    { 34, 34, 7, 4, 34 },
                    { 35, 35, 7, 5, 35 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sections_DescriptionId",
                table: "Sections",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TitleId",
                table: "Sections",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductOptionals_OptionalId",
                table: "Products",
                column: "OptionalId",
                principalTable: "ProductOptionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_SectionDescriptions_DescriptionId",
                table: "Sections",
                column: "DescriptionId",
                principalTable: "SectionDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_SectionTitles_TitleId",
                table: "Sections",
                column: "TitleId",
                principalTable: "SectionTitles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductOptionals_OptionalId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_SectionDescriptions_DescriptionId",
                table: "Sections");

            migrationBuilder.DropForeignKey(
                name: "FK_Sections_SectionTitles_TitleId",
                table: "Sections");

            migrationBuilder.DropTable(
                name: "SectionDescriptions");

            migrationBuilder.DropTable(
                name: "SectionTitles");

            migrationBuilder.DropIndex(
                name: "IX_Sections_DescriptionId",
                table: "Sections");

            migrationBuilder.DropIndex(
                name: "IX_Sections_TitleId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOptionals",
                table: "ProductOptionals");

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DropColumn(
                name: "DescriptionId",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Sections");

            migrationBuilder.RenameTable(
                name: "ProductOptionals",
                newName: "ProductOptional");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sections",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                defaultValue: "",
                comment: "The section's description");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Sections",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The section's title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOptional",
                table: "ProductOptional",
                column: "Id");

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

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био", "ОПИСАНИЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.", "ЗА СЪСТАВКИТЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", "УПОТРЕБА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Title" },
                values: new object[] { "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "ИЗПАЩАНЕ И ДОСТАВКА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio", "СЪСТАВ, INCI" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био", "ОПИСАНИЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава", "ЗА СЪСТАВКИТЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.", "УПОТРЕБА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Title" },
                values: new object[] { "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "ИЗПАЩАНЕ И ДОСТАВКА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%", "СЪСТАВ, INCI" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Description", "Title" },
                values: new object[] { "", "ОПИСАНИЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n \r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n \r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n \r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n \r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n \r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n \r\n*Био", "ЗА СЪСТАВКИТЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n \r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n \r\nИли върхъ суха кожа, за да я защитите.\r\n \r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", "УПОТРЕБА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Title" },
                values: new object[] { "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "ИЗПАЩАНЕ И ДОСТАВКА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n*Bio", "СЪСТАВ, INCI" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n \r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n \r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n \r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n \r\nВ удобно шишенце с попма за лесно използване.\r\n \r\n100% натурална\r\n94% от България", "ОПИСАНИЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n \r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n \r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n \r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n \r\nЕтерично масло грейпфрут - лек цитрусов аромат", "ЗА СЪСТАВКИТЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Разклаете преди употреба.\r\n \r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.", "УПОТРЕБА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Description", "Title" },
                values: new object[] { "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "ИЗПАЩАНЕ И ДОСТАВКА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n*Био", "СЪСТАВ, INCI" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n \r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n \r\n100% натурален\r\n45.7 % от България\r\n44.5% био", "ОПИСАНИЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n \r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n \r\nВитамин Е има антиоксидантен ефект.\r\n \r\nА цялата комбинация от съставки държи неприятните миризми далеч.", "ЗА СЪСТАВКИТЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.", "УПОТРЕБА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "Description", "Title" },
                values: new object[] { "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "ИЗПАЩАНЕ И ДОСТАВКА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil*, Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Компоненти на етерини масла", "СЪСТАВ, INCI" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n \r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n \r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\nНекомедогенен.\r\nНай-подходящ за суха кожа.\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\nПодхранва, заздравява и защитава кожната бариера.\r\n \r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n \r\n100% натурален\r\n80% от България\r\n31% био", "ОПИСАНИЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Масло от шипка - помога ревитализирането на кожата \r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n*Био", "ЗА СЪСТАВКИТЕ" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n \r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.", "УПОТРЕБА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Title" },
                values: new object[] { "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.", "ИЗПАЩАНЕ И ДОСТАВКА" });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Title" },
                values: new object[] { "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла", "СЪСТАВ, INCI" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductOptional_OptionalId",
                table: "Products",
                column: "OptionalId",
                principalTable: "ProductOptional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
