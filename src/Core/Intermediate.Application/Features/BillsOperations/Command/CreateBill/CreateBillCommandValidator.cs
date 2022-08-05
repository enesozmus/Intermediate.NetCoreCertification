using FluentValidation;

namespace Intermediate.Application.Features.BillsOperations;

public class CreateBillCommandValidator : AbstractValidator<CreateBillCommandRequest>
{
     public CreateBillCommandValidator()
     {
          RuleFor(x => x.AmountPayable).GreaterThan(0).WithMessage("Fatura tutarı sıfırdan küçük olamaz!");
          RuleFor(x => x.DeadlineDate).GreaterThan(DateTime.Now).WithMessage("Son ödeme tarihi bugünden ileri bir tarih olmalıdır!");
     }
}