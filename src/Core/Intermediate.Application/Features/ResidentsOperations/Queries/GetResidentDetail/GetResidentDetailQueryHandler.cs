using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentDetailQueryHandler : IRequestHandler<GetResidentDetailQueryRequest, Result<GetResidentDetailQueryResponse>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public GetResidentDetailQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<GetResidentDetailQueryResponse>> Handle(GetResidentDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var resident = await _userManager.Users
               .FirstOrDefaultAsync(x => x.Id == request.Id);

          // eşle
          var mapped = _mapper.Map<GetResidentDetailQueryResponse>(resident);

          // gönder
          return Result<GetResidentDetailQueryResponse>.Success(mapped);
     }
}
