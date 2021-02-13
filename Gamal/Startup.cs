using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Gamal.Models;
using Gamal.Models.IRepositories;
using Gamal.Models.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Authorization;
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


         //services.Configure<Settings>(Configuration.GetSection("dev"));
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
				   //var appConfig = ConfigurationManager.AppSettings;

             optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Connection"));
             
             // optionsBuilder.UseSqlServer(DbHelper.GetDBConnectionString());
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

           // services.AddEntityFrameworkSqlServer();
         
            services.AddTransient<IFacultyRepository, FacultyRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddControllersWithViews();

         //services.AddAuthentication(auth =>
         //{
         //   auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         //   auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         //})
         // .AddJwtBearer(token =>
         // {
         //    token.RequireHttpsMetadata = false;
         //    token.SaveToken = true;
         //    token.TokenValidationParameters = new TokenValidationParameters
         //    {
         //       ValidateIssuerSigningKey = true,
         //       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["AppSetting:Key"])),
         //       ValidateIssuer = false,
         //       ValidateAudience = false,
         //    };
         // });
         services.AddAuthentication();
            services.AddAuthorization();
            services.AddMvc(options => {
               var policies = new AuthorizationPolicyBuilder()
                                  .RequireAuthenticatedUser()
                                  .Build();
               options.Filters.Add(new AuthorizeFilter(policies));
               //options.Filters.Add(new AuthorizeFilter());
            }).AddXmlDataContractSerializerFormatters();
           } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddFile ("/logging/logger.txt");
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

      class DbHelper
      {
         public static string GetDBConnectionString()
         {
            // The parameter name is customized based on the ASPNETCORE_ENVIRONMENT
            //
            // You can change this to a fixed string or use a different mechanism
            // to customize.
            String parameterName = String.Format("/GamalApp/dev/constr");

            // Using USEast1
            var ssmClient = new AmazonSimpleSystemsManagementClient("AKIAXIPOGAPU6524RCVS", "a1i6bGxqrLJhSw/RHuU2emT6BdC+Xsu6aiuWanT9", Amazon.RegionEndpoint.USWest2);
            
            var response = ssmClient.GetParameterAsync(new GetParameterRequest
            {
               Name = parameterName,
               WithDecryption = true
            });
            
            var value = response.GetAwaiter().GetResult().Parameter.Value;
            return value;
         }
      }
   }
}
