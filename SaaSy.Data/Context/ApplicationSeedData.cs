using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaaSy.Entity;
using SaaSy.Entity.Entities.Tenants;
using System;
using System.Collections.Generic;

namespace SaaSy.Data.Context
{
    public static class ApplicationSeedData
    {
        public static int EnsureSeedData(this ApplicationDbContext db)
        {
            var tenant = db.Tenants.FirstOrDefaultAsync(x => x.TenantId == 1).Result;
            if(tenant == null)
            {
                tenant = new Tenant
                {
                    TenantId = 1,
                    TenantCode = "app",
                    Created = DateTime.Now,
                    CreatedBy = "seed",
                    Modified = DateTime.Now,
                    ModifiedBy = "seed",
                    License = new License
                    {
                        LicenseId = 1,
                        ClientSpecific = false,
                        AvailablePrices = new List<AvailablePrice> {
                            new AvailablePrice
                            {
                                LicenseId = 1,
                                PriceId = 1,
                                Price = new Price
                                {
                                    PriceId = 1,
                                    PriceInterval = Entity.Enums.PriceIntervalMonths.Yearly,
                                    Amount = 0
                                }
                            }
                        },
                        Features = new List<Feature>
                        {
                            new Feature
                            {
                                FeatureId = 1,
                                Claim = Const.TENANT_KEY,
                                Locales = new List<FeatureLocale>
                                {
                                    new FeatureLocale
                                    {
                                        FeatureId = 1,
                                        LanguageCode = "en",
                                        IsInputLanguage = true,
                                        Created = DateTime.Now,
                                        CreatedBy = "seed",
                                        Modified = DateTime.Now,
                                        ModifiedBy = "seed",
                                        Description = "Allows access to the default tenant.",
                                        Title = "Access Default Tenant"
                                    }
                                }
                            }
                        },
                        Locales = new List<LicenseLocale>
                        {
                            new LicenseLocale
                            {
                                LicenseId = 1,
                                LanguageCode = "en",
                                Created = DateTime.Now,
                                CreatedBy = "seed",
                                Modified = DateTime.Now,
                                ModifiedBy = "seed",
                                IsInputLanguage = true,
                                Title = "System License",
                                Description = "Main system license for default tenant."
                            }
                        }
                    },
                    Locales = new List<TenantLocale>
                    {
                        new TenantLocale
                        {
                            TenantId = 1,
                            LanguageCode = "en",
                            Created = DateTime.Now,
                            CreatedBy = "seed",
                            Modified = DateTime.Now,
                            ModifiedBy = "seed",
                            IsInputLanguage = true,
                            Title = "Default System Tenant",
                            Description = "Default System Tenant"
                        }
                    }
                };
            }
            return db.SaveChanges();
        }

        public static int EnsureDatabaseIsSeeded(this IApplicationBuilder applicationBuilder,
            bool autoMigrateDatabase)
        {
            // seed the database using an extension method
            using (var serviceScope = applicationBuilder.ApplicationServices
           .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                if (autoMigrateDatabase)
                {
                    context.Database.Migrate();
                }
                return context.EnsureSeedData();
            }
        }
    }
}
