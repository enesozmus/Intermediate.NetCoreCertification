using Intermediate.Application;
using Intermediate.Persistence;
using Intermediate.Persistence.SeedData;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region @ Layers @

builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureApplicationServices();

#endregion

builder.Services.AddEndpointsApiExplorer();

#region Swagger

builder.Services.AddSwaggerGen(options =>
{
     options.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
     options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
     {
          Description = "Jwt auth header",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
     });
     options.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
          {
               new OpenApiSecurityScheme
               {
                    Reference = new OpenApiReference
                    {
                         Type = ReferenceType.SecurityScheme,
                         Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
               },
               new List<string>()
          }
     });
});

#endregion

#region CORS-1

builder.Services.AddCors(options =>
{
     options.AddDefaultPolicy(policy => policy
     .WithOrigins("http://localhost:5070")
     .AllowAnyHeader()
     .AllowAnyMethod()
     .AllowCredentials());
});

#endregion

var app = builder.Build();

#region @ SeedData@

DbInitializer.Initialize(app);

#endregion

if (app.Environment.IsDevelopment())
{
     app.UseSwagger();
     app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

#region Identity

app.UseAuthentication();
app.UseAuthorization();

#endregion

app.MapControllers();

app.Run();
