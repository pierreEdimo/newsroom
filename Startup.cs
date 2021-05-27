using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using newsroom.DBContext;
using Microsoft.EntityFrameworkCore;
using newsroom.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using newsroom.Services;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace newsroom
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
           

            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite("Data Source = newsplacedb"));

            services.AddTransient<IFileStorageService, InAppStorageService>(); 

            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(Startup)); 

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();



            services.AddIdentity<UserEntity, IdentityRole>(config =>
            {
                config.Password.RequireDigit = true;
                config.Password.RequireLowercase = true;
                config.Password.RequiredLength = 6;
                config.Password.RequireNonAlphanumeric = true;
                config.User.RequireUniqueEmail = true;
            })
             .AddEntityFrameworkStores<DatabaseContext>()
             .AddDefaultTokenProviders();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(config =>
                {
                    config.RequireHttpsMetadata = false;
                    config.SaveToken = true;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        RequireExpirationTime = false,
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });


            services.AddControllers().AddNewtonsoftJson();


            services.AddSwaggerGen( config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                   Version = "v1", 
                   Title = "NewsplaceApi", 
                   Description = "This is a blog api", 
                   License = new OpenApiLicense()
                   {
                       Name= "MIT"
                   }, 

                   Contact = new OpenApiContact()
                   {
                       Name = "Pierre Patrice Edimo", 
                       Email = "pierredimo@live.com"
                   }
                });

            }); 


            services.AddCors(options => options.AddPolicy("EnableAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            }));
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext context )
        {
            context.Database.EnsureCreated(); 

            app.UseSwagger();

            app.UseSwaggerUI( config => {
                config.SwaggerEndpoint("/swagger/v1/swagger.json","newsplaceApi"); 
            } ); 

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

           

            app.UseStaticFiles(); 

           

            app.UseRouting();

            app.UseResponseCaching(); 

            app.UseCors("EnableAll");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
