using AutoMapper;
using Intermediate.Application.Interfaces;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class GetSentMessagesQueryHandler : IRequestHandler<GetSentMessagesQueryRequest, Result<IReadOnlyList<GetSentMessagesQueryResponse>>>
{
     private readonly IUserAccessor _userAccessor;
     private readonly IMessageReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetSentMessagesQueryHandler(IUserAccessor userAccessor, IMessageReadRepository readRepository, IMapper mapper)
     {
          _userAccessor = userAccessor;
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetSentMessagesQueryResponse>>> Handle(GetSentMessagesQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var messages = await _readRepository.GetAsync(x => x.SendUser.UserName == _userAccessor.GetUsername());

          if (messages == null) return null;

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetSentMessagesQueryResponse>>(messages);

          // gönder
          return Result<IReadOnlyList<GetSentMessagesQueryResponse>>.Success(mapped);
     }
}