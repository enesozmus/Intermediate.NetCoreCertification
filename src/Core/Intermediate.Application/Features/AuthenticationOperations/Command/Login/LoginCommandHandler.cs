using AutoMapper;
using Intermediate.Application.JSONWebToken;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Intermediate.Application.Features.AuthenticationOperations;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IJWTManager _jwtManager;
     private readonly IMapper _mapper;

     public LoginCommandHandler(UserManager<AppUser> userManager, IJWTManager jwtManager, IMapper mapper)
     {
          _userManager = userManager;
          _jwtManager = jwtManager;
          _mapper = mapper;
     }

     public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
     {
          var user = _userManager
               .Users
               //.Include(x => x.Photos)
               .SingleOrDefault(u => u.Email == request.Email);
          if (user is null)
               throw new NotFoundUserException("Kullanıcı veya şifre hatalı!");

          var userModel = _mapper.Map<LoginCommandResponse>(user);
          var userSigninResult = await _userManager.CheckPasswordAsync(user, request.Password);

          LoginCommandResponse response = new();
          if (userSigninResult)
          {
               response.Id = userModel.Id;
               response.IsSuccess = true;
               //response.FirstName = userModel.FirstName;
               //response.LastName = userModel.LastName;
               response.UserName = userModel.UserName;
               //response.Email = userModel.Email;
               response.Token = _jwtManager.GenerateJSONWebToken(response);
               return response;
          }
          else
               throw new NotFoundUserException("Kullanıcı veya şifre hatalı!");
     }
}
