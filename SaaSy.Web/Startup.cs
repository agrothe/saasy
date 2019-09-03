using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SaaSy.Data.Context;
using SaaSy.Domain.Services.Identity;
using SaaSy.Domain.Services.Util;
using SaaSy.Entity.Identity;
using SaaSy.Resource;
using SaaSy.Web.Classes.Middleware;
using System.Globalization;

namespace SaaSy.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }
 

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // consider replacing with IDataContext
            var connectionString = string.Format(
                Configuration.GetConnectionString("DefaultConnection"), 
                Configuration["DatabaseUser"], 
                Configuration["DatabasePassword"],
                Configuration["DatabaseName"]);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole<long>>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            // Add our Labels class for l10n, views are localized in SaaSy.Web.Resouces
            services.AddSingleton<Labels>();


            services.AddLocalization(x => {
                x.ResourcesPath = "Resources";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                CultureInfo[] supportedCultures = new[]
                {
                    new CultureInfo(Const.Locale.EN),
                    new CultureInfo(Const.Locale.FR)
                };

                options.DefaultRequestCulture = new RequestCulture(Const.Locale.EN);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Add(new PathRequestCultureProvider(supportedCultures));
            });


            services.AddRouting(options => {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options => {
                    options.AllowAreas = true;
                })
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            // data abstractions
            services.AddTransient<IDataContext, ApplicationDbContext>();

            // application services
            services.AddScoped<SignInManager<ApplicationUser>,AppSignInManager<ApplicationUser>>();
            services.AddSingleton<IEncodingService, EncodingService>();
            
            services.AddMediatR(typeof(EncodingService).Assembly);
            services.AddMediatR(typeof(ApplicationUser).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
               // app.EnsureDatabaseIsSeeded(false);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseEndpointRouting();

            var localizationOptions = app
                .ApplicationServices
                .GetService<IOptions<RequestLocalizationOptions>>()
                .Value;

            app.UseRequestLocalization(localizationOptions);

            // app middleware start

            // app middleware end

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultLocale",
                    template: "{locale}/{tenant}/{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }





    }
}
