using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class RemoveApartmentCommandHandler : IRequestHandler<RemoveApartmentCommandRequest, Result<Unit>>
{
     private readonly IApartmentReadRepository _readRepository;
     private readonly IApartmentWriteRepository _writeRepository;

     public RemoveApartmentCommandHandler(IApartmentReadRepository readRepository, IApartmentWriteRepository writeRepository)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(RemoveApartmentCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartment = await _readRepository.GetByIdAsync(request.Id);

          // sil
          await _writeRepository.RemoveAsync(apartment);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
