using Intermediate.MVC.Models;

namespace Intermediate.MVC.Services;

public interface IBlockService
{
     Task<IReadOnlyList<GetBlocksQueryResponse>> GetBlocksAsync();
     Task<HttpResponseMessage> CreateBlock(CreateBlockCommandRequest request);
     // Güncelleyeceğimiz entity'nin bilgilerini kolaylık sağlamak adına forma çekiyoruz.
     Task<UpdateBlockCommandRequest> GetViewForUpdateBlock(int id);
     Task<HttpResponseMessage> UpdateBlock(UpdateBlockCommandRequest request);
     Task<HttpResponseMessage> RemoveBlock(int id);
}
