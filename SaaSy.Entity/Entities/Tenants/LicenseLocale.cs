using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class LicenseLocale : LocaleBase
    {
        public long LicenseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public License License { get; set; }
    }
}
