namespace Intermediate.Application.Features.AuthenticationOperations;

public class LoginCommandResponse
{
     public int Id { get; set; }
     public string UserName { get; set; }
     public string Token { get; set; }
     public bool IsSuccess { get; set; }
}
