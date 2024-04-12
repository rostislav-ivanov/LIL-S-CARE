using LilsCareApp.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using static LilsCareApp.Infrastructure.DataConstants.AdminConstants;

namespace LilsCareApp.Tests.SeedDb
{
    public class SeedData
    {
        public IEnumerable<AddressDelivery> AddressDeliveries = new List<AddressDelivery>
        {
            new AddressDelivery
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                PhoneNumber = "0888888888",
                PostCode = "1000",
                Address= "bul. Vitosha",
                Town = "Sofia",
                District = "Sofia",
                Country = "Bulgaria",
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
            new AddressDelivery
            {
                Id = 2,
                FirstName = "Petar",
                LastName = "Petrov",
                PhoneNumber = "0888888888",
                PostCode = "1000",
                Address= "bul. Vitosha",
                Town = "Sofia",
                District = "Sofia",
                Country = "Bulgaria",
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },

        };



        public IEnumerable<AppUser> Users = new List<AppUser>()
        {
            new AppUser
            {
                Id = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG",
                Email = "test@softuni.bg",
                NormalizedEmail = "TEST@SOFTUNI.BG",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "Testov",
                ImagePath = "/files/users/test-testov.jpg"
            },
            new AppUser
            {
                Id = "45fbe739-6be0-429d-b44b-1ce6cf7eeef",
                UserName = AdminEmail,
                NormalizedUserName = AdminEmail.ToUpper(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Adminov",
            }
        };

        public IEnumerable<IdentityRole> Roles =
        [
            new IdentityRole
            {
                Id = "1fad9b8a-7a81-4a37-90b1-2c47cefb9e0b",
                Name = AreaName,
                NormalizedName = AreaName.ToUpper(),
            }
        ];

        public IdentityUserRole<string> UserRole = new IdentityUserRole<string> { RoleId = "1fad9b8a-7a81-4a37-90b1-2c47cefb9e0b", UserId = "45fbe739-6be0-429d-b44b-1ce6cf7eeef" };


        public IEnumerable<BagUser> BagsUsers = new List<BagUser>
            {
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 1,
                    Quantity = 2
                },
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 2,
                    Quantity = 3
                },
                new BagUser
                {
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                    ProductId = 3,
                    Quantity = 4
                },

            };


        public IEnumerable<Category> Categories =
        [
            new () { Id = 1, Name = "всички" },
            new () { Id = 2, Name = "за тяло" },
            new () { Id = 3, Name = "за суха кожа" },
            new () { Id = 4, Name = "за мазна кожа" },
            new () { Id = 5, Name = "за лице" },
        ];


        public IEnumerable<ImageProduct> Images = new List<ImageProduct>()
        {

                new ImageProduct
                {
                    Id = 1,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 2,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 3,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 4,
                    ProductId = 1,
                    ImagePath = "/files/products/product-01-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 5,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 6,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 7,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 8,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 9,
                    ProductId = 2,
                    ImagePath = "/files/products/product-02-image-05.webp",
                    ImageOrder = 5
                },
                new ImageProduct
                {
                    Id = 10,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 11,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 12,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 13,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 14,
                    ProductId = 3,
                    ImagePath = "/files/products/product-03-image-05.webp",
                    ImageOrder = 5
                },
                new ImageProduct
                {
                    Id = 15,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 16,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 17,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 18,
                    ProductId = 4,
                    ImagePath = "/files/products/product-04-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 19,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 20,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 21,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 22,
                    ProductId = 5,
                    ImagePath = "/files/products/product-05-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 23,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-01.webp",
                    ImageOrder = 1
                },
                new ImageProduct
                {
                    Id = 24,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-02.webp",
                    ImageOrder = 2
                },
                new ImageProduct
                {
                    Id = 25,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-03.webp",
                    ImageOrder = 3
                },
                new ImageProduct
                {
                    Id = 26,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-04.webp",
                    ImageOrder = 4
                },
                new ImageProduct
                {
                    Id = 27,
                    ProductId = 6,
                    ImagePath = "/files/products/product-06-image-05.webp",
                    ImageOrder = 5
                },

        };


        public IEnumerable<Order> Orders = new List<Order>
        {
           new Order
            {
                Id = 1,
                OrderNumber = "123456",
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 1,
                AddressDeliveryId = 1,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                DateShipping = DateTime.UtcNow,
                TrackingNumber = "1234567890",
                PaymentMethodId = 1,
            },
          new Order
             {
                Id = 2,
                OrderNumber = "123456x",
                CreatedOn = DateTime.UtcNow,
                StatusOrderId = 2,
                AddressDeliveryId = 2,
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
                DateShipping = DateTime.UtcNow,
                TrackingNumber = "1234567890x",
                PaymentMethodId = 2,
             },
        };



        public IEnumerable<PaymentMethod> PaymentMethods = new List<PaymentMethod>
        {
            new PaymentMethod { Id = 1, Type = "Наложен платеж" },
            new PaymentMethod { Id = 2, Type = "С карта" },
            new PaymentMethod { Id = 3, Type = "Банков превод" }
        };


        public IEnumerable<ProductCategory> ProductsCategories =
        [
            new () { ProductId = 1,CategoryId = 1},
            new () { ProductId = 2,CategoryId = 1},
            new () { ProductId = 3,CategoryId = 1},
            new () { ProductId = 4,CategoryId = 1},
            new () { ProductId = 5,CategoryId = 1},
            new () { ProductId = 6,CategoryId = 1},
            new () { ProductId = 1,CategoryId = 2},
            new () { ProductId = 1,CategoryId = 3},
            new () { ProductId = 2,CategoryId = 3},
            new () { ProductId = 2,CategoryId = 4},
            new () { ProductId = 3,CategoryId = 5},
            new () { ProductId = 4,CategoryId = 2},
            new () { ProductId = 4,CategoryId = 3},
            new () { ProductId = 4,CategoryId = 5},
            new () { ProductId = 5,CategoryId = 3},
            new () { ProductId = 5,CategoryId = 5},
            new () { ProductId = 6,CategoryId = 3},
            new () { ProductId = 6,CategoryId = 4},

        ];



        public IEnumerable<Product> Products = new List<Product>
        {
                new Product
                {
                    Id = 1,
                    Name = "НАТУРАЛЕН СУХ ДЕЗОДОРАНТ",
                    Price = 5.50m,
                    Quantity = 10,
                    Optional = "Тегло:  25 г.",
                    IsShow = true,
                },
                new Product
                {
                    Id = 2,
                    Name = "БАЛСАМ ЗА УСТНИ С ЖОЖОБА, КАКАО И ПЧЕЛЕН ВОСЪК",
                    Price = 4.00m,
                    Optional = "Тегло:  5 г.",
                    Quantity = 20,
                    IsShow = true,
                },
                new Product
                {
                    Id = 3,
                    Name = "ХИДРАТИРАЩ КРЕМ С ШИПКА И НИАЦИНАМИД",
                    Price = 12.00m,
                    Optional = "Тегло:  50 г.",
                    Quantity = 30,
                    IsShow = true,
                },
                new Product
                {
                    Id = 4,
                    Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                    Price = 10.00m,
                    Optional = "Тегло:  100 мл.",
                    Quantity = 0,
                    IsShow = true,
                },
                new Product
                {
                    Id = 5,
                    Name = "НАТУРАЛЕН КРЕМ ДЕЗОДОРАНТ",
                    Price = 8.50m,
                   Optional = "Тегло:  50 г.",
                    Quantity = 10,
                    IsShow = true,
                },
                new Product
                {
                    Id = 6,
                    Name = "ДВУФАЗНА МИЦЕЛАРНА ВОДА ЗЕЛЕН ЧАЙ И ЖОЖОБА",
                    Price = 10.00m,
                    Optional = "Тегло:  20 мл.",
                    Quantity = 20,
                    IsShow = true,
                },
                new Product
                {
                    Id = 7,
                    Name = "",
                    Price = 10.00m,
                    Optional = "",
                    Quantity = 0,
                    IsShow = false,
                },

        };


        public IEnumerable<ProductOrder> ProductsOrders =
            [
            new ()
            {
                ProductId = 1,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 1,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 2,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 3,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 3,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 4,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 5,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 6,
                OrderId = 1,
            },
            new ()
            {
                ProductId = 6,
                OrderId = 2,
            },
            new ()
            {
                ProductId = 7,
                OrderId = 1,
            }
        ];



        public IEnumerable<PromoCode> PromoCodes = new List<PromoCode>
        {
            new PromoCode
            {
                Id = 1,
                Code = "-10 % за регистрация",
                Discount = 0.1m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
            new PromoCode
            {
                Id = 2,
                Code = "-20 % отстъпка",
                Discount = 0.2m,
                ExpirationDate = DateTime.UtcNow.AddMonths(12),
                AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
            },
        };


        public IEnumerable<Review> Reviews = new List<Review>
        {
            new Review
            {
                Rating = 4,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.ParseExact("28/10/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture),
                ProductId = 2,
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
            },
            new Review
            {
                Rating = 3,
                Title = "Great product",
                Comment = "Great product, I love it!",
                CreatedOn = DateTime.Now,
                ProductId = 4,
                AuthorId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef",
            },
        };


        public IEnumerable<Section> Sections = new List<Section>
        {
            new Section
            {
                Id = 1,
                Title = "ОПИСАНИЕ",
                Description = "Нежен, изцяло натурален и ръчно изработен сух дезодорант. Подходящ за ежедневна употреба.\r\n \r\nБез парфюм и без етерични масла.\r\n \r\nВ нов твърд вариант за по-лесна употеба и нансяне дирктно.\r\n \r\nИли може да използвате стара опаковка от стик дезодорант, за да разтопите блокчето за удобна ежедневна употреба.\r\n \r\nСрежете блокчето на парченца и ги сложете в стик опаковка. Иползвайте микровълнова фурна на ниска температура и за картки интервали докато блокечето се разтопи. Оставете да изстине и стегне и готово!\r\n \r\nАко не разполагате с микровълнова фурна, може да го разтопите на водна баня в стик. Увийете плътно стик опковката със стреч фолио, за да не влиза вода в опковката и при продукта.\r\n \r\n100% натурален\r\n10 % от България\r\n78.4% био",
                SectionOrder = 1,
                ProductId = 1
            },
            new Section
            {
                Id = 2,
                Title = "ЗА СЪСТАВКИТЕ",
                Description = "Сухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\nВитамин Е има антиоксидантен ефект.\r\nКокосово масло, масло от ший (карите) и пчелен восък.",
                SectionOrder = 2,
                ProductId = 1
            },
            new Section
            {
                Id = 3,
                Title = "УПОТРЕБА",
                Description = "Вземете блокчето от кутийката и намажете подмишничите.\r\n \r\nИли внимателно го разтопете в опаковка за стик дезодорант за по-лесна и удобна ежедневна употреба.\r\n \r\nМоже да преизползвате стара опаковка от предишен дезодорант.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.",
                SectionOrder = 3,
                ProductId = 1
            },
            new Section
            {
                Id = 4,
                Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                SectionOrder = 4,
                ProductId = 1
            },
            new Section
            {
                Id = 5,
                Title = "СЪСТАВ, INCI",
                Description = "Cocos Nucifera (Coconut) Oil*, Tapioca Starch*, Butyrospermum Parkii (Shea) Butter*, Cera Alba (Beeswax), Glyceryl Stearate, Sodium Bicarbonate, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil* \r\n*Bio",
                SectionOrder = 5,
                ProductId = 1
            },
            new Section
            {
                Id = 6,
                Title = "ОПИСАНИЕ",
                Description = "Изцяло натурален и ръчно изработен балсам за устни, който носи усещане за уют и мекота. Създаден да е нежен и защитаващ.\r\n \r\nБио какаово масло\r\nЕстствен каков аромат\r\nКомбиниран с натурално масло от ванилия\r\nПчелен восък\r\n \r\nВ два варианта:\r\nЛек и блестящ прозрачен цвят\r\nИзцяло безцветен\r\n \r\nОбогатен с витамин Е и био масло от жожоба.\r\n \r\n100% натурален\r\n49% от България\r\n41% био",
                SectionOrder = 1,
                ProductId = 2
            },
            new Section
            {
                Id = 7,
                Title = "ЗА СЪСТАВКИТЕ",
                Description = "Какаовото масло* придава лек и естествен шоколадов аромат и предпазва устните.\r\n \r\nМаслото от жожоба* ги подхранва.\r\n \r\nПчелния восък* защитава устните, прави балсама траен както върху устните така и в тубичката да не свършва бързо. Придава усещане за възглванича и мекота върху устните.\r\n \r\nВитамин Е - натурален антиоксидант, който защитава от вредните влияния от околната среда.\r\n \r\n*Био 41% от състава",
                SectionOrder = 2,
                ProductId = 2
            },
            new Section
            {
                Id = 8,
                Title = "УПОТРЕБА",
                Description = "Изцяло натурален, може да използвате винаги когато искате да подхраните и защитите устните си или просто да им придадете лек блясък за завършен вид на визията си.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте със затворено капаче, на сухо място и защитено от пряка слънчева светлина.",
                SectionOrder = 3,
                ProductId = 2
            },
            new Section
            {
                Id = 9,
                Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                SectionOrder = 4,
                ProductId = 2
            },
            new Section
            {
                Id = 10,
                Title = "СЪСТАВ, INCI",
                Description = "Apricot Kernel Oil (масло от кайсиеви ядки), Theobroma Cacao Seed Butter (какаово масло)*, Copernicia Cerifera Cera (Карнаубски восък, веган)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Helianthus Annuus Seed Oil (слънчогледово масло), Vanilla Planifolia Fruit Extract (екстракт от шушулки ванилия), Mica**, CI 77491 (Iron Oxide)**, Tocopherol (витамин E).\r\n*Био 49% **Минерални пигменти 1%",
                SectionOrder = 5,
                ProductId = 2
            },
            new Section
            {
                Id = 11,
                Title = "ОПИСАНИЕ",
                Description = "",
                SectionOrder = 1,
                ProductId = 3
            },
            new Section
            {
                Id = 12,
                Title = "ЗА СЪСТАВКИТЕ",
                Description = "Българско студено пресовано масло от шипка* - натурален източник на витамин А, подхранва и стимулура регенерирнето на кожата.\r\n \r\nЕкстракт от шипка - ботанически глицернов екстракт, който в този крем е чъдесна комбинация с маслото от шипка.\r\n \r\nМасло от ший* - Най-лекото и с най-нисък комедогенен рейтинг (0-2) от всички твърди масла. Това означава, че има ниска вероятност да запуши порите като скалата е от 0 до 5.\r\n \r\nВитамин B3 - ниацинамид - антиоксидант, който изравнява тена, регулира себума, помага худратацията и изглажда финни бръчки. Наистирна звучи неверояно, a е доакзрно.\r\n \r\nВитамин Е - има ефективо и естетвено антиоксидантно действие:  забвя стареенето като помага за възстановяването на кожата и я предпазва от свободните радикали и вредите от околната среда.\r\n \r\nРастителни глицерин и хиалурон - хумектанти - привличат водата и хидратират кожата. Ключова е концентрацията! Твърде много от тях могат да изсушат кожата, като започнат да издърпват влагата от по-дълбоките слоеве на кожата, когато въздуха е сух. Важен е баланса между вода и хумектанти в продукта.\r\n \r\n*Био",
                SectionOrder = 2,
                ProductId = 3
            },
            new Section
            {
                Id = 13,
                Title = "УПОТРЕБА",
                Description = "Нанесете върху суха или влажна кожа. Малко количество е достатъчно за цялото лице и шия. Използвайте 1-2 пъти дневно според необходимостта и сухотата на кожата.\r\n \r\nМоже да нансете върху влажна кожа, например след душ и измивен гел, за да заключите хидратацията.\r\n \r\nИли върхъ суха кожа, за да я защитите.\r\n \r\nНанасяйте върху добре почистена кожа с чисти ръце. Само за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.",
                SectionOrder = 3,
                ProductId = 3
            },
            new Section
            {
                Id = 14,
                Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                SectionOrder = 4,
                ProductId = 3
            },
            new Section
            {
                Id = 15,
                Title = "СЪСТАВ, INCI",
                Description = "Aqua (Вода), Rosa Canina Seed Oil* (масло от шипка, 10%) , Butyrospermum Parkii Butter* (масло от ший/карите), Glycerin (глицерин), Rosa Canina Fruit Extract (екстракт от шипка), Niacinamide (витамин B3), Cetearyl Olivate, Sorbitan Olivate (емулгатори), Sodium Hyaluronate (хиалуронова киселина), Tocopherol (витамин E), Helianthus Annuus (Слънчоглед) Seed Oil*, Sodium Benzoate, Potassium Sorbate (консерванти), Lactic Acid (млечна киселина, AHA, регулира pH на продукта).\r\n*Bio",
                SectionOrder = 5,
                ProductId = 3
            }
            ,
            new Section
            {
                Id = 16,
                Title = "ОПИСАНИЕ",
                Description = "Натурална мицеларна вода с два компонента. Разклатете преди употреба, за да се смесят двете фази. Идеална е за нежното отстраняване на грима в края на деня.\r\n \r\nИма двойно действие е като тоник за лице с екстракт от зелен чай и витамин Е.\r\n \r\nФаза 1 е изключително нежна. Има успокояващо и антиоксидантно действие благодарение на екстракта от зелен чай, сквален и пантенол (провитамин B3).\r\n \r\nФаза 2 е с био масло от жожоба и допринся за разтврянето на грима. Оставя кожата мека, подхранена и защитена.\r\n \r\nВ удобно шишенце с попма за лесно използване.\r\n \r\n100% натурална\r\n94% от България",
                SectionOrder = 1,
                ProductId = 4
            },
            new Section
            {
                Id = 17,
                Title = "ЗА СЪСТАВКИТЕ",
                Description = "Екстракт от зелен чай - антиоксидантно и успокояващо действе, помага против появата на акне\r\n \r\nБио масло от Жожоба - помага за нежното разтваряне на грима и подхранва кожата\r\n \r\nВитамин Е - антиоксидант, успокоява раздразненията, бори се със свободните радикали и забавя стареенето на кожата\r\n \r\nПантенол - провитамин B5 - с растителен прозход. Хидратира и подхранва\r\n \r\nЕтерично масло грейпфрут - лек цитрусов аромат",
                SectionOrder = 2,
                ProductId = 4
            },
            new Section
            {
                Id = 18,
                Title = "УПОТРЕБА",
                Description = "Разклаете преди употреба.\r\n \r\nМоже да използвате винаги, когато искате нежно да премахнете грима. Разклатете преди употреба и напоете памучно тампонче. Нежно притиснете към кожата, за да се намокри и да започне да разтваря грима. След това отстранете грима с леки движения от центъра на лицето към страните.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте на сухо място, защитено от пряка слънчева светлина.",
                SectionOrder = 3,
                ProductId = 4
            },
            new Section
            {
                Id = 19,
                Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                SectionOrder = 4,
                ProductId = 4
            },
            new Section
            {
                Id = 20,
                Title = "СЪСТАВ, INCI",
                Description = "Aqua, Vitis Vinifera (Grape) Seed Oil, Camellia Sinensis (Green Tea) Leaf Extract,  Glycerin, Caprylic / Capric Triglycerides (Fractioned Coconut Oil), Simmondsia Chinensis (Jojoba) Seed Oil*, D-panthenol (Provitamin B5, plant-based), Coco Glucoside, Squalane, Sodium Surfactin, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*, Potassium Sorbate, Sodium Benzoate, Benzyl Alcohol, Citric Acid, Citrus Paradisi (Grapefruit) Peel Oil, Limonene, Citral, Linalool.\r\n*Био",
                SectionOrder = 5,
                ProductId = 4
            }
            ,
            new Section
            {
                Id = 21,
                Title = "ОПИСАНИЕ",
                Description = "Нежен, изцяло натурален и ръчно изработен дезодорант. Подходящ за ежедневна употреба. Етеричните масла от сладък портокал и евкалипт придват лек цитрусов аромат.\r\n \r\nИзбрахме точно тези етерични масла не само заради приятния аромат. Те притежават и по-добър антибактериален фект спрямо повечето етерични масла. Дори пречат на развитието и на различни видове гъбички. Това ознчава, че натурално може да намали лошата миризма при потене, която е причинена от бактериите под мишниците.\r\n \r\n100% натурален\r\n45.7 % от България\r\n44.5% био",
                SectionOrder = 1,
                ProductId = 5
            },
            new Section
            {
                Id = 22,
                Title = "ЗА СЪСТАВКИТЕ",
                Description = "Етеричните масла от сладък портокал и евкалипт придават свеж, леко ментов цитрусов аромат и имат антибактериален ефект.\r\n \r\nСухите съставки като био тапиока поддържат подмишниците сухи през деня.\r\n \r\nВитамин Е има антиоксидантен ефект.\r\n \r\nА цялата комбинация от съставки държи неприятните миризми далеч.",
                SectionOrder = 2,
                ProductId = 5
            },
            new Section
            {
                Id = 23,
                Title = "УПОТРЕБА",
                Description = "Вземете на върха на пръстите много малко количесто (по-малко дори от грахово зрънце), леко го затоплете между пръстите и разнесете добре подмишниците.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Съхранявайте добре затворено на сухо място, защитено от пряка слънчева светлина.",
                SectionOrder = 3,
                ProductId = 5
            },
            new Section
            {
                Id = 24,
                Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                SectionOrder = 4,
                ProductId = 5
            },
            new Section
            {
                Id = 25,
                Title = "СЪСТАВ, INCI",
                Description = "Vitis Vinifera (Grape) Seed Oil, Tapioca Starch*, Theobroma Cacao (Cocoa) Seed Butter*, Copernicia Cerifera Cera (Carnauba Wax)*, Sodium Bicarbonate, Glyceryl Stearate, Citrus Sinensis (Orange) Peel Oil*, Eucalyptus Globulus Leaf Oil*, Limonene**, Linalool**, Citral**, Tocopherol (Vit E), Helianthus Annuus (Sunflower) Seed Oil*\r\n*Bio\r\n**Компоненти на етерини масла",
                SectionOrder = 5,
                ProductId = 5
            },
            new Section
            {
                Id = 26,
                Title = "ОПИСАНИЕ",
                Description = "Създаден, за да се поглезите - с био масла от: шипка, ягодови семки, арган и жожба. Подхранва и защитава кожата. Запазва хидратацията като предпазва кожата от загуба на вода и я оставя мека и гладка.\r\n \r\nОбогатен с витамин Е за добър антиоксидантен ефект, който предпазва клетките от вредното въздействие отоколната среда, свободните радикали и оксидативни процеси. По този начин поддържа кожата млада и елстична.\r\n \r\nМаслото от шипка е натурален източник на витамин А. Аргановото масло и маслото от ягодови семки подхранват кожата, а маслото от жожоба съдържа натурални серамиди, подсилват кожната бариера и заздравяват връзките между клетките.\r\n\r\nНекомедогенен.\r\nНай-подходящ за суха кожа.\r\nИли като защита след по-изтощаваща рутина, напр. след химичен пилинг.\r\nПодхранва, заздравява и защитава кожната бариера.\r\n \r\nИзползвате няколко капки върху суха или влажна кожа (на пример след душ) или след хидратиращ лосион, за да 'заклчючите' хидратацията и да защитите кожата. \r\n \r\n100% натурален\r\n80% от България\r\n31% био",
                SectionOrder = 1,
                ProductId = 6
            },
            new Section
            {
                Id = 27,
                Title = "ЗА СЪСТАВКИТЕ",
                Description = "Масло от шипка - помога ревитализирането на кожата \r\nМасло от ягодови семки - хидратира в дълбочина и има протививъзвпалителен ефект\r\nМасло от жожоба* - натурално съдържа над 95% серамиди, подхранва кожата и заздравява кожната бариера\r\nАрганово масло* - подхранва, защитава и подобрява хидратацията и еластичносттна на кожата\r\nМсла от мандарина и иланг-иланг* - придават лек, свеж и релаксиращ аромат, за да се насладите максимално на момента в грижа за кожата\r\nВитамин Е* - антиоксидант - успокоява раздразнената кожа и забавя страеенето като бори се със свободните радикали, UV уверждането и процесите на оксидация\r\n*Био",
                SectionOrder = 2,
                ProductId = 6
            },
            new Section
            {
                Id = 28,
                Title = "УПОТРЕБА",
                Description = "Например след лек хидратиращ лосион, за да заключи хидратацията и полезните съставки.\r\nДиректно върху влажна кожа за по-добро абсорбиране и защита.\r\nИли върху суха кожа, за да предотврати трансепидеррмалната загуба на вода от кожата.\r\n \r\nПодходящ за защита на кожата в края на рутината. Комбинира се добре след ексфолиращи и/или хидратиращи продукти.\r\n \r\nСамо за външна употреба. Да се пази от достъп на деца. Не използвайте при алергия към някоя от съставките. Използвайте с чисти ръце и кожа. Съхранявайте добре затворено, на сухо място, защитено от пряка слънчева светлина.",
                SectionOrder = 3,
                ProductId = 6
            },
            new Section
            {
                Id = 29,
                Title = "ИЗПАЩАНЕ И ДОСТАВКА",
                Description = "След като е посочен адрес за доставка или куриерски офис на Еконт или Спиди в полетата за адрес при поръчка, продуктите се опаковат внимателно в рециклирани картонена кутийка и хартиен пълнеж за уплътнение и се изпращат с доставка с преглед.",
                SectionOrder = 4,
                ProductId = 6
            },
            new Section
            {
                Id = 30,
                Title = "СЪСТАВ, INCI",
                Description = "Vitis Vinifera Seed Oil (масло от гроздови смеки), Rosa Canina Seed Oil (българско студенпресовно био масло от семената на шипка)*, Fragaria Ananassa Seed Oil (студенопресовано масло от семки на ягода), Argania Spinosa Kernel Oil (арганово масло)*, Simmondsia Chinensis Seed Oil (масло от жожоба)*, Tocopherol (Витамин E), Helianthus Annuus Seed Oil (Слънчогледово масло <0,2%) *,  Citrus Reticulata Oil (Етерично масло от мандарина) , Limonene**, Linalool**, Cananga Odorata flower Oil (Етерично масло от Иланг Иланф) *.\r\n*Био, 31%\r\n**Компоненети на етерични масла",
                SectionOrder = 5,
                ProductId = 6
            }



        };



        public IEnumerable<ShippingOffice> ShippingOffice = new List<ShippingOffice>
        {
            new ShippingOffice
            {
                Id = 1,
                City = "Sofia",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 2,
                City = "Sofia",
                OfficeAddress = "bul. Hristo Botev 20",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 3,
                City = "Varna",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 4,
                City = "Burgas",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 5,
                City = "Ruse",
                OfficeAddress = "bul. Vitosha 100",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 1
            },
            new ShippingOffice
            {
                Id = 6,
                City = "Sofia",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 7,
                City = "Sofia",
                OfficeAddress = "bul. Hristo Botev 30",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 8,
                City = "Sofia",
                OfficeAddress = "bul. Bozveli 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 9,
                City = "Burgas",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            },
            new ShippingOffice
            {
                Id = 10,
                City = "Ruse",
                OfficeAddress = "bul. Vitosha 200",
                Price = 5.00m,
                ShippingDuration = 2,
                ShippingProviderId = 2
            }

        };



        public IEnumerable<ShippingProvider> ShippingProviders = new List<ShippingProvider>
        {
            new ShippingProvider
            {
                Id = 1,
                Name = "Еконт",
            },
            new ShippingProvider
            {
                Id = 2,
                Name = "Спиди"
            },
        };


        public IEnumerable<StatusOrder> StatusOrders =
        [
            new () { Id = 1, Name = "Неизпълнена" },
            new () { Id = 2, Name = "Отменена" },
            new () { Id = 3, Name = "Изпълнена" },
            new () { Id = 4, Name = "Получена" },
            new () { Id = 5, Name = "Върната" },
        ];

        public IEnumerable<WishUser> WishesUsers = new List<WishUser>
            {
                new WishUser
                {
                    ProductId = 1,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                },
                new WishUser
                {
                    ProductId = 2,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                },
                new WishUser
                {
                    ProductId = 4,
                    AppUserId = "85fbe739-6be0-429d-b44b-1ce6cf7eeef"
                }
            };
    }
}
