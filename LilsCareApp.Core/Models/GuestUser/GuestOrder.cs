namespace LilsCareApp.Core.Models.GuestUser
{
    public class GuestOrder
    {
        public required string sessionId { get; set; }

        public List<GuestBag> GuestBags { get; set; } = new List<GuestBag>();
    }
}