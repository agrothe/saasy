using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Authorization
{
    public class AuthorizedTenantAttribute : TypeFilterAttribute
    {
        public AuthorizedTenantAttribute() : base(typeof(AuthorizedTenantFilter))
        {
            
        }
    }
}
