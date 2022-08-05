using FluentValidation;

namespace Intermediate.Application.Features.MessagesOperations;

public class SendMessageCommandValidator : AbstractValidator<SendMessageCommandRequest>
{
     public SendMessageCommandValidator()
     {
          RuleFor(x => x.Text).NotNull().WithMessage("Lütfen geçerli bir mesaj giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir mesaj giriniz!");
          RuleFor(x => x.Text).MaximumLength(240).WithMessage("Mesaj alanı 240 karakteri aşamaz!");
     }
}