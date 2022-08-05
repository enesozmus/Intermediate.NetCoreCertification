using Intermediate.Application.Features.ApartmentsOperations;
using Intermediate.Domain.Entities;
using System.Linq.Expressions;

namespace Intermediate.Application.IRepositories;

public interface IApartmentReadRepository : IReadRepository<Apartment>
{
     Task<IReadOnlyList<Apartment>> GetApartments();
     Task<IReadOnlyList<Apartment>> GetUserApartments(Expression<Func<Apartment, bool>> predicate);
     Task<Apartment> GetApartment(int id);
}
