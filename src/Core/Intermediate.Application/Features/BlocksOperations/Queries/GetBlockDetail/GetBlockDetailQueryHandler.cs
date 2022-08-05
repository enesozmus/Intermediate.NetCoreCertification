using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class GetBlockDetailQueryHandler : IRequestHandler<GetBlockDetailQueryRequest, Result<GetBlocksQueryResponse>>
{
     private readonly IBlockReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetBlockDetailQueryHandler(IBlockReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }
     public async Task<Result<GetBlocksQueryResponse>> Handle(GetBlockDetailQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var block = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          var mapped = _mapper.Map<GetBlocksQueryResponse>(block);

          // gönder
          return Result<GetBlocksQueryResponse>.Success(mapped);
     }
}
