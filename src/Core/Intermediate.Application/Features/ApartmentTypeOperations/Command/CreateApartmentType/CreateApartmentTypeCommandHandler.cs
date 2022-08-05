using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;

namespace Intermediate.Application.Features.ApartmentTypesOperations;

public class CreateApartmentTypeCommandHandler : IRequestHandler<CreateApartmentTypeCommandRequest, Result<Unit>>
{
     private readonly IApartmentTypeWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public CreateApartmentTypeCommandHandler(IApartmentTypeWriteRepository writeRepository, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateApartmentTypeCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mapped = _mapper.Map<ApartmentType>(request);

          // oluştur
          await _writeRepository.AddAsync(mapped);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

