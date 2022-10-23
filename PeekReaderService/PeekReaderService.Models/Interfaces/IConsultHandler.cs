using System.Threading.Tasks;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Domain = Peek.Framework.PeekServices.Domain;


namespace PeekReaderService.Models.Interfaces
{
    public interface IConsultHandler
    {
        Task<ResponseBase<PagedResult<Domain.Peek>>> Get(GetPeeksRequest getPeeksRequest);
        Task<ResponseBase<PagedResult<Domain.Like>>> Get(GetLikesRequest getPeeksRequest);
        Task<ResponseBase<PagedResult<Domain.Comment>>> Get(GetCommentsRequest getCommentsRequest);
        Task<ResponseBase<int>> Get(GetLikesCountRequest getLikesCountRequest);
        Task<ResponseBase<int>> Get(GetCommentsCountRequest getCommentsRequest);
    }
}
