using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;

namespace SaaSy.Data.Configuration.Tenants
{
    public class AvailablePriceConfig : IEntityTypeConfiguration<AvailablePrice>
    {
        public void Configure(EntityTypeBuilder<AvailablePrice> t)
        {
            t.ToTable("LicenseAvailablePrices");

            t.HasKey(x => new { x.LicenseId, x.PriceId });

        }
    }
}
