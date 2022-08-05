using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class UpdateApartmentTypeCommandHandler : IRequestHandler<UpdateApartmentTypeCommandRequest, Result<Unit>>
{
     private readonly IApartmentTypeReadRepository _readRepository;
     private readonly IApartmentTypeWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public UpdateApartmentTypeCommandHandler(IApartmentTypeReadRepository readRepository, IApartmentTypeWriteRepository writeRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateApartmentTypeCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartmentType = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          _mapper.Map(request, apartmentType);

          // güncelle
          await _writeRepository.UpdateAsync(apartmentType);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

