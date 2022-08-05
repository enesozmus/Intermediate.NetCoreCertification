using FluentValidation;
using Intermediate.MVC.Models;

namespace Intermediate.MVC.FluentValidation;

public class UpdateBillCommandValidator : AbstractValidator<UpdateBillCommandRequest>
{
     public UpdateBillCommandValidator()
     {
          RuleFor(x => x.AmountPayable).GreaterThan(0).WithMessage("Fatura tutarı sıfırdan küçük olamaz!");
          RuleFor(x => x.DeadlineDate).GreaterThan(DateTime.Now).WithMessage("Son ödeme tarihi bugünden ileri bir tarih olmalıdır!");
     }
}