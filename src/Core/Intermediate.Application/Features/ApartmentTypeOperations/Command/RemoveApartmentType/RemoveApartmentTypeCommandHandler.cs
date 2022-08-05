using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class RemoveApartmentTypeCommandHandler : IRequestHandler<RemoveApartmentTypeCommandRequest, Result<Unit>>
{
     private readonly IApartmentTypeReadRepository _readRepository;
     private readonly IApartmentTypeWriteRepository _writeRepository;

     public RemoveApartmentTypeCommandHandler(IApartmentTypeReadRepository readRepository, IApartmentTypeWriteRepository writeRepository)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
     }

     public async Task<Result<Unit>> Handle(RemoveApartmentTypeCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartmentType = await _readRepository.GetByIdAsync(request.Id);

          // sil
          await _writeRepository.RemoveAsync(apartmentType);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}
