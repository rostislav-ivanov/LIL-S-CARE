using LilsCareApp.Core.Models.GuestUser;

namespace LilsCareApp.Core.Contracts
{
    public interface IGuestSessionManager
    {
        GuestSession? GetSession();
        void SetSession(GuestSession? session);
    }
}
