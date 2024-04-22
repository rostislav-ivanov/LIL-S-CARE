using LilsCareApp.Core.Contracts;
using LilsCareApp.Core.Models.GuestUser;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
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

        public string GetLanguage()
        {
            var language = _httpContextAccessor.HttpContext?.Request.Cookies[".AspNetCore.Culture"]?.Split('=').Last() ?? Default;

            return language;
        }
    }
}
