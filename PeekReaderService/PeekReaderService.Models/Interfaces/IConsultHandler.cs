using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Domain = Peek.Framework.PeekServices.Domain;


namespace PeekReaderService.Models.Interfaces
{
    public interface IConsultHandler
    {
        Task<ResponseBase<PagedResult<Domain.Peek>>> Get(GetPeeksRequest getPeeksRequest);
        Task<ResponseBase<LikesDocument>> Get(GetLikesRequest getPeeksRequest);
        Task<ResponseBase<CommentsDocument>> Get(GetCommentsRequest getCommentsRequest);

    }
}
