﻿using AppFidelidade.Core.Constants;
using AppFidelidade.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace AppFidelidade.API.Extensions
{
    public static class ServicesComplementaryExtension
    {
        public static void ServicesComplementaryInitialization(this IServiceCollection services)
        {
            
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(SettingsToken.Key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = ApplicationConstants.NameApplication, Version = "v1" });
            });
        }
    }
}