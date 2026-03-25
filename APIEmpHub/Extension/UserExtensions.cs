using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace APIEmpHub.Extension
{
    public static class UserExtensions
    {
        public static IConfiguration _config;
        public static void Initialize(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        public static string GetClaimsValue(this IPrincipal principal, string claimType)
        {
            if (principal != null)
            {
                var claimsIdentity = (ClaimsIdentity)principal.Identity;
                if (claimsIdentity.HasClaim(x => x.Type == claimType))
                {
                    var claim = claimsIdentity.FindFirst(claimType);
                    return claim.Value;
                }
            }
            return string.Empty;
        }

        public static string Authen(this IPrincipal principal)
        {
            return GetClaimsValue(principal, ClaimTypes.Authentication);
        }

        public static string UserId(this IPrincipal principal)
        {
            return GetClaimsValue(principal, ClaimTypes.NameIdentifier);
        }

        public static string UserName(this IPrincipal principal)
        {
            return GetClaimsValue(principal, "name");
        }

        public static string Position(this IPrincipal principal)
        {
            return GetClaimsValue(principal, "position");
        }

        public static string Department(this IPrincipal principal)
        {
            return GetClaimsValue(principal, "department");
        }
    }
}
