using Bigon.Infrastructure;

namespace Bigon.Application.Services.Identity
{
    public class FakeIdentityService : IIdentityService
    {
        public int? GetPrincipleId()
        {
            return null;
        }
    } 
} 
