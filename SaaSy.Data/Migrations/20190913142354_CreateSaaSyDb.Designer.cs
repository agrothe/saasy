﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SaaSy.Data.Context;

namespace SaaSy.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190913142354_CreateSaaSyDb")]
    partial class CreateSaaSyDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<long>", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.AvailablePrice", b =>
                {
                    b.Property<long>("LicenseId");

                    b.Property<long>("PriceId");

                    b.HasKey("LicenseId", "PriceId");

                    b.HasIndex("PriceId");

                    b.ToTable("LicenseAvailablePrices");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.Feature", b =>
                {
                    b.Property<long>("FeatureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Claim");

                    b.Property<long?>("LicenseId");

                    b.HasKey("FeatureId");

                    b.HasIndex("LicenseId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.FeatureLocale", b =>
                {
                    b.Property<long>("FeatureId");

                    b.Property<string>("LanguageCode");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsInputLanguage");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("FeatureId", "LanguageCode");

                    b.ToTable("Feature_Locales");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.License", b =>
                {
                    b.Property<long>("LicenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ClientSpecific");

                    b.HasKey("LicenseId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.LicenseLocale", b =>
                {
                    b.Property<long>("LicenseId");

                    b.Property<string>("LanguageCode");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsInputLanguage");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("LicenseId", "LanguageCode");

                    b.ToTable("License_Locales");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.Price", b =>
                {
                    b.Property<long>("PriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<int>("PriceInterval");

                    b.HasKey("PriceId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.Tenant", b =>
                {
                    b.Property<long>("TenantId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<long?>("LicenseId");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<long?>("PriceId");

                    b.Property<string>("TenantCode")
                        .HasMaxLength(10);

                    b.HasKey("TenantId");

                    b.HasIndex("LicenseId");

                    b.HasIndex("PriceId");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.TenantLocale", b =>
                {
                    b.Property<long>("TenantId");

                    b.Property<string>("LanguageCode");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<bool>("IsInputLanguage");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("TenantId", "LanguageCode");

                    b.ToTable("Tenant_Locales");
                });

            modelBuilder.Entity("SaaSy.Entity.Identity.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<long>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("SaaSy.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("SaaSy.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<long>")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSy.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("SaaSy.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.AvailablePrice", b =>
                {
                    b.HasOne("SaaSy.Entity.Entities.Tenants.License", "License")
                        .WithMany("AvailablePrices")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaaSy.Entity.Entities.Tenants.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.Feature", b =>
                {
                    b.HasOne("SaaSy.Entity.Entities.Tenants.License")
                        .WithMany("Features")
                        .HasForeignKey("LicenseId");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.FeatureLocale", b =>
                {
                    b.HasOne("SaaSy.Entity.Entities.Tenants.Feature", "Feature")
                        .WithMany("Locales")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.LicenseLocale", b =>
                {
                    b.HasOne("SaaSy.Entity.Entities.Tenants.License", "License")
                        .WithMany("Locales")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.Tenant", b =>
                {
                    b.HasOne("SaaSy.Entity.Entities.Tenants.License", "License")
                        .WithMany()
                        .HasForeignKey("LicenseId");

                    b.HasOne("SaaSy.Entity.Entities.Tenants.Price", "Price")
                        .WithMany()
                        .HasForeignKey("PriceId");
                });

            modelBuilder.Entity("SaaSy.Entity.Entities.Tenants.TenantLocale", b =>
                {
                    b.HasOne("SaaSy.Entity.Entities.Tenants.Tenant", "Tenant")
                        .WithMany("Locales")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
