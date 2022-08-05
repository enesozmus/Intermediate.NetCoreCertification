using FluentValidation;
using Intermediate.MVC.Models;

namespace Intermediate.MVC.FluentValidation;

public class CreateBillCommandValidator : AbstractValidator<CreateBillCommandRequest>
{
     public CreateBillCommandValidator()
     {
          RuleFor(x => x.AmountPayable).GreaterThan(0)
               .WithMessage("Fatura tutarı sıfırdan küçük olamaz!");
          RuleFor(x => x.DeadlineDate).GreaterThan(DateTime.Now)
               .WithMessage("Son ödeme tarihi bugünden ileri bir tarih olmalıdır!");
          RuleFor(x => x.AppUserId).GreaterThan(0)
               .WithMessage("Lütfen geçerli bir kullanıcı seçiniz!");
          RuleFor(x => x.AppUserId).NotEmpty()
               .WithMessage("Lütfen geçerli bir kullanıcı seçiniz!");
     }
}