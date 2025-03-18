using Microsoft.AspNetCore.Identity;

namespace Engage360plus.Repository
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
