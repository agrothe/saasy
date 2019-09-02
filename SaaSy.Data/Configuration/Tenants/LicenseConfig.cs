using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Data.Configuration
{
    public class LicenseConfig : IEntityTypeConfiguration<License>
    {
        public void Configure(EntityTypeBuilder<License> t)
        {
            t.ToTable("Licenses");
            t.HasKey(x => x.LicenseId);

            //t.HasMany(x => x.AvailablePrices)
            //    .WithOne();

            //t.HasMany(x => x.Features)
            //    .WithOne();

            //t.HasMany(x => x.Locales)
            //    .WithOne(x => x.License)
            //    .HasForeignKey(x => x.LicenseId);

        }
    }
}
