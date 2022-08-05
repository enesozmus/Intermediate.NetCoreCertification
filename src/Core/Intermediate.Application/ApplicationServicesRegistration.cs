using FluentValidation.AspNetCore;
using Intermediate.Application.JSONWebToken;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Intermediate.Application;

public static class ApplicationServicesRegistration
{
     public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
     {
          // FluentValidation
          services.AddControllers().AddFluentValidation(options =>
          {
               options.ImplicitlyValidateChildProperties = true;
               options.ImplicitlyValidateRootCollectionElements = true;
               options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          });

          // MediatR
          services.AddMediatR(Assembly.GetExecutingAssembly());

          // AutoMapper
          services.AddAutoMapper(Assembly.GetExecutingAssembly());

          // Json Web Token
          services.AddSingleton<IJWTManager>(new JWTManager());
          //services.AddScoped<IJWTManager, JWTManager>();

          return services;
     }
}
