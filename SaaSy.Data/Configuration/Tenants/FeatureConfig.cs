using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaaSy.Entity.Entities.Tenants;

namespace SaaSy.Data.Configuration
{
    public class FeatureConfig : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> t)
        {
            t.ToTable("Features");
            t.HasKey(x => x.FeatureId);

            //t.HasMany(x => x.Locales)
            //    .WithOne(x => x.Feature)
            //    .HasForeignKey(x => x.FeatureId);
        }
    }
}
