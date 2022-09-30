using System.Threading.Tasks;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;
using PeekWriterService.Models.Domain;

namespace PeekReaderService.Models.Interfaces
{
    public interface IConsultHandler
    {
        Task<ResponseBase<PeekDocument>> Get(GetPeeksRequest getPeeksRequest);
        Task<ResponseBase<LikesDocument>> Get(GetLikesRequest getPeeksRequest);
        Task<ResponseBase<CommentsDocument>> Get(GetCommentsRequest getCommentsRequest);

    }
}
