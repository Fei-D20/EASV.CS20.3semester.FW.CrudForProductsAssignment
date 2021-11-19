using System;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Core.IServices;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Database;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.IRepositories;
using EASV.CS20._3semester.FW.CrudForProductsAssignment.Domain.Services;
using EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authentication;
using EASV.CS20._3semester.FW.CrudForProductsAssignmentSecurity.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using UserRepository = EASV.CS20._3semester.FW.CrudForProductsAssignment.Database.UserRepository;

namespace EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Byte[] secretBytes = new byte[40];
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            using (var rngCsp = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(secretBytes);
            }

            services.AddHttpClient();
            //Add JWT authentication
            //The settings below match the settings when we create our TOKEN:
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    //ValidAudience = "CoMetaApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "CoMetaApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
            var loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
            services.AddDbContext<ApplicationContext>(opt => opt.UseLoggerFactory(loggerFactory).UseSqlite("Data source = ProductProject.db"));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                        {Title = "EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi", Version = "v1"});
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserAuthConfig>();
            services.AddTransient<IAuthorizableOwnerIdentity, UserResourceOwnerAuthorizationService>();
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("OwnerPolicy",
                    policy => { policy.Requirements.Add(new ResourceOwnerRequirement()); });
            });
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddTransient<IUserAuthenticator, UserAuthenticator>();
            
            services.AddCors(opt =>
            {
                opt.AddPolicy("product-policy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "EASV.CS20._3semester.FW.CrudForProductsAssignment.WebApi v1"));
            }
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<ApplicationContext>();
                //creating db
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseCors("product-policy");
        }
    }
}