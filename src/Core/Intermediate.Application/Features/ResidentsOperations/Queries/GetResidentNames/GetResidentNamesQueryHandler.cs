using AutoMapper;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Application.Features.ResidentsOperations;

public class GetResidentNamesQueryHandler : IRequestHandler<GetResidentNamesQueryRequest, Result<IReadOnlyList<GetResidentNamesQueryResponse>>>
{
     private readonly UserManager<AppUser> _userManager;
     private readonly IMapper _mapper;

     public GetResidentNamesQueryHandler(UserManager<AppUser> userManager, IMapper mapper)
     {
          _userManager = userManager;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetResidentNamesQueryResponse>>> Handle(GetResidentNamesQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var residents = await _userManager.Users.ToListAsync();

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetResidentNamesQueryResponse>>(residents);

          // gönder
          return Result<IReadOnlyList<GetResidentNamesQueryResponse>>.Success(mapped);
     }
}
