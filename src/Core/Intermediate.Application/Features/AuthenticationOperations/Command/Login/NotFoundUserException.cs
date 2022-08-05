namespace Intermediate.Application.Features.AuthenticationOperations;

public class NotFoundUserException : Exception
{
     public NotFoundUserException() : base("Kullanıcı adı veya şifre hatalı!")
     {
     }

     public NotFoundUserException(string? message) : base(message)
     {
     }

     public NotFoundUserException(string? message, Exception? innerException) : base(message, innerException)
     {
     }
}
