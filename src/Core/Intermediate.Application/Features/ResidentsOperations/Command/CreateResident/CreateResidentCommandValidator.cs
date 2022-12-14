using FluentValidation;
using System.Text.RegularExpressions;

namespace Intermediate.Application.Features.ResidentsOperations;

public class CreateResidentCommandValidator : AbstractValidator<CreateResidentCommandRequest>
{
     public CreateResidentCommandValidator()
     {
          RuleFor(p => p.FirstName).NotNull().WithMessage("Lütfen geçerli bir ad giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir ad giriniz!");
          RuleFor(p => p.LastName).NotNull().WithMessage("Lütfen geçerli bir soyad giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir soyad giriniz!");
          RuleFor(p => p.UserName).NotNull().WithMessage("Lütfen geçerli bir kullanıcı adı giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir kullanıcı adı giriniz!");
          RuleFor(p => p.Email).NotNull().WithMessage("Lütfen geçerli bir email giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir email giriniz!");
          RuleFor(p => p.Password).NotNull().WithMessage("Lütfen geçerli bir parola giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir parola giriniz!");
          RuleFor(p => p.IdentityNumber).NotNull().WithMessage("Lütfen geçerli bir TC No giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir TC No giriniz!");
          RuleFor(p => p.PhoneNumber).NotNull().WithMessage("Lütfen geçerli bir telefon numarası giriniz!")
               .NotEmpty().WithMessage("Lütfen geçerli bir telefon numarası giriniz!");

          RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyadı alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.Email).MinimumLength(8).WithMessage("Email alanı 8 karakterden az olmamalı!");
          RuleFor(p => p.UserName).MinimumLength(2).WithMessage("Kullanıcı adı alanı 2 karakterden az olmamalı!");
          RuleFor(p => p.Password).MinimumLength(8).WithMessage("Parola alanı 8 karakterden az olmamalı!");

          RuleFor(p => p.FirstName).MaximumLength(15).WithMessage("Ad alanı 15 karakterden fazla olmamalı");
          RuleFor(p => p.LastName).MaximumLength(15).WithMessage("Soyadı alanı 15 karakterden fazla olmamalı");
          RuleFor(p => p.Email).MaximumLength(20).WithMessage("Email alanı 20 karakterden fazla olmamalı");
          RuleFor(p => p.UserName).MaximumLength(20).WithMessage("Kullanıcı adı alanı 20 karakterden fazla olmamalı");
          RuleFor(p => p.Password).MaximumLength(20).WithMessage("Parola alanı 20 karakterden fazla olmamalı");

          RuleFor(x => x.PhoneNumber).Matches("(05|5)[0-9][0-9][ ][1-9]([0-9]){2}[ ]([0-9]){4}").WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");
          RuleFor(x => x.PhoneNumber).MaximumLength(13).MinimumLength(13).WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");
          RuleFor(x => x.IdentityNumber).MaximumLength(11).MinimumLength(11).WithMessage("Lütfen 11 haneli T.C numaranızı giriniz!");

          RuleFor(p => p.Password).Must(p => HasValidPassword(p)).WithMessage("Parola bir rakam[0-9], büyük[A-Z] ve küçük karakter[a-z] ve alfanümerik olmayan bir karakter içermelidir.");
     }

     private bool HasValidPassword(string pw)
     {
          var lowercase = new Regex("[a-z]+");
          var uppercase = new Regex("[A-Z]+");
          var digit = new Regex("(\\d)+");
          var symbol = new Regex("(\\W)+");

          return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
     }
}
