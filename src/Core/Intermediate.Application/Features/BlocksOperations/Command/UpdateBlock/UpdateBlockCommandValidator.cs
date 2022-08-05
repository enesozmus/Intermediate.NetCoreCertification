using FluentValidation;

namespace Intermediate.Application.Features.BlocksOperations;

public class UpdateBlockCommandValidator : AbstractValidator<UpdateBlockCommandRequest>
{
     public UpdateBlockCommandValidator()
     {
          RuleFor(x => x.BlockName).NotNull().WithMessage("Lütfen geçerli bir blok adı giriniz!").NotEmpty().WithMessage("Lütfen geçerli bir blok adı giriniz!");
          RuleFor(x => x.Address).NotNull().WithMessage("Lütfen geçerli bir blok adı giriniz!").NotEmpty().WithMessage("Lütfen geçerli bir adres giriniz!");
          RuleFor(x => x.TotalFlats).NotNull().WithMessage("Lütfen geçerli bir kat sayısı giriniz!").NotEmpty().WithMessage("Lütfen geçerli bir kat sayısı giriniz!");
          RuleFor(x => x.TotalFloors).NotNull().WithMessage("Lütfen geçerli bir daire sayısı giriniz!").NotEmpty().WithMessage("Lütfen geçerli bir daire sayısı giriniz!");

          RuleFor(x => x.TotalFlats).GreaterThan(0).WithMessage("Toplam kat sayısı sıfırdan küçük olamaz!");
          RuleFor(x => x.TotalFlats).LessThan(1000).WithMessage("Toplam kat sayısı binden küçük olmalıdır!");
          RuleFor(x => x.TotalFloors).GreaterThan(0).WithMessage("Toplam daire sayısı sıfırdan küçük olamaz!");
          RuleFor(x => x.TotalFloors).LessThan(10000).WithMessage("Toplam daire sayısı on binden küçük olmalıdır!");

          RuleFor(x => x.Address).MinimumLength(12).WithMessage("Adres bilgisi on iki karakterden az olamaz!");
     }
}