using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class License
    {
        public long LicenseId { get; set; }

        public bool ClientSpecific { get; set; }
        public ICollection<Feature> Features { get; set; }
        public ICollection<AvailablePrice> AvailablePrices { get; set; }

        public ICollection<LicenseLocale> Locales { get; set; }
    }
}
