using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaaSy.Data.Configuration;
using SaaSy.Data.Configuration.Tenants;
using SaaSy.Entity.Entities.Tenants;
using SaaSy.Entity.Identity;

namespace SaaSy.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>, IDataContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Price> Prices { get; set; }

        public DbSet<TenantLocale> TenantLocales { get; set; }
        public DbSet<LicenseLocale> LicenseLocales { get; set; }
        public DbSet<FeatureLocale> FeatureLocales { get; set; }
        public DbSet<AvailablePrice> AvailablePrices { get; set; }


        protected override void OnModelCreating(ModelBuilder ctx)
        {
            base.OnModelCreating(ctx);

            ctx.Entity<ApplicationUser>()
                .ToTable("Users");

            ctx.Entity<IdentityRole<long>>()
                .ToTable("Roles")
                .HasKey(x=>x.Id);

            ctx.Entity<IdentityRoleClaim<long>>()
                .ToTable("RoleClaims");

            ctx.Entity<IdentityUserClaim<long>>()
                .ToTable("UserClaims");

            ctx.Entity<IdentityUserLogin<long>>()
                .ToTable("UserLogins")
                .HasKey(x=> new { x.LoginProvider, x.ProviderKey });

            ctx.Entity<IdentityUserRole<long>>()
                .ToTable("UserRoles")
                .HasKey(x => new { x.UserId, x.RoleId });

            ctx.Entity<IdentityUserToken<long>>()
                .ToTable("UserTokens");

            ctx.Entity<IdentityUserToken<long>>()
                .ToTable("UserTokens")
                .HasKey(x => new { x.UserId, x.LoginProvider });

            ctx.ApplyConfiguration(new TenantConfig());
            ctx.ApplyConfiguration(new TenantLocaleConfig());
            ctx.ApplyConfiguration(new FeatureConfig());
            ctx.ApplyConfiguration(new FeatureLocaleConfig());
            ctx.ApplyConfiguration(new LicenseConfig());
            ctx.ApplyConfiguration(new LicenseLocaleConfig());
            ctx.ApplyConfiguration(new PriceConfig());
            ctx.ApplyConfiguration(new AvailablePriceConfig());
        }


    }
}
