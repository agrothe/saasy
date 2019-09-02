using SaaSy.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class Price
    {
        public long PriceId { get; set; }
        public float Amount { get; set; }
        public PriceIntervalMonths PriceInterval { get; set; }
    }
}
