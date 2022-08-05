using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class CreateBlockCommandHandler : IRequestHandler<CreateBlockCommandRequest, Result<Unit>>
{
     private readonly IBlockWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public CreateBlockCommandHandler(IBlockWriteRepository writeRepository, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateBlockCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mapped = _mapper.Map<Block>(request);

          // oluştur
          await _writeRepository.AddAsync(mapped);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

