using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class GetIncomingMessagesQueryHandler : IRequestHandler<GetIncomingMessagesQueryRequest, Result<IReadOnlyList<GetIncomingMessagesQueryResponse>>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly IMessageReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetIncomingMessagesQueryHandler(IUserAccessor userAccessor, IMessageReadRepository readRepository, IMapper mapper)
     {
          _userAccessor = userAccessor;
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetIncomingMessagesQueryResponse>>> Handle(GetIncomingMessagesQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var messages = await _readRepository.GetAsync(x => x.ReceiveUser.UserName == _userAccessor.GetUsername());

          if (messages == null) return null;

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetIncomingMessagesQueryResponse>>(messages);

          // gönder
          return Result<IReadOnlyList<GetIncomingMessagesQueryResponse>>.Success(mapped);
     }
}