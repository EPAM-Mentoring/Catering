using Catering.DAL.DbContexts;
using Catering.DAL.Entities.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Catering.API.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(
           this IServiceCollection services,
           IConfiguration config)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("User", policy => policy.RequireUserName("test@test.com"));
                    options.AddPolicy("Admin", policy => policy.RequireUserName("admin@test.com"));
                })
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            return services;
           
        }
    }
}
