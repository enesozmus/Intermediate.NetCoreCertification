using AutoMapper;
using Intermediate.Application.IRepositories;
using Intermediate.Application.Results;
using MediatR;

namespace Intermediate.Application.Features.ApartmentsOperations;

public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommandRequest, Result<Unit>>
{
     private readonly IApartmentReadRepository _readRepository;
     private readonly IApartmentWriteRepository _writeRepository;
     private readonly IMapper _mapper;

     public UpdateApartmentCommandHandler(IApartmentReadRepository readRepository, IApartmentWriteRepository writeRepository, IMapper mapper)
     {
          _readRepository = readRepository;
          _writeRepository = writeRepository;
          _mapper = mapper;
     }

     public async Task<Result<Unit>> Handle(UpdateApartmentCommandRequest request, CancellationToken cancellationToken)
     {
          // getir
          var apartment = await _readRepository.GetByIdAsync(request.Id);

          // eşle
          _mapper.Map(request, apartment);

          // güncelle
          await _writeRepository.UpdateAsync(apartment);

          // gönder
          return Result<Unit>.Success(Unit.Value);
     }
}

