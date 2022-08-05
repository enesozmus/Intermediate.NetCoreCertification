using Intermediate.Domain.Entities;

namespace Intermediate.Application.IRepositories;

public interface IBillReadRepository : IReadRepository<Bill>
{
     Task<IReadOnlyList<Bill>> GetBills();
     Task<Bill> GetBill(int id);
}
