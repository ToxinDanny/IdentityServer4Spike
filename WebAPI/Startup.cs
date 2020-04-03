using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using IdentityServer4.AccessTokenValidation;

namespace WebAPI
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
            // services.AddAuthentication("Bearer")
            //     .AddJwtBearer("Bearer", opt =>
            //     {
            //         opt.Authority = "https://localhost:5000";
            //         opt.RequireHttpsMetadata = false;
            //         opt.Audience = "myApi";
                    
            //         opt.TokenValidationParameters.ValidateIssuer = true;
            //         opt.TokenValidationParameters.ValidateAudience = true;
            //         opt.TokenValidationParameters.ValidateIssuerSigningKey = true;
            //         opt.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            //     });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(opt => {
                    opt.Authority = "https://localhost:5000";
                    opt.ApiName = "myApi";
                    opt.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(opt => {
                opt.AddPolicy("RolePolicy", policy => {
                    policy.RequireRole(new List<string>{"admin"});
                });
            });
            services.AddCors();

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
            app.UseCors(opt => {
                opt.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
