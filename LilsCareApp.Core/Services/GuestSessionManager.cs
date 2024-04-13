using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.GuestUser;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace LilsCareApp.Core.Services
{
    public class GuestSessionManager : IGuestSessionManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GuestSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public GuestSession? GetSession()
        {
            if (_httpContextAccessor.HttpContext?.Session.GetString("GuestSession") == null)
            {
                _httpContextAccessor.HttpContext?.Session.SetString("GuestSession", JsonConvert.SerializeObject(new GuestSession()));
            }

            return JsonConvert.DeserializeObject<GuestSession>(_httpContextAccessor.HttpContext.Session.GetString("GuestSession"));
        }

        public void SetSession(GuestSession? session)
        {
            if (session == null)
            {
                session = new GuestSession();
            }

            _httpContextAccessor.HttpContext?.Session.SetString("GuestSession", JsonConvert.SerializeObject(session));
        }
    }
}
