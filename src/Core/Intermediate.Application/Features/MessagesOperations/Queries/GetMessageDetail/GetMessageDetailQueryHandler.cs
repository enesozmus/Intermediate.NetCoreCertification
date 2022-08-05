using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.MessagesOperations;

public class GetMessageDetailQueryHandler : IRequestHandler<GetMessageDetailQueryRequest, Result<GetMessageDetailQueryResponse>>
{
     private readonly IMessageReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetMessageDetailQueryHandler(IMessageReadRepository readRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _mapper = mapper;
     }

     public async Task<Result<GetMessageDetailQueryResponse>> Handle(GetMessageDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var message = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          var mapped = _mapper.Map<GetMessageDetailQueryResponse>(message);

          // sonucu gönder
          return Result<GetMessageDetailQueryResponse>.Success(mapped);

     }
}
