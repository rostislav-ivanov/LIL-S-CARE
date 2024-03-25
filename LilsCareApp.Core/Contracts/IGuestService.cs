using LilsCareApp.Core.Models;
using LilsCareApp.Core.Models.GuestUser;

namespace LilsCareApp.Core.Contracts
{
    public interface IGuestService
    {
        Task<IEnumerable<ProductsInBagDTO>> GetProductsInBagAsync(List<GuestBag> guestBags);
    }
}
