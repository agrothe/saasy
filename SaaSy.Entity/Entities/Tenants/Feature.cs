using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class Feature
    {
        public long FeatureId { get; set; }

        public string Claim { get; set; }
        public ICollection<FeatureLocale> Locales { get; set; }

    }
}
