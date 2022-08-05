using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.BlocksOperations;

public class RemoveBlockCommandHandler : IRequestHandler<RemoveBlockCommandRequest, Result<Unit>>
{
     private readonly IBlockReadRepository _readRepository;
     private readonly IBlockWriteRepository _writeRepository;

     public RemoveBlockCommandHandler(IBlockReadRepository readRepository, IBlockWriteRepository writeRepository)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(RemoveBlockCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var block = await _readRepository.GetByIdAsync(request.Id);

          // sil
          await _writeRepository.RemoveAsync(block);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
