namespace Intermediate.Application.Features.ResidentsOperations;

public class ResidentCreateFailedException : Exception
{
     public ResidentCreateFailedException() : base("Kullanıcı oluşturulurken beklenmeyen bir hatayla karşılaşıldı!")
     {
     }

     public ResidentCreateFailedException(string? message) : base(message)
     {
     }

     public ResidentCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
     {
     }
}
