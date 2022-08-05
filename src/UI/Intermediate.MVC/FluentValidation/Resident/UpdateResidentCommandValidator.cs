using FluentValidation;
using Intermediate.MVC.Models;

namespace Intermediate.MVC.FluentValidation;

public class UpdateResidentCommandValidator : AbstractValidator<UpdateResidentCommandRequest>
{
     public UpdateResidentCommandValidator()
     {
          RuleFor(p => p.FirstName).NotNull().WithMessage("Lütfen geçerli bir ad giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir ad giriniz!");
          RuleFor(p => p.LastName).NotNull().WithMessage("Lütfen geçerli bir soyad giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir soyad giriniz!");
          RuleFor(p => p.UserName).NotNull().WithMessage("Lütfen geçerli bir kullanıcı adı giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir kullanıcı adı giriniz!");
          RuleFor(p => p.Email).NotNull().WithMessage("Lütfen geçerli bir email giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir email giriniz!");
          RuleFor(p => p.IdentityNumber).NotNull().WithMessage("Lütfen geçerli bir TC No giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir TC No giriniz!");
          RuleFor(p => p.PhoneNumber).NotNull().WithMessage("Lütfen geçerli bir telefon numarası giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir telefon numarası giriniz!");

          RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyadı alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.Email).MinimumLength(8).WithMessage("Email alanı 8 karakterden az olmamalı!");
          RuleFor(p => p.UserName).MinimumLength(2).WithMessage("Kullanıcı adı alanı 2 karakterden az olmamalı!");

          RuleFor(p => p.FirstName).MaximumLength(15).WithMessage("Ad alanı 15 karakterden fazla olmamalı");
          RuleFor(p => p.LastName).MaximumLength(15).WithMessage("Soyadı alanı 15 karakterden fazla olmamalı");
          RuleFor(p => p.Email).MaximumLength(20).WithMessage("Email alanı 20 karakterden fazla olmamalı");
          RuleFor(p => p.UserName).MaximumLength(20).WithMessage("Kullanıcı adı alanı 20 karakterden fazla olmamalı");

          RuleFor(x => x.PhoneNumber).Matches("(05|5)[0-9][0-9][ ][1-9]([0-9]){2}[ ]([0-9]){4}").WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");
          RuleFor(x => x.PhoneNumber).MaximumLength(13).MinimumLength(13).WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");
          RuleFor(x => x.IdentityNumber).MaximumLength(11).MinimumLength(11).WithMessage("Lütfen 11 haneli T.C numaranızı giriniz!");
     }
}