using LilsCareApp.Core.Models.GuestUser;

namespace LilsCareApp.Core.Contracts
{
    public interface IHttpContextManager
    {
        GuestSession? GetSession();
        void SetSession(GuestSession? session);

        string GetLanguage();
    }
}
