﻿namespace LilsCareApp.Core
{
    public static class ErrorMessageConstants
    {
        public const string Required = "Моля, въведете {0}!";
        public const string StringLength = "Полето {0} трябва да бъде най-малко {2} и най-много {1} символа дълго";
        public const string DurationRange = "Полето {0} трябва да бъде между {1} и {2}";
        public const string ConfirmAgreementPrivacyPolicy = "Потвърдете съгласието с политиката за поверителност.";
        public const string EmailAddress = "Невалиден имейл адрес.";
        public const string InvalidPhoneNumber = "Невалиден телефонен номер.";
        public const string PhoneNumberPattern = @"^(\+|0)\d{8,}$";
        public const string RatingRange = "Моля, дайте вашата оценка!";
        public const string RequireRating = "Моля, дайте вашата оценка!";
        public const string PrivacyPolicyCheck = "Моля, потвърдете съгласието с политиката за поверителност.";
    }
}
