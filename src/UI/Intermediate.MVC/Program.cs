using Intermediate.MVC.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// FluentValidations
builder.Services.AddFluentValidations();

// Services
builder.Services.AddCustomServices();


#region JwtBearerDefaults

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
        {
             options.LoginPath = "/Auth/Login";
             options.LogoutPath = "/Auth/Logout";
             options.AccessDeniedPath = "/Auth/AccessDenied";
             options.Cookie.SameSite = SameSiteMode.Strict;
             options.Cookie.HttpOnly = true;
             options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
             options.Cookie.Name = "IntermediateCertificate";
        });
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
     app.UseExceptionHandler("/Home/Error");
     app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

#region Identity

app.UseAuthentication();
app.UseAuthorization();

#endregion

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
