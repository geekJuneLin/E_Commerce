using AutoMapper;
using E_Commerce.Data;
using E_Commerce.Helpers;
using E_Commerce.Models;
using E_Commerce.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce
{
    public class Startup
    {
        public IConfiguration Configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppDbContext>(opt => {
                opt.UseSqlServer(Configuration["ConnectionStrings:appDb"]);
            });

            services.AddTransient<IProductItemRepository, ProductItemRepository>();

            services.AddTransient<IHeaderLinkGenerator, HeaderLinkGenerator>();

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var secretBytes = Encoding.UTF8.GetBytes(Configuration["JWTSecretKey"]);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretBytes)
                    };
                });

            services.AddHttpClient();

            services.AddCors(options =>
            {
                options.AddPolicy("myPolicy", builder => {
                    builder.AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .WithExposedHeaders("x-pagination");
                });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                    .AddNewtonsoftJson(option =>
                    {
                        option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("myPolicy");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //PreDb.PrepPopulation(app);
        }
    }
}
