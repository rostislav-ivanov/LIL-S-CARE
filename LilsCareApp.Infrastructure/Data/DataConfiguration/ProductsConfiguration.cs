using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LilsCareApp.Infrastructure.Data.DataConfiguration
{
    internal class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly IEnumerable<Product> products = new List<Product>
        {
                new Product
                {
                    Id = 1,
                    Name = "СКРАБ ЗА ТЯЛО",
                    Price = 9.00m,
                    Quantity = 10,
                    Weight = "150 г",
                    Purpose = "<p>Изцяло натурален, може да използвате 1-2 пъти седмично, когато желаете нежно да ексфолирате кожата и да я направите по-мека и гладка.</p>\r\n<p>Използвайте с чисти ръце върху чиста и мокра кожа. Нежно масажирайте за ексфолиращ ефект. Изплакнете.</p>\r\n<p>Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, защитено от пряка слънчева светлина.</p> ",
                    Description = "<p>Част от лимитирана колекция празнични продукти, които може да закупите поотделно или като подаръчен комплект. 💝</p><p>Захарен скраб за тяло - натурален, био и ръчно изработен, с аромат на топли и уютни празници - стествен шоколадов аромат и леко цитрусов от етерично масло сладък портокал.</p><p>💛Този сладък скраб за тяло в два цвята е домашно приготвен с любов, масло от гроздови семки и какаово масло. Цвета му е натуралне от червена мика (минерален пигмент). Този скраб е прекрасен подарък за всеки, който се нуждае от малко повече релаксиращи моменти и грижа за себе си този сезон.</p><p>Обогатен с витамин Е.</p><p class=\"mb-0\">100% натурален</p><p class=\"mb-0\">86% от България</p><p class=\"mb-0\">13% Био</p>",
                    IngredientINCIs = "<p>Sucrose (Захар), Vitis Vinifera Seed Oil (Масло от гроздови семки), Theobroma Cacao Seed Butter (Какаово масло)*, Stearic Acid , Citrus Sinensis (Портокал) Peel Oil*, Limonene**,\r\nLinalool**, Citral**, Benzyl Alcohol, Ethylhexylglycerin, Tocopherol (Vit E), Mica***, CI 77491***. *Био **Компоненти на етерични масла ***Минерални пигменти От България 81,4% Био 14,5%</p>",
                    Ingredients = "<p><strong>Какаовото масло* </strong>- придава лек и естествен шоколадов аромат и предпазва и подхранва кожата.</p>\r\n<p><strong>Етеричното масло от сладък </strong>- портокал придават лек празничен аромат*.</p>\r\n<p><strong>Масло от гроздови семки </strong>- подхранва кожата. То е леко, некомедогенно и попива бързо.</p>\r\n<p><strong>Стеаринова киселина </strong>- наситена мастна 'киселина' която в природата се намира в много масла. В натуралния състав на какаовото масло е 24-37%, а в масло от шеа / карите е между 20-50%.</p>\r\n<p><strong>Витамин Е </strong>- натурален антиоксидант, който предпазва и защитава кожата от свободни радикали, процеси на оксидация и вредни влияния от околната среда.</p>\r\n<p>*Био</p>"
                },
                new Product
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Price = 4.00m,
                    Weight = "200g",
                    Quantity = 20,
                    Purpose = "Purpose 2",
                    Description = "Description 2",
                    IngredientINCIs = "IngredientINCIs 2",
                    Ingredients = "Ingredients 2"
                },
                new Product
                {
                    Id = 3,
                    Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА",
                    Price = 12.00m,
                    Weight = "50 g",
                    Quantity = 30,
                    Purpose = "Purpose 3",
                    Description = "Description 3",
                    IngredientINCIs = "IngredientINCIs 3",
                    Ingredients = "Ingredients 3"
                },
                new Product
                {
                    Id = 4,
                    Name = "НЕЖЕН ЛОСИОН С НЕВЕН",
                    Price = 4.00m,
                    Weight = "400g",
                    Quantity = 0,
                    Purpose = "Purpose 4",
                    Description = "Description 4",
                    IngredientINCIs = "IngredientINCIs 4",
                    Ingredients = "Ingredients 4"
                },
                new Product
                {
                    Id = 5,
                    Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА",
                    Price = 10.00m,
                    Weight = "100 мл",
                    Quantity = 50,
                    Purpose = "Purpose 5",
                    Description = "Description 5",
                    IngredientINCIs = "IngredientINCIs 5",
                    Ingredients = "Ingredients 5"
                },
                new Product
                {
                    Id = 6,
                    Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                    Price = 8.50m,
                    Weight = "50 g",
                    Quantity = 70,
                    Purpose = "Purpose 6",
                    Description = "Description 6",
                    IngredientINCIs = "IngredientINCIs 6",
                    Ingredients = "Ingredients 6"
                },
                new Product
                {
                    Id = 7,
                    Name = "СЕРУМ МАСЛО С ШИПКА И ЖОЖОБА",
                    Price = 9.00m,
                    Weight = "20 мл",
                    Quantity = 80,
                    Purpose = "Purpose 7",
                    Description = "Description 7",
                    IngredientINCIs = "IngredientINCIs 7",
                    Ingredients = "Ingredients 7"
                }
        };

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(products);
        }
    }
}