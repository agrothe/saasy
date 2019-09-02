using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SaaSy.Entity.Entities.Tenants
{
    public class AvailablePrice
    {
        public long LicenseId { get; set; }
        public long PriceId {get;set;}

        [ForeignKey("LicenseId")]
        public License License { get; set; }

        [ForeignKey("PriceId")]
        public Price Price { get; set; }
    }
}
