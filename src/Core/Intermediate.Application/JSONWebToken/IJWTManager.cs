using Intermediate.Application.Features.AuthenticationOperations;

namespace Intermediate.Application.JSONWebToken;

public interface IJWTManager
{
     string GenerateJSONWebToken(LoginCommandResponse userInfo);
}
