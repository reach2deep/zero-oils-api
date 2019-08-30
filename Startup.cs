using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Verdant.Zero.Erp.Api.BuisnessServices;
using Verdant.Zero.Erp.Api.Data.Buisness;
using Verdant.Zero.Erp.Api.Data.EntityFramework;
using Verdant.Zero.Erp.Api.EntityFramework;
using Verdant.Zero.Erp.Api.Interfaces;
using Verdant.Zero.Erp.Api.Model;
using Verdant.Zero.Erp.Api.Security;

namespace Verdant.Zero.Erp.Api
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
            CorsPolicyBuilder corsBuilder = new CorsPolicyBuilder();

            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
                       

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Zerop API",
                    Description = "ASP.NET Core Web API"
                });
            });

            
            ConnectionStrings connectionStrings = new ConnectionStrings();
            Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);

            services.AddDbContext<ZeroErpManagementDatabase>(options => options.UseMySQL(Configuration.GetConnectionString("PrimaryDatabaseConnectionString")));

            // Customer
            services.AddTransient<ICustomerManagementDataService, ZeroErpManagementDataService>();
            services.AddTransient<ICustomerManagementBusinessService>(provider => 
            new CustomerManagementBusinessService(provider.GetRequiredService<ICustomerManagementDataService>(), connectionStrings));

            // Account
            services.AddTransient<IAccountManagementDataService, AccountManagementDataService>();
            services.AddTransient<IAccountManagementBusinessService>(provider =>
            new AccountManagementBusinessService(provider.GetRequiredService<IAccountManagementDataService>(), connectionStrings));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://verdant.co.in",
                    ValidAudience = "http://verdant.co.in",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Verdant.Zero.Erp.Api.Shared.Utilities.TokenManagement"))
                };
            });

            services.AddScoped<SecurityFilter>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("SiteCorsPolicy");
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
                c.RoutePrefix = string.Empty;
            });
            
        }
    }
}
