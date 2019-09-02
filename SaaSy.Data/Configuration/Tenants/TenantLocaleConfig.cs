using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;

namespace SaaSy.Data.Configuration.Tenants
{
    public class TenantLocaleConfig : IEntityTypeConfiguration<TenantLocale>
    {
        public void Configure(EntityTypeBuilder<TenantLocale> t)
        {
            t.ToTable("Tenant_Locales");

            t.HasKey(x => new { x.TenantId, x.LanguageCode });

            t.Property(x => x.Title)
                .HasMaxLength(100);

            t.Property(x => x.Description)
                .HasMaxLength(500);

            //t.HasOne(x => x.Tenant)
            //    .WithMany(x => x.Locales)
            //    .HasForeignKey(x => new {x.TenantId, x.LanguageCode });
            //t.HasOne(x => x.Tenant)
            //    .WithMany()
            //    .HasForeignKey(x => x.TenantId);

        }
    }
}
