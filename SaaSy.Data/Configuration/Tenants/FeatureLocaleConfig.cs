using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;

namespace SaaSy.Data.Configuration.Tenants
{
    public class FeatureLocaleConfig : IEntityTypeConfiguration<FeatureLocale>
    {
        public void Configure(EntityTypeBuilder<FeatureLocale> t)
        {
            t.ToTable("Feature_Locales");

            t.HasKey(x => new { x.FeatureId, x.LanguageCode });

            t.Property(x => x.Title)
                .HasMaxLength(100);

            t.Property(x => x.Description)
                .HasMaxLength(500);

            //t.HasOne(x => x.Feature)
            //    .WithMany()
            //    .HasForeignKey(x => x.FeatureId);

        }

    }
}
