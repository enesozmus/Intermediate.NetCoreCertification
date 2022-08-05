using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ProfilesOperations;

public class GetUserBillsQueryHandler : IRequestHandler<GetUserBillsQueryRequest, Result<IReadOnlyList<GetUserBillsQueryResponse>>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly IBillReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetUserBillsQueryHandler(IUserAccessor userAccessor, IBillReadRepository readRepository, IMapper mapper)
     {
          _userAccessor = userAccessor;
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetUserBillsQueryResponse>>> Handle(GetUserBillsQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var bills = await _readRepository.GetAsync(x => x.AppUser.UserName == _userAccessor.GetUsername());

          if (bills == null) return null;

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetUserBillsQueryResponse>>(bills);

          // gönder
          return Result<IReadOnlyList<GetUserBillsQueryResponse>>.Success(mapped);
     }
}