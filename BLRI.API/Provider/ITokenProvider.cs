using BLRI.Entity.Auth;

namespace BLRI.API.Provider
{
    public interface ITokenProvider
    {
        string GenerateToken(User user);
    }
}