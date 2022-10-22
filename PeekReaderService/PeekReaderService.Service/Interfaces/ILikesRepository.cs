using System.Collections.Generic;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Domain = Peek.Framework.PeekServices.Domain;

namespace PeekReaderService.Service.Interfaces
{
    public interface ILikesRepository
    {
        Task<List<Domain.Like>> Get(GetLikesRequest getLikesRequest);
        Task<int> Get(GetLikesCountRequest getLikesCountRequest);

    }
}
