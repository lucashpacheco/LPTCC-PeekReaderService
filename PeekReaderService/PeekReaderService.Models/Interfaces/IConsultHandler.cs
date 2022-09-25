using System.Threading.Tasks;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;

namespace PeekReaderService.Models.Interfaces
{
    public interface IConsultHandler
    {
        Task<ResponseBase<bool>> Get(GetLikesRequest getLikesRequest);
        Task<ResponseBase<bool>> Get(GetPeeksRequest getPeeksRequest);
        Task<ResponseBase<bool>> Get(GetCommentsRequest getCommentsRequest);

    }
}
