using System;
using System.Threading.Tasks;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;
using PeekReaderService.Models.Interfaces;

namespace PeekReaderService.Service
{
    public class ConsultHandler : IConsultHandler
    {
        public Task<ResponseBase<bool>> Get(GetLikesRequest getLikesRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase<bool>> Get(GetPeeksRequest getPeeksRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase<bool>> Get(GetCommentsRequest getCommentsRequest)
        {
            throw new NotImplementedException();
        }
    }
}
