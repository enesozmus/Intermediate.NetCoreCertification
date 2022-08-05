using FluentValidation.AspNetCore;
using Intermediate.MVC.FluentValidation;

namespace Intermediate.MVC.Extensions;

public static class AddFluentValidation
{
     public static void AddFluentValidations(this IServiceCollection builder)
     {
          builder.AddFluentValidation(x =>
          {
               x.DisableDataAnnotationsValidation = true;
               x.ImplicitlyValidateChildProperties = true;
               x.RegisterValidatorsFromAssemblyContaining<CreateBlockCommandValidator>();
               x.RegisterValidatorsFromAssemblyContaining<UpdateBlockCommandValidator>();

               x.RegisterValidatorsFromAssemblyContaining<UpdateApartmentTypeCommandValidator>();
               x.RegisterValidatorsFromAssemblyContaining<UpdateApartmentTypeCommandValidator>();

               x.RegisterValidatorsFromAssemblyContaining<UpdateResidentCommandValidator>();
               x.RegisterValidatorsFromAssemblyContaining<UpdateResidentCommandValidator>();

               x.RegisterValidatorsFromAssemblyContaining<UpdateBillCommandValidator>();
               x.RegisterValidatorsFromAssemblyContaining<UpdateBillCommandValidator>();

               x.RegisterValidatorsFromAssemblyContaining<UpdateApartmentCommandValidator>();
               x.RegisterValidatorsFromAssemblyContaining<UpdateApartmentCommandValidator>();

               x.RegisterValidatorsFromAssemblyContaining<SendMessageCommandValidator>();
               x.RegisterValidatorsFromAssemblyContaining<UpdateMessageCommandValidator>();
          });
     }
}
