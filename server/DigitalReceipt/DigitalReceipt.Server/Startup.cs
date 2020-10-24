using DigitalReceipt.Server.Infrastructure.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DigitalReceipt.Data;
using Microsoft.EntityFrameworkCore;
using DigitalReceipt.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using static DigitalReceipt.Common.GlobalConstants;
using DigitalReceipt.Common.Settings;
using DigitalReceipt.Server.Infrastructure.Extensions;
using DigitalReceipt.Server.Infrastructure.Filters;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Models.Users;
using System.Runtime;

namespace DigitalReceipt.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public AppSettings AppSettings { get; protected set; }

        public void ConfigureServices(IServiceCollection services)
        {
            AppSettings = services.AddSettings<AppSettings>(nameof(AppSettings), Configuration);

            services.AddApplicationSettings(Configuration);
            
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services
               .AddIdentity<User, IdentityRole>(options =>
               {
                   options.Lockout.AllowedForNewUsers = true;
                   options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(AuthenticationConstants.LockoutTimeInMinutes);
                   options.Lockout.MaxFailedAccessAttempts = AuthenticationConstants.MaxFailedAccessAttempts;

                   options.Password.RequireDigit = false;
                   options.Password.RequiredLength = 6;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
               })
               .AddDefaultTokenProviders()
               .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddBusinessLogic();

            if (AppSettings.EnableCors)
            {
                services.AddCorsRules(AppSettings);
            }

            services
                .AddJwtAuthentication(Configuration)
                .ConfigureApiBehavior();

            if (AppSettings.EnableSwagger)
            {
                services.AddSwagger();
            }

            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateModelStateActionFilter>();
                options.Filters.Add<ExceptionFilter>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(LoginInputModel).Assembly);

            // Uncomment the line below if you want to seed data in your database
            app.SeedData();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            if (AppSettings.EnableCors)
            {
                app.UseCors(CorsPolicy);
            }

            app.UseAuthentication();
            app.UseAuthorization();

            if(env.IsDevelopment() || AppSettings.EnableSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaseManager API V1");
                });
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
