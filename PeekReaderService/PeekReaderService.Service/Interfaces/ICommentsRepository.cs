using System.Collections.Generic;
using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Domain = Peek.Framework.PeekServices.Domain;

namespace PeekReaderService.Service.Interfaces
{
    public interface ICommentsRepository
    {
        Task<List<Domain.Comment>> Get(GetCommentsRequest commentsDocument);
        Task<int> Get(GetCommentsCountRequest getCommentsCountRequest);
    }
}
