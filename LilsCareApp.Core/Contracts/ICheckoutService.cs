using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Infrastructure.Data.Models;

namespace LilsCareApp.Core.Contracts
{
    public interface ICheckoutService
    {
        Task<int?> GetDefaultAddressIdAsync(string userId);
        Task<IEnumerable<PaymentMethod>> GetPaymentMethodsAsync();
        Task<IEnumerable<PromoCodeDTO>> GetPromoCodesAsync(string userId);
        Task<string> CheckoutSaveAsync(OrderDTO checkout, string userId);
        Task<OrderSummaryDTO> OrderSummaryAsync(string orderSNumber);
    }
}