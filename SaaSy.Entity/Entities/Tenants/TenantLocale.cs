using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class TenantLocale : LocaleBase
    {
        public long TenantId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Tenant Tenant { get; set; }
    }
}
