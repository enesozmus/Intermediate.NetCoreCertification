using FluentValidation;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class UpdateApartmentCommandValidator : AbstractValidator<UpdateApartmentCommandRequest>
{
     public UpdateApartmentCommandValidator()
     {
          RuleFor(x => x.Floor).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir kat bilgisi giriniz!");
          RuleFor(x => x.Floor).GreaterThan(1).WithMessage("Kat bilgisi birden küçük olamaz!");
          RuleFor(x => x.Floor).LessThan(1000).WithMessage("Lütfen en fazla üç haneli bir kat bilgisi giriniz!");

          RuleFor(x => x.DoorNumber).NotNull().NotEmpty().WithMessage("Lütfen geçerli bir kapı numarası bilgisi giriniz!");
          RuleFor(x => x.DoorNumber).GreaterThan(1).WithMessage("Kapı numarası bilgisi birden küçük olamaz!");
          RuleFor(x => x.DoorNumber).LessThan(10000).WithMessage("Lütfen en fazla dört haneli bir kapı numarası bilgisi giriniz!");
     }
}