using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class UpdateBlockCommandHandler : IRequestHandler<UpdateBlockCommandRequest, Result<Unit>>
{
     private readonly IBlockReadRepository _readRepository;
     private readonly IBlockWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public UpdateBlockCommandHandler(IBlockReadRepository readRepository, IBlockWriteRepository writeRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateBlockCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var block = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          _mapper.Map(request, block);

          // güncelle
          await _writeRepository.UpdateAsync(block);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

