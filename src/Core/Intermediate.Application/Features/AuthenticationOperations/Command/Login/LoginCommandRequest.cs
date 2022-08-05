using MediatR;

namespace Intermediate.Application.Features.AuthenticationOperations;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
     public string Email { get; set; }
     public string Password { get; set; }
}
