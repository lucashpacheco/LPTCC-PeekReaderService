using System.Threading.Tasks;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;

namespace PeekReaderService.Service.Interfaces
{
    public interface ICommentsRepository
    {
        Task<CommentsDocument> Get(GetCommentsRequest commentsDocument);
    }
}
