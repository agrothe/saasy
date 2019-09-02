using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class FeatureLocale : LocaleBase
    {
        public long FeatureId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Feature Feature { get; set; }
    }
}
