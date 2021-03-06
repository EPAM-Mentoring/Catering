using AutoMapper;
using Catering.API.Configuration;
using Catering.API.Extensions;
using Catering.BLL.Interfaces;
using Catering.BLL.Options;
using Catering.BLL.Services;
using Catering.Common.WebClient;
using Catering.DAL.DbContexts;
using Catering.DAL.Entities.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Catering.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private readonly IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson();

            services.AddDbContext<CateringDbContext>(options => 
                   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient();
            services.AddScoped<IWebApiClient, WebApiClient>();
            services.ResolveDependencies();
            services.AddAuth(Configuration);
  
            services.Configure<ReserveServiceOptions>(Configuration.GetSection(ReserveServiceOptions.Section));
   
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed((host) => true));
            });
            services.AddSwaggerDocumentation();

            services.AddMvc()
              .AddNewtonsoftJson(options =>
              {
                  options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                  options.SerializerSettings.Culture = System.Globalization.CultureInfo.InvariantCulture;
                  options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                  options.SerializerSettings.FloatFormatHandling = Newtonsoft.Json.FloatFormatHandling.String;
              });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuth();

            app.UseSwaggerDocumentation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
