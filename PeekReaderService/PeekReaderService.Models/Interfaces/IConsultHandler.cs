using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;

namespace PeekReaderService.Models.Interfaces
{
    public interface IConsultHandler
    {
        Task<ResponseBase<PeekDocument>> Get(GetPeeksRequest getPeeksRequest);
        Task<ResponseBase<LikesDocument>> Get(GetLikesRequest getPeeksRequest);
        Task<ResponseBase<CommentsDocument>> Get(GetCommentsRequest getCommentsRequest);

    }
}
