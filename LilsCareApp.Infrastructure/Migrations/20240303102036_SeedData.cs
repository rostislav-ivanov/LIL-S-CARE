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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 0, "f06c1f75-df85-4e5a-b5b6-f77d542c65d1", null, false, null, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAIAAYagAAAAEPGbd3rUeJPvsl+v6zGa8LTOoV+ITsW8e7mmJSxRMAwIW0a/RjMHAwFthfE4s6JEWQ==", null, false, "1f523c6d-e30c-4feb-ae02-d090aa90c1f5", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Всички" },
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
                columns: new[] { "Id", "Description", "IngredientINCIs", "Ingredients", "Name", "Price", "Purpose", "Quantity", "Weight" },
                values: new object[,]
                {
                    { 1, "Част от лимитирана колекция празнични продукти, които може да закупите поотделно или като подаръчен комплект. 💝\r\n\r\n \r\n\r\nЗахарен скраб за тяло - натурален, био и ръчно изработен, с аромат на топли и уютни празници - естествен шоколадов аромат и леко цитрусов от етерично масло сладък портокал. \r\n\r\n💛Този сладък скраб за тяло в два цвята е домашно приготвен с любов, масло от гроздови семки и какаово масло. Цвета му е натуралне от червена мика (минерален пигмент). Този скраб е прекрасен подарък за всеки, който се нуждае от малко повече релаксиращи моменти и грижа за себе си този сезон.\r\n\r\n \r\n\r\nОбогатен с витамин Е.\r\n\r\n \r\n\r\n100% натурален\r\n\r\n86% от България\r\n\r\n13% Био", "Sucrose (Захар), Vitis Vinifera Seed Oil (Масло от гроздови семки), Theobroma Cacao Seed Butter (Какаово масло)*, Stearic Acid , Citrus Sinensis (Портокал) Peel Oil*, Limonene**, Linalool**, Citral**, Benzyl Alcohol, Ethylhexylglycerin, Tocopherol (Vit E), Mica***, CI 77491***.\r\n\r\n*Био **Компоненти на етерични масла ***Минерални пигменти\r\n\r\nОт България 81,4%\r\n\r\nБио 14,5%", "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва и подхранва кожата.\r\n\r\n \r\n\r\nЕтеричното масло от сладък портокал придават лек празничен аромат*.\r\n\r\n \r\n\r\nМасло от гроздови семки - подхранва кожата. То е леко, некомедогенно и попива бързо.\r\n\r\n \r\n\r\nСтеаринова киселина - наситена мастна 'киселина' която в природата се намира в много масла. В натуралния състав на какаовото масло е 24-37%, а в масло от шеа / карите е между 20-50%.\r\n\r\n \r\n\r\nВитамин Е е натурален антиоксидант, който предпазва и защитава кожата от свободни радикали, процеси на оксидация и вредни влияния от околната среда.\r\n\r\n \r\n\r\n*Био", "СКРАБ ЗА ТЯЛО", 9.00m, "Изцяло натурален, може да използвате 1-2 пъти седмично, когато желаете нежно да ексфолирате кожата и да я направите по-мека и гладка.\r\n\r\n \r\n\r\nИзползвайте с чисти ръце върху чиста и мокра кожа. Нежно масажирайте за ексфолиращ ефект. Изплакнете.\r\n\r\n \r\n\r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, защитено от пряка слънчева светлина.", 10, "150 г" },
                    { 2, "Description 2", "IngredientINCIs 2", "Ingredients 2", "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК", 4.00m, "Purpose 2", 20, "200g" },
                    { 3, "Description 3", "IngredientINCIs 3", "Ingredients 3", "ХИДРАТИРАЩ КРЕМ С ШИПКА", 12.00m, "Purpose 3", 30, "50 g" },
                    { 4, "Description 4", "IngredientINCIs 4", "Ingredients 4", "НЕЖЕН ЛОСИОН С НЕВЕН", 4.00m, "Purpose 4", 0, "400g" },
                    { 5, "Description 5", "IngredientINCIs 5", "Ingredients 5", "ДВУФАЗНА МИЦЕЛАРНА ВОДА", 10.00m, "Purpose 5", 50, "100 мл" },
                    { 6, "Description 6", "IngredientINCIs 6", "Ingredients 6", "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ", 8.50m, "Purpose 6", 70, "50 g" },
                    { 7, "Description 7", "IngredientINCIs 7", "Ingredients 7", "СЕРУМ МАСЛО С ШИПКА И ЖОЖОБА", 9.00m, "Purpose 7", 80, "20 мл" }
                });

            migrationBuilder.InsertData(
                table: "ShippingProviders",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "2-3 работни дни", "До офис Еконт / Спиди", 6.50m },
                    { 2, "2-3 работни дни", "До адрес - Еконт", 8.50m }
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
                    { 1, "bul. Vitosha", "1ace6aef-5444-4e08-a62a-7d805d68d113", "Bulgaria", "Sofia", "Ivan", "Ivanov", "0888888888", "1000", "Sofia" },
                    { 2, "bul. Vitosha", "1ace6aef-5444-4e08-a62a-7d805d68d113", "Bulgaria", "Sofia", "Petar", "Petrov", "0888888888", "1000", "Sofia" }
                });

            migrationBuilder.InsertData(
                table: "BagsUsers",
                columns: new[] { "AppUserId", "ProductId" },
                values: new object[,]
                {
                    { "1ace6aef-5444-4e08-a62a-7d805d68d113", 1 },
                    { "1ace6aef-5444-4e08-a62a-7d805d68d113", 2 },
                    { "1ace6aef-5444-4e08-a62a-7d805d68d113", 3 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AppUserId", "ImagePath", "ProductId", "ReviewId" },
                values: new object[,]
                {
                    { 1, null, "https://static.wixstatic.com/media/a6694c_24a7b0d7f63d42048f5a05e97362f385~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_24a7b0d7f63d42048f5a05e97362f385~mv2.jpg", 1, null },
                    { 2, null, "https://static.wixstatic.com/media/a6694c_263e877cdb774516bea29e2155049a0d~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_263e877cdb774516bea29e2155049a0d~mv2.jpg", 1, null },
                    { 3, null, "https://static.wixstatic.com/media/a6694c_69a0f0f6f1cf4847983b2248749af6cc~mv2.jpg/v1/fill/w_301,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_69a0f0f6f1cf4847983b2248749af6cc~mv2.jpg", 1, null },
                    { 4, null, "https://static.wixstatic.com/media/a6694c_57415abd6b2b4d1f86e4ed35cf155e0d~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_57415abd6b2b4d1f86e4ed35cf155e0d~mv2.jpg", 1, null },
                    { 5, null, "https://video.wixstatic.com/video/a6694c_b61f40bc476a43578be260fce9fa6efa/1080p/mp4/file.mp4", 1, null },
                    { 6, null, "https://static.wixstatic.com/media/a6694c_75d8524a8fb046db82d0090671364c15~mv2.jpg/v1/fill/w_886,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_75d8524a8fb046db82d0090671364c15~mv2.jpg", 2, null },
                    { 7, null, "https://static.wixstatic.com/media/a6694c_2f611f06e55346e5b3b22c94c0bb8077~mv2.jpg/v1/fill/w_887,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_2f611f06e55346e5b3b22c94c0bb8077~mv2.jpg", 2, null },
                    { 8, null, "https://static.wixstatic.com/media/a6694c_1b60760d6a9e46f6ba0be663ab0cd432~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_1b60760d6a9e46f6ba0be663ab0cd432~mv2.jpg", 2, null },
                    { 9, null, "https://static.wixstatic.com/media/a6694c_7ce163b0f3e4461d9ee3ef5c16b972f4~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_7ce163b0f3e4461d9ee3ef5c16b972f4~mv2.jpg", 2, null },
                    { 10, null, "https://static.wixstatic.com/media/a6694c_8cf53b5caa60466b86d7e1e71035a5c1~mv2.jpg/v1/fill/w_886,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_8cf53b5caa60466b86d7e1e71035a5c1~mv2.jpg", 2, null },
                    { 11, null, "https://static.wixstatic.com/media/a6694c_dbfcc272e90a48f89dfa6930ee2b0355~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_dbfcc272e90a48f89dfa6930ee2b0355~mv2.jpg", 2, null },
                    { 12, null, "https://static.wixstatic.com/media/a6694c_44172c09d7974734aed4b4fa6474bac2~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_44172c09d7974734aed4b4fa6474bac2~mv2.jpg", 2, null },
                    { 13, null, "https://video.wixstatic.com/video/a6694c_688be81645b14d1f9707a985aad784fb/1080p/mp4/file.mp4", 2, null },
                    { 14, null, "https://static.wixstatic.com/media/a6694c_40945dc6b1754f74ab2b9331a5d4c692~mv2.jpg/v1/fill/w_887,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_40945dc6b1754f74ab2b9331a5d4c692~mv2.jpg", 3, null },
                    { 15, null, "https://static.wixstatic.com/media/a6694c_dcb7369410054c2b8ffc9fa2f7a7854c~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_dcb7369410054c2b8ffc9fa2f7a7854c~mv2.jpg", 3, null },
                    { 16, null, "https://static.wixstatic.com/media/a6694c_5e4516f6b7294324b75d8577ed3b7112~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_5e4516f6b7294324b75d8577ed3b7112~mv2.jpg", 3, null },
                    { 17, null, "https://static.wixstatic.com/media/a6694c_955cfb52005d4979a9d170045f3bf603~mv2.jpg/v1/fill/w_374,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_955cfb52005d4979a9d170045f3bf603~mv2.jpg", 3, null },
                    { 18, null, "https://static.wixstatic.com/media/a6694c_22c2642fbcb14b9c83a1b7b5349cb654~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_22c2642fbcb14b9c83a1b7b5349cb654~mv2.png", 3, null },
                    { 19, null, "https://static.wixstatic.com/media/a6694c_9feeef67f1174acb9d05de346a5380f3~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_9feeef67f1174acb9d05de346a5380f3~mv2.png", 4, null },
                    { 20, null, "https://static.wixstatic.com/media/a6694c_331b7666ec214d1cb9eab348b23156e6~mv2.png/v1/fill/w_832,h_665,al_c,usm_0.66_1.00_0.01/a6694c_331b7666ec214d1cb9eab348b23156e6~mv2.png", 4, null },
                    { 21, null, "https://static.wixstatic.com/media/a6694c_8c8ef3eb0c7b4c009a08aecabee93d26~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_8c8ef3eb0c7b4c009a08aecabee93d26~mv2.png", 4, null },
                    { 22, null, "https://static.wixstatic.com/media/a6694c_f3173997361b4b1b83ad90f807bbaf85~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_f3173997361b4b1b83ad90f807bbaf85~mv2.png", 4, null },
                    { 23, null, "https://static.wixstatic.com/media/a6694c_6180737a52184e20a160a44b8b00cbc6~mv2.png/v1/fill/w_832,h_665,al_c,usm_0.66_1.00_0.01/a6694c_6180737a52184e20a160a44b8b00cbc6~mv2.png", 4, null },
                    { 24, null, "https://static.wixstatic.com/media/a6694c_0d7a1d6d29d0432b85ad84001ad13a9b~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_0d7a1d6d29d0432b85ad84001ad13a9b~mv2.png", 4, null },
                    { 25, null, "https://static.wixstatic.com/media/a6694c_2485f5b6aa434f04a31a359a58f370ce~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_2485f5b6aa434f04a31a359a58f370ce~mv2.png", 4, null },
                    { 26, null, "https://video.wixstatic.com/video/a6694c_84516f7e298844d7954c342ceedba433/1080p/mp4/file.mp4", 4, null },
                    { 27, null, "https://static.wixstatic.com/media/a6694c_c3e384c8ca434dc6b7c2920f660579e3~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c3e384c8ca434dc6b7c2920f660579e3~mv2.png", 5, null },
                    { 28, null, "https://static.wixstatic.com/media/a6694c_c4aefe2a5f294a0faf6a2f7c19af32db~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c4aefe2a5f294a0faf6a2f7c19af32db~mv2.png", 5, null },
                    { 29, null, "https://static.wixstatic.com/media/a6694c_a730f2e789864a9cb75ce1dde1e52b07~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_a730f2e789864a9cb75ce1dde1e52b07~mv2.png", 5, null },
                    { 30, null, "https://static.wixstatic.com/media/a6694c_35eeecadd7f6495c99a3db846af81148~mv2.jpg/v1/fill/w_499,h_665,al_c,q_85,usm_0.66_1.00_0.01/a6694c_35eeecadd7f6495c99a3db846af81148~mv2.jpg", 5, null },
                    { 31, null, "https://video.wixstatic.com/video/a6694c_5b80835e03c94fd6b720fdd2ceaa8865/1080p/mp4/file.mp4", 5, null },
                    { 32, null, "https://static.wixstatic.com/media/a6694c_e95ca1c8158d4caba5b6e7bedaa0eeab~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_e95ca1c8158d4caba5b6e7bedaa0eeab~mv2.png", 6, null },
                    { 33, null, "https://static.wixstatic.com/media/a6694c_6381e01ae9c340d598e09ea221ff60f2~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_6381e01ae9c340d598e09ea221ff60f2~mv2.png", 6, null },
                    { 34, null, "https://static.wixstatic.com/media/a6694c_48c50850bac34de3911eb25953af593d~mv2.png/v1/fill/w_831,h_665,al_c,usm_0.66_1.00_0.01/a6694c_48c50850bac34de3911eb25953af593d~mv2.png", 6, null },
                    { 35, null, "https://static.wixstatic.com/media/a6694c_757ebf6a259740c19feb8b3a9a6bc8f5~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_757ebf6a259740c19feb8b3a9a6bc8f5~mv2.png", 6, null },
                    { 36, null, "https://static.wixstatic.com/media/a6694c_dcd9e99fe4d44425b1f77612e83ac7c3~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_dcd9e99fe4d44425b1f77612e83ac7c3~mv2.png", 7, null },
                    { 37, null, "https://static.wixstatic.com/media/a6694c_2fa731434bbc41df95694781b5de4092~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_2fa731434bbc41df95694781b5de4092~mv2.png", 7, null },
                    { 38, null, "https://static.wixstatic.com/media/a6694c_1a21a0325bd2422081c51946789b8adf~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_1a21a0325bd2422081c51946789b8adf~mv2.png", 7, null },
                    { 39, null, "https://static.wixstatic.com/media/a6694c_f5e3c9c920fe41f395dc3bbb35e0161d~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_f5e3c9c920fe41f395dc3bbb35e0161d~mv2.png", 7, null },
                    { 40, null, "https://static.wixstatic.com/media/a6694c_ec1aa69e21ac48dc9cfd0bf0522f8caa~mv2.png/v1/fill/w_532,h_665,al_c,usm_0.66_1.00_0.01/a6694c_ec1aa69e21ac48dc9cfd0bf0522f8caa~mv2.png", 7, null },
                    { 41, null, "https://video.wixstatic.com/video/a6694c_8570c70283b14cce830d5da15331979c/480p/mp4/file.mp4", 7, null },
                    { 42, null, "https://video.wixstatic.com/video/a6694c_3e25a17da1ba451786a46aa4daee1698/480p/mp4/file.mp4", 7, null },
                    { 43, null, "https://static.wixstatic.com/media/a6694c_c198248097424ec09f04d600b3ee3a40~mv2.png/v1/fill/w_886,h_665,al_c,usm_0.66_1.00_0.01/a6694c_c198248097424ec09f04d600b3ee3a40~mv2.png", 7, null }
                });

            migrationBuilder.InsertData(
                table: "ProductsCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "AppUserId", "AuthorName", "Comment", "CreatedOn", "Email", "ProductId", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "1ace6aef-5444-4e08-a62a-7d805d68d113", "John Doe", "Great product, I love it!", new DateTime(2024, 3, 3, 12, 20, 34, 351, DateTimeKind.Local).AddTicks(8576), "john@doe.com", 1, 4, "Great product" },
                    { 2, "1ace6aef-5444-4e08-a62a-7d805d68d113", "John Doe 2", "Great product, I love it!", new DateTime(2024, 3, 3, 12, 20, 34, 351, DateTimeKind.Local).AddTicks(8673), "john@doe.com", 1, 3, "Great product" },
                    { 3, "1ace6aef-5444-4e08-a62a-7d805d68d113", "John Doe 3", "Great product, I love it!", new DateTime(2024, 3, 3, 12, 20, 34, 351, DateTimeKind.Local).AddTicks(8677), "john@doe.com", 2, 3, "Great product" }
                });

            migrationBuilder.InsertData(
                table: "WishesUsers",
                columns: new[] { "AppUserId", "ProductId" },
                values: new object[,]
                {
                    { "1ace6aef-5444-4e08-a62a-7d805d68d113", 1 },
                    { "1ace6aef-5444-4e08-a62a-7d805d68d113", 3 },
                    { "1ace6aef-5444-4e08-a62a-7d805d68d113", 4 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressDeliveryId", "AppUserId", "CreatedOn", "DateShipping", "PaymentMethodId", "ShippingProviderId", "StatusOrderId", "TrackingNumber" },
                values: new object[,]
                {
                    { 1, 1, "1ace6aef-5444-4e08-a62a-7d805d68d113", new DateTime(2024, 3, 3, 10, 20, 32, 817, DateTimeKind.Utc).AddTicks(6142), new DateTime(2024, 3, 3, 10, 20, 32, 817, DateTimeKind.Utc).AddTicks(7669), 1, 1, 1, "1234567890" },
                    { 2, 2, "1ace6aef-5444-4e08-a62a-7d805d68d113", new DateTime(2024, 3, 3, 10, 20, 32, 818, DateTimeKind.Utc).AddTicks(7547), new DateTime(2024, 3, 3, 10, 20, 32, 818, DateTimeKind.Utc).AddTicks(7553), 2, 2, 2, "1234567890x" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 1 });

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 2 });

            migrationBuilder.DeleteData(
                table: "BagsUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 3 });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Images",
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
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductsCategories",
                keyColumns: new[] { "CategoryId", "ProductId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

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
                keyValues: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 1 });

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 3 });

            migrationBuilder.DeleteData(
                table: "WishesUsers",
                keyColumns: new[] { "AppUserId", "ProductId" },
                keyValues: new object[] { "1ace6aef-5444-4e08-a62a-7d805d68d113", 4 });

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
                table: "ShippingProviders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShippingProviders",
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
                keyValue: "1ace6aef-5444-4e08-a62a-7d805d68d113");
        }
    }
}
