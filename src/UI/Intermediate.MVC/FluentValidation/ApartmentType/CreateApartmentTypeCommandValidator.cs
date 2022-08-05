using FluentValidation;
using Intermediate.MVC.Models;

namespace Intermediate.MVC.FluentValidation;

public class CreateApartmentTypeCommandValidator : AbstractValidator<CreateApartmentTypeCommandRequest>
{
     public CreateApartmentTypeCommandValidator()
     {
          RuleFor(x => x.Type).NotNull().WithMessage("Lütfen geçerli bir daire tipi giriniz!").NotEmpty().WithMessage("Lütfen geçerli bir daire tipi giriniz!");
          RuleFor(x => x.Type).MaximumLength(3).NotEmpty().WithMessage("Apartman daire tipi üç karakteri aşamaz!(1+1, 3+2 vs.)");
          RuleFor(x => x.Type).Must(BeAValidParameter).WithMessage("Girdiğiniz değer bir '+' içermelidir!");
     }
     private static bool BeAValidParameter(string arg)
     {
          if (arg != null)
               return arg.Contains("+");
          return false;
     }
}