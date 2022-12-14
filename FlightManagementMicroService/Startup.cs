using CommonServiceDiscovery;
using FlightManagementMicroService.BusinessLayerInterfaces;
using FlightManagementMicroService.BusinessLogic;
using FlightManagementMicroService.DataAccessLayer;
using FlightManagementMicroService.DataAccessLayerInterfaces;
using FlightManagementMicroService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementMicroService
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddScoped<IAirLineMasterDataAccessLayerService, AirLineMasterDataAccessLayer>();
            services.AddScoped<IAirlineMasterBusinessLayerService, AirLineMasterBusinessLayerService>();
            services.AddScoped<IAirPortBusinessLayerService, AirPortBusinessLayerService>();
            services.AddScoped<IAirPortDataAccessLayerService, AirPortDataAccessLayerService>();
            services.AddScoped<IFlightDataAccessLayerService, FlightDataAccessLayerService>();
            services.AddScoped<IFlightBusinessLayerService, FlightBusinessLayerService>();
            services.AddScoped<IFlightScheduleBusinessLayerService, FlightScheduleBusinessLayerService>();
            services.AddScoped<IFlightScheduleDataAccessLayerService, FlightScheduleDataAccessLayerService>();
            services.AddScoped<IDiscountMasterBusinessLayerService, DiscountMasterBusinessLayerService>();
            services.AddScoped<IDiscountMasterDataAccessLayerServiceInterface, DiscountMasterDataAccessLayerService>();
            services.AddScoped<ICommonDataAccessLayer, CommonDataAccessLayerService>();

            services.AddDbContext<FlightBookingDBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("FlightDBConection")));
            services.AddConsulConfig(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseConsul(Configuration);
            app.UseCors("AllowOrigin");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
