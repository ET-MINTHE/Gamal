using Gamal.Models;
using Gamal.Models.IRepositories;
using Gamal.Models.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Gamal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        private IServiceCollection ConfigureLogging(IServiceCollection factory)
        {
            factory.AddLogging(opt =>
            {
                opt.AddConsole();
            });
            return factory;
        }
        public IConfiguration Configuration { get; }
        public ILoggerFactory LoggingFactory { get; set; }
      // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         //services.AddDbContextPool<AppDbContext>(
         //    options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
         
         services.AddLocalization(option => option.ResourcesPath = "Resources");
         
         services.Configure<RequestLocalizationOptions>(
         opts =>
         {
               var supportedCultures = new List<CultureInfo>
               {
                  new CultureInfo("en-GB"),
                  new CultureInfo("en-US"),
                  new CultureInfo("en"),
                  new CultureInfo("fr-FR"),
                  new CultureInfo("fr"),
               };

               opts.DefaultRequestCulture = new RequestCulture("fr-FR");
               // Formatting numbers, dates, etc.
               opts.SupportedCultures = supportedCultures;
               // UI strings that we have localized.
               opts.SupportedUICultures = supportedCultures;
               opts.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
               {
                  return new ProviderCultureResult("fr-FR");
               }));
         });
         
         services.AddDbContext<AppDbContext>((serviceProvider, optionsBuilder) =>
         {
               optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Connection"));
               optionsBuilder.UseInternalServiceProvider(serviceProvider);
         });
         
         services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<AppDbContext>()
               .AddDefaultTokenProviders();

         services.AddSession(options => {
               options.IdleTimeout = TimeSpan.FromMinutes(300);//You can set Time   
         });

         services.AddEntityFrameworkSqlServer();
         services.AddControllersWithViews();

         services.AddEntityFrameworkSqlServer();

         services.AddTransient<IFacultyRepository, FacultyRepository>();
         services.AddTransient<ICourseRepository, CourseRepository>();
         services.AddTransient<IDepartmentRepository, DepartmentRepository>();

         services.AddControllersWithViews();
         
         services.AddAuthentication(auth =>
         {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         })
          .AddJwtBearer(token =>
          {
             token.RequireHttpsMetadata = false;
             token.SaveToken = true;
             token.TokenValidationParameters = new TokenValidationParameters
             {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["AppSetting:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
             };
          });
         
         services.AddAuthorization();
         services.AddMvc();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseRequestLocalization(requestLocalizationOptions);
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        
            app.UseRequestLocalization(options.Value);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
         
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(
               builder =>
               {
                  builder.AllowAnyOrigin() // TODO: revisit and check if this can be more strict and still allow preflight OPTION requests
                      .AllowAnyMethod()
                      .AllowAnyHeader();
               }
             );
         
            app.UseEndpoints(endpoints =>
               {
                  endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
               });
        }
    }
}
