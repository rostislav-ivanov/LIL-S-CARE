namespace LilsCareApp.Infrastructure
{
    public static class DataConstants
    {
        public static class AdminConstants
        {
            public const string AreaName = "Admin";
            public const string AdminRoleName = "Admin";
            public const string AdminEmail = "admin@mail.com";
        }
        public static class AppConstants
        {
            //public const decimal FreeShipping = 35.00m;
            //public const decimal AddressDeliveryPrice = 8.00m;
        }

        public static class AppUser
        {
            public const int FirstNameMaxLength = 100;
            public const int LastNameMaxLength = 100;
            public const int ImagePathMaxLength = 2048;
            public const int UserNameMinLength = 6;
            public const int UserNameMaxLength = 20;
            public const int EmailMaxLength = 20;
        }

        public static class Product
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
            public const string PriceMinValue = "0.00";
            public const string PriceMaxValue = "1000.00";
            public const string QuantityMinValue = "-1000";
            public const string QuantityMaxValue = "1000";
            public const int OptionalMinLength = 3;
            public const int OptionalMaxLength = 200;
            public const int ProductsPerPages = 3;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class Image
        {
            public const int ImagePathMaxLength = 2048;
        }

        public static class Review
        {
            public const int AuthorNameMinLength = 3;
            public const int AuthorNameMaxLength = 200;
            public const int EmailMaxLength = 200;
            public const int TitleMaxLength = 200;
            public const int CommentMaxLength = 1000;
            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;
        }

        public static class StatusOrder
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 100;
        }

        public static class Order
        {
            public const int TrackingNumberMaxLength = 30;
            public const string TrackingNumberPattern = @"^[A-Za-z0-9]{5,}$";
            public const int OrdersPerPages = 10;
            public const string Paid = "Платена";
            public const string Unpaid = "Неплатена";
            public const int LanguageMaxLength = 10;
            public const int NoteForDeliveryMaxLength = 500;
        }

        public static class PaymentMethod
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class DeliveryMethod
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class ShippingProvider
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class PromoCode
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;
        }

        public static class AddressDelivery
        {
            public const int FirstNameMaxLength = 100;
            public const int LastNameMaxLength = 100;
            public const int PhoneNumberMaxLength = 50;
            public const int EmailNumberMaxLength = 50;
            public const int AddressMaxLength = 250;
            public const int TownMaxLength = 100;
            public const int DistrictMaxLength = 100;
            public const int CountryMaxLength = 100;
            public const int PostCodeMaxLength = 50;
            public const int EmailMaxLength = 50;
        }

        public static class Section
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 50;
            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 1500;
        }

        public static class Language
        {
            public const string English = "en";
            public const string Bulgarian = "bg";
            public const string Romanian = "ro";
            public const string Default = "en";
        }
    }
}

//[Range(type: typeof(decimal), minimum: PriceMinValue, maximum: PriceMaxValue, ConvertValueInInvariantCulture = true)]






