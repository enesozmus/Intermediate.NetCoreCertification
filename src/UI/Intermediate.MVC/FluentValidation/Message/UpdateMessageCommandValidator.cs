using FluentValidation;
using Intermediate.MVC.Models;

namespace Intermediate.MVC.FluentValidation;

public class UpdateMessageCommandValidator : AbstractValidator<UpdateMessageCommandRequest>
{
     public UpdateMessageCommandValidator()
     {
          RuleFor(x => x.Text).NotNull().WithMessage("Lütfen geçerli bir mesaj giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir mesaj giriniz!");
          RuleFor(x => x.Text).MaximumLength(240).WithMessage("Mesaj alanı 240 karakteri aşamaz!");
     }
}