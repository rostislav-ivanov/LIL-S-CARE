namespace LilsCareApp.Core.Models.Header
{
    public class HeaderComponentViewModel
    {
        public int CountInBag { get; set; }

        public string UserImagePath { get; set; } = string.Empty;

        public Dictionary<string, string> Cultures { get; set; } = [];

        public string ReturnUrl { get; set; } = string.Empty;

        public decimal FreeShipping { get; set; }

        public string Currency { get; set; } = string.Empty;
    }
}
