using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaaSy.Data.Configuration
{
    public class LicenseLocaleConfig : IEntityTypeConfiguration<LicenseLocale>
    {
        public void Configure(EntityTypeBuilder<LicenseLocale> t)
        {
            t.ToTable("License_Locales");
            t.HasKey(x => new { x.LicenseId, x.LanguageCode });

            //t.HasOne(x => x.License)
            //    .WithMany(x=>x.Locales)
            //    .HasForeignKey(x => new { x.LicenseId, x.LanguageCode });


            //t.HasOne(x => x.License)
            //    .WithMany()
            //    .HasForeignKey(x => x.LicenseId);

            t.Property(x => x.Title)
                .HasMaxLength(100);

            t.Property(x => x.Description)
                .HasMaxLength(500);

        }
    }
}
