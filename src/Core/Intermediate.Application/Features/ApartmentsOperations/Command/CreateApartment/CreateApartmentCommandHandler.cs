using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using Intermediate.Domain.Entities;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommandRequest, Result<Unit>>
{
     private readonly IApartmentWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public CreateApartmentCommandHandler(IApartmentWriteRepository writeRepository, IMapper mapper)
     {
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(CreateApartmentCommandRequest request, CancellationToken cancellationToken)
     {
          // eşle
          var mapped = _mapper.Map<Apartment>(request);

          // oluştur
          await _writeRepository.AddAsync(mapped);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

