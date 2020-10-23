using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DigitalReceipt.Server.Infrastructure.Configuration
{
    public static class SwaggerConfiguration
    {
        private const string AuthenticationScheme = "Bearer";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Case Manager API", Version = "v1" });
                c.AddSecurityDefinition(AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = AuthenticationScheme
                });

                var scheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = AuthenticationScheme,
                    },
                    Name = AuthenticationScheme,
                    In = ParameterLocation.Header,
                    Scheme = AuthenticationScheme
                };

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    [scheme] = new List<string>()
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
