using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;

namespace SaaSy.Data.Configuration
{
    public class TenantConfig : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> t)
        {
            t.ToTable("Tenants");
            t.HasKey(x => x.TenantId);
            t.Property("TenantCode")
                .HasMaxLength(10);

            //t.HasOne(x => x.License);
            //t.HasOne(x => x.Price);

            //t.HasMany(x => x.Locales)
            //    .WithOne(x => x.Tenant)
            //    .HasForeignKey(x => new { x.TenantId, x.LanguageCode });

            //t.HasMany(x => x.Locales)
            //    .WithOne(x => x.Tenant)
            //    .HasForeignKey(x => x.TenantId);

        }
    }
}
