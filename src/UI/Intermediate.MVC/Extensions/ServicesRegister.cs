using Intermediate.MVC.Services;

namespace Intermediate.MVC.Extensions;

public static class ServicesRegister
{
     public static void AddCustomServices(this IServiceCollection builder)
     {
          builder.AddHttpClient();
          builder.AddScoped<IProfileService, ProfileService>();
          builder.AddScoped<IApartmentService, ApartmentService>();
          builder.AddScoped<IBlockService, BlockService>();
          builder.AddScoped<IApartmentTypeService, ApartmentTypeService>();
          builder.AddScoped<IResidentService, ResidentService>();
          builder.AddScoped<IBillService, BillService>();
          builder.AddScoped<IMessageService, MessageService>();
     }
}
