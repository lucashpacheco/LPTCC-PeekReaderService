using System.Collections.Generic;
using System.Threading.Tasks;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;
using PeekReaderService.Models.Interfaces;
using PeekReaderService.Service.Interfaces;
using PeekWriterService.Models.Domain;

namespace PeekReaderService.Service
{
    public class ConsultHandler : IConsultHandler
    {
        private readonly ILikesRepository _likesRepository;
        private readonly IPeekRepository _peekRepository;
        private readonly ICommentsRepository _commentsRepository;

        public ConsultHandler(IPeekRepository peekRepository, ICommentsRepository commentsRepository, ILikesRepository likesRepository)
        {
            _peekRepository = peekRepository;
            _commentsRepository = commentsRepository;
            _likesRepository = likesRepository;
        }

        public async Task<ResponseBase<PeekDocument>> Get(GetPeeksRequest getPeeksRequest)
        {
            var response = new ResponseBase<PeekDocument>(success: false, errors: new List<string>(), data: null);

            var result = await _peekRepository.Get(getPeeksRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<LikesDocument>> Get(GetLikesRequest getLikesRequest)
        {
            var response = new ResponseBase<LikesDocument>(success: false, errors: new List<string>(), data: null);
            
            var result = await _likesRepository.Get(getLikesRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<CommentsDocument>> Get(GetCommentsRequest getCommentsRequest)
        {
            var response = new ResponseBase<CommentsDocument>(success: false, errors: new List<string>(), data: null);

            var result = await _commentsRepository.Get(getCommentsRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }
    }
}
