using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using SaaSy.Entity;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace SaaSy.Web.Classes.Middleware
{
    public class PathRequestCultureProvider : RequestCultureProvider
    {
        private CultureInfo[] SupportedCultures;
        public PathRequestCultureProvider(CultureInfo[] supportedCultures)
        {
            SupportedCultures = supportedCultures;
        }
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            // path example: en/app/account/login
            var parts = httpContext.Request.Path.ToUriComponent().TrimStart('/').Split('/');
            var culture = string.Empty;

            // first position is always language
            if (parts.Length > 0)
            {
                culture = parts[0];
            }

            // second position is always tenant
            if(parts.Length > 1)
            {
                /***
                 * This should be in a different middleware for purpose of
                 * seperation of concerns, but for sake of performance we
                 * are doing this here as we already have the path broken
                 * apart.
                 * */
                httpContext.Items.Add(Const.TENANT_KEY, parts[1]);
            }
            
            
            if (string.IsNullOrWhiteSpace(culture))
            {
                return Task.FromResult(new ProviderCultureResult(SupportedCultures[0].Name));
            }

            return Task.FromResult(new ProviderCultureResult(culture));
        }
    }
}
