using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.JSONWebToken;
using Intermediate.Domain.Entities;
using Intermediate.Persistence.Contexts;
using Intermediate.Persistence.Repositories;
using Intermediate.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Intermediate.Persistence;


public static class PersistenceServicesRegistration
{
     public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
     {
          #region Microsoft SQL Server

          services.AddDbContext<IntermediateContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

          #endregion

          #region Identity Library

          services.AddIdentity<AppUser, AppRole>(options =>
          {
               options.Password.RequiredLength = 8;
               options.Password.RequireNonAlphanumeric = true;
               options.Password.RequireLowercase = true;
               options.Password.RequireUppercase = true;
               options.Password.RequireDigit = true;
               options.User.RequireUniqueEmail = true;
               options.Password.RequiredUniqueChars = 1;
               options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+";
               //options.SignIn.RequireConfirmedAccount = false;
               //options.SignIn.RequireConfirmedEmail = false;
               //options.SignIn.RequireConfirmedPhoneNumber = false;
               //options.Lockout.MaxFailedAccessAttempts = 3;
               //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

          })
               .AddEntityFrameworkStores<IntermediateContext>()
               .AddDefaultTokenProviders()
               .AddSignInManager<SignInManager<AppUser>>();

          #endregion

          #region Json Web Token

          services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
          {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTModel.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = JWTModel.Issuer,
                    ValidateAudience = true,
                    ValidAudience = JWTModel.Audience,
                    ValidateLifetime = true,
                    //Verilen sürede token sonlanır. Eğer Zero olarak verilmez ise default 5 dakikadır.
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true
               };
          });

          #endregion

          #region Repositories

          services.AddScoped<IBlockReadRepository, BlockReadRepository>();
          services.AddScoped<IBlockWriteRepository, BlockWriteRepository>();

          services.AddScoped<IApartmentTypeReadRepository, ApartmentTypeReadRepository>();
          services.AddScoped<IApartmentTypeWriteRepository, ApartmentTypeWriteRepository>();

          services.AddScoped<IApartmentReadRepository, ApartmentReadRepository>();
          services.AddScoped<IApartmentWriteRepository, ApartmentWriteRepository>();

          services.AddScoped<IBillReadRepository, BillReadRepository>();
          services.AddScoped<IBillWriteRepository, BillWriteRepository>();

          services.AddScoped<IMessageReadRepository, MessageReadRepository>();
          services.AddScoped<IMessageWriteRepository, MessageWriteRepository>();

          #endregion

          #region Services

          services.AddScoped<IUserAccessor, UserAccessor>();

          #endregion

          return services;
     }
}
