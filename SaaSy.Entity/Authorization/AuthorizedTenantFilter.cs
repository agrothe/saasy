using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace SaaSy.Entity.Authorization
{
    public class AuthorizedTenantFilter : IAuthorizationFilter
    {
        public AuthorizedTenantFilter()
        {

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Items.TryGetValue(Const.TENANT_KEY, out object value);
            var tenant = value ?? string.Empty;
            var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == Const.TENANT_KEY && c.Value == tenant.ToString());
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
