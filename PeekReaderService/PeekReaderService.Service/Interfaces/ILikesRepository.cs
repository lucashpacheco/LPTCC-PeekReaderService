using System.Collections.Generic;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;

namespace PeekReaderService.Service.Interfaces
{
    public interface ILikesRepository
    {
        Task<List<LikesDocument>> Get(GetLikesRequest getLikesRequest);
        Task<int> Get(GetLikesCountRequest getLikesCountRequest);

    }
}
