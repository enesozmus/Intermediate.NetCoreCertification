using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class GetBlocksQueryHandler : IRequestHandler<GetBlocksQueryRequest, Result<IReadOnlyList<GetBlocksQueryResponse>>>
{
     private readonly IBlockReadRepository _readRepository;
     private readonly IMapper _mapper;

     public GetBlocksQueryHandler(IBlockReadRepository repository, IMapper mapper)
     {
          _readRepository = repository;
          _mapper = mapper;
     }

     public async Task<Result<IReadOnlyList<GetBlocksQueryResponse>>> Handle(GetBlocksQueryRequest request, CancellationToken cancellationToken)
     {
          // getir
          var blocks = await _readRepository.GetAllAsync();

          // eşle
          var mapped = _mapper.Map<IReadOnlyList<GetBlocksQueryResponse>>(blocks);

          // gönder
          return Result<IReadOnlyList<GetBlocksQueryResponse>>.Success(mapped);
     }
}
