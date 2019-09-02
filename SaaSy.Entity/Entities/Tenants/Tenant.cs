using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class Tenant : ModelBase
    {
        public long TenantId { get; set; }

        [StringLength(10)]
        public string TenantCode { get; set; }

        public License License { get; set; }

        public Price Price { get; set; }

        public ICollection<TenantLocale> Locales { get; set; }
    }
}
