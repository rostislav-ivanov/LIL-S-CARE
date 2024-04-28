using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.Checkout;
using LilsCareApp.Core.Models.GuestUser;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using static LilsCareApp.Infrastructure.DataConstants.Language;

namespace LilsCareApp.Core.Services
{
    public class HttpContextManager : IHttpContextManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public GuestSession? GetSessionGuest()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetString("GuestSession") == null)
            {
                _httpContextAccessor.HttpContext?.Session.SetString("GuestSession", JsonSerializer.Serialize(new GuestSession()));
            }

            return JsonSerializer.Deserialize<GuestSession>(_httpContextAccessor.HttpContext.Session.GetString("GuestSession"));
        }

        public void SetSessionGuest(GuestSession? guest)
        {
            if (guest == null)
            {
                guest = new GuestSession();
            }

            _httpContextAccessor.HttpContext?.Session.SetString("GuestSession", JsonSerializer.Serialize(guest));
        }

        public string GetLanguage()
        {
            var language = _httpContextAccessor.HttpContext?.Request.Cookies[".AspNetCore.Culture"]?.Split('=').Last() ?? Default;

            return language;
        }

        public AddressOrderDTO? GetSessionAddress()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetString("Address") == null)
            {
                _httpContextAccessor.HttpContext?.Session.SetString("Address", JsonSerializer.Serialize(new AddressOrderDTO()));
            }
            return JsonSerializer.Deserialize<AddressOrderDTO>(_httpContextAccessor.HttpContext.Session.GetString("Address"));
        }

        public void SetSessionAddress(AddressOrderDTO? address)
        {
            if (address == null)
            {
                address = new AddressOrderDTO();
            }

            _httpContextAccessor.HttpContext?.Session.SetString("Address", JsonSerializer.Serialize(address));
        }

        public OrderDTO? GetSessionOrder()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetString("Order") == null)
            {
                _httpContextAccessor.HttpContext?.Session.SetString("Order", JsonSerializer.Serialize(new OrderDTO()));
            }
            return JsonSerializer.Deserialize<OrderDTO>(_httpContextAccessor.HttpContext.Session.GetString("Order"));
        }

        public void SetSessionOrder(OrderDTO? order)
        {
            if (order == null)
            {
                order = new OrderDTO();
            }
            _httpContextAccessor.HttpContext?.Session.SetString("Order", JsonSerializer.Serialize(order));
        }
    }
}
