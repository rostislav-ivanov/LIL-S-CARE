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
            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is the product show on online store");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultAddressDeliveryId", "Email", "EmailConfirmed", "FirstName", "ImagePath", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 0, "71813380-c3f5-4766-83a1-2ef768732c12", null, null, false, null, null, null, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEFKm2jIULvp9FQtblOeg2jVt8XOQRpHTbZ/SUzdkuo8Vj73PdHmO40r5BI9SM+SIbA==", null, false, "d03e385c-4ca5-4e9f-9e98-4219183f644a", false, "test@softuni.bg" });

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
                columns: new[] { "Id", "Description", "IngredientINCIs", "Ingredients", "IsShow", "Name", "Price", "Purpose", "Quantity", "Weight" },
                values: new object[,]
                {
                    { 1, "<p>Част от лимитирана колекция празнични продукти, които може да закупите поотделно или като подаръчен комплект. 💝</p><p>Захарен скраб за тяло - натурален, био и ръчно изработен, с аромат на топли и уютни празници - стествен шоколадов аромат и леко цитрусов от етерично масло сладък портокал.</p><p>💛Този сладък скраб за тяло в два цвята е домашно приготвен с любов, масло от гроздови семки и какаово масло. Цвета му е натуралне от червена мика (минерален пигмент). Този скраб е прекрасен подарък за всеки, който се нуждае от малко повече релаксиращи моменти и грижа за себе си този сезон.</p><p>Обогатен с витамин Е.</p><p class=\"mb-0\">100% натурален</p><p class=\"mb-0\">86% от България</p><p class=\"mb-0\">13% Био</p>", "<p>Sucrose (Захар), Vitis Vinifera Seed Oil (Масло от гроздови семки), Theobroma Cacao Seed Butter (Какаово масло)*, Stearic Acid , Citrus Sinensis (Портокал) Peel Oil*, Limonene**,\r\nLinalool**, Citral**, Benzyl Alcohol, Ethylhexylglycerin, Tocopherol (Vit E), Mica***, CI 77491***. *Био **Компоненти на етерични масла ***Минерални пигменти От България 81,4% Био 14,5%</p>", "<p><strong>Какаовото масло* </strong>- придава лек и естествен шоколадов аромат и предпазва и подхранва кожата.</p>\r\n<p><strong>Етеричното масло от сладък </strong>- портокал придават лек празничен аромат*.</p>\r\n<p><strong>Масло от гроздови семки </strong>- подхранва кожата. То е леко, некомедогенно и попива бързо.</p>\r\n<p><strong>Стеаринова киселина </strong>- наситена мастна 'киселина' която в природата се намира в много масла. В натуралния състав на какаовото масло е 24-37%, а в масло от шеа / карите е между 20-50%.</p>\r\n<p><strong>Витамин Е </strong>- натурален антиоксидант, който предпазва и защитава кожата от свободни радикали, процеси на оксидация и вредни влияния от околната среда.</p>\r\n<p>*Био</p>", true, "СКРАБ ЗА ТЯЛО", 9.00m, "<p>Изцяло натурален, може да използвате 1-2 пъти седмично, когато желаете нежно да ексфолирате кожата и да я направите по-мека и гладка.</p>\r\n<p>Използвайте с чисти ръце върху чиста и мокра кожа. Нежно масажирайте за ексфолиращ ефект. Изплакнете.</p>\r\n<p>Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, защитено от пряка слънчева светлина.</p> ", 10, "150 г" },
                    { 2, "Description 2", "IngredientINCIs 2", "Ingredients 2", true, "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", 4.00m, "Purpose 2", 20, "200g" },
                    { 3, "Description 3", "IngredientINCIs 3", "Ingredients 3", true, "ХИДРАТИРАЩ КРЕМ С ШИПКА", 12.00m, "Purpose 3", 30, "50 g" },
                    { 4, "Description 4", "IngredientINCIs 4", "Ingredients 4", true, "НЕЖЕН ЛОСИОН С НЕВЕН", 4.00m, "Purpose 4", 0, "400g" },
                    { 5, "Description 5", "IngredientINCIs 5", "Ingredients 5", true, "ДВУФАЗНА МИЦЕЛАРНА ВОДА", 10.00m, "Purpose 5", 50, "100 мл" },
                    { 6, "Description 6", "IngredientINCIs 6", "Ingredients 6", true, "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", 8.50m, "Purpose 6", 70, "50 g" },
                    { 7, "Description 7", "IngredientINCIs 7", "Ingredients 7", true, "СЕРУМ МАСЛО С ШИПКА И ЖОЖОБА", 9.00m, "Purpose 7", 80, "20 мл" }
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
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 1, 2 },
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 2, 3 },
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 3, 4 }
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
                table: "PromoCodes",
                columns: new[] { "Id", "AppUserId", "AppliedDate", "Code", "Discount", "ExpirationDate" },
                values: new object[,]
                {
                    { 1, "4ae56886-4229-49e3-a6ae-96ee6e340c4a", null, "-10 % за регистрация", 0.1m, new DateTime(2025, 3, 29, 15, 58, 55, 578, DateTimeKind.Utc).AddTicks(6793) },
                    { 2, "4ae56886-4229-49e3-a6ae-96ee6e340c4a", null, "-20 % отстъпка", 0.2m, new DateTime(2025, 3, 29, 15, 58, 55, 578, DateTimeKind.Utc).AddTicks(6802) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "AuthorId", "ProductId", "Comment", "CreatedOn", "Rating", "Title" },
                values: new object[,]
                {
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 2, "Great product, I love it!", new DateTime(2024, 3, 29, 17, 58, 55, 578, DateTimeKind.Local).AddTicks(6244), 4, "Great product" },
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 3, "Great product, I love it!", new DateTime(2024, 3, 29, 17, 58, 55, 578, DateTimeKind.Local).AddTicks(6310), 3, "Great product" },
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 4, "Great product, I love it!", new DateTime(2024, 3, 29, 17, 58, 55, 578, DateTimeKind.Local).AddTicks(6314), 3, "Great product" }
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
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 1 },
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 3 },
                    { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 4 }
                });

            migrationBuilder.InsertData(
                table: "AddressDeliveries",
                columns: new[] { "Id", "Address", "AppUserId", "Country", "District", "Email", "FirstName", "IsShippingToOffice", "LastName", "PhoneNumber", "PostCode", "ShippingOfficeId", "Town" },
                values: new object[,]
                {
                    { 1, "bul. Vitosha", "4ae56886-4229-49e3-a6ae-96ee6e340c4a", "Bulgaria", "Sofia", null, "Ivan", false, "Ivanov", "0888888888", "1000", 1, "Sofia" },
                    { 2, "bul. Vitosha", "4ae56886-4229-49e3-a6ae-96ee6e340c4a", "Bulgaria", "Sofia", null, "Petar", false, "Petrov", "0888888888", "1000", 2, "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressDeliveryId", "AppUserId", "CreatedOn", "DateShipping", "Discount", "NoteForDelivery", "OrderNumber", "PaymentMethodId", "PromoCodeId", "ShippingPrice", "StatusOrderId", "SubTotal", "Total", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, 1, "4ae56886-4229-49e3-a6ae-96ee6e340c4a", new DateTime(2024, 3, 29, 15, 58, 55, 10, DateTimeKind.Utc).AddTicks(6987), new DateTime(2024, 3, 29, 15, 58, 55, 10, DateTimeKind.Utc).AddTicks(8194), 0m, null, null, 1, null, 0m, 1, 0m, 0m, "1234567890" },
                    { 2, 2, "4ae56886-4229-49e3-a6ae-96ee6e340c4a", new DateTime(2024, 3, 29, 15, 58, 55, 10, DateTimeKind.Utc).AddTicks(9378), new DateTime(2024, 3, 29, 15, 58, 55, 10, DateTimeKind.Utc).AddTicks(9381), 0m, null, null, 2, null, 0m, 2, 0m, 0m, "1234567890x" }
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
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 1 });

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 2 });

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 3 });

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
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ImageProducts",
                keyColumn: "Id",
                keyValue: 43);

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
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 2 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 3 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "AuthorId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 4 });

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
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 1 });

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 3 });

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "4ae56886-4229-49e3-a6ae-96ee6e340c4a", 4 });

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
                keyValue: "4ae56886-4229-49e3-a6ae-96ee6e340c4a");

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

            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "Products");
        }
    }
}
