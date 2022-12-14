using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Responses;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.PeekServices.PeekReader.Responses;
using PeekReaderService.Models.Interfaces;
using PeekReaderService.Service.Interfaces;
using Domain = Peek.Framework.PeekServices.Domain;
using NW = Newtonsoft.Json;

namespace PeekReaderService.Service
{
    public class ConsultHandler : IConsultHandler
    {
        private readonly ILikesRepository _likesRepository;
        private readonly IPeekRepository _peekRepository;
        private readonly ICommentsRepository _commentsRepository;
        private readonly ILogger<ConsultHandler> _logger;


        public ConsultHandler(ILogger<ConsultHandler> logger, IPeekRepository peekRepository, ICommentsRepository commentsRepository, ILikesRepository likesRepository)
        {
            _peekRepository = peekRepository;
            _commentsRepository = commentsRepository;
            _likesRepository = likesRepository;
            _logger = logger;
        }

        public async Task<ResponseBase<PagedResult<Domain.Peek>>> Get(GetPeeksRequest getPeeksRequest)
        {
            _logger.Log(LogLevel.Information, $"[ConsultHandler] - GetPeeksRequest received in handler : {NW.JsonConvert.SerializeObject(getPeeksRequest)}");

            var response = new ResponseBase<PagedResult<Domain.Peek>>(success: false, errors: new List<string>(), data: new PagedResult<Domain.Peek>());

            var result = await _peekRepository.Get(getPeeksRequest);

            if (result == null)
            {
                _logger.Log(LogLevel.Error, $"[ConsultHandler] - Unable to get peeks ");

                return response;
            }

            response.Success = true;
            response.Data.Result = result;
            response.Data.TotalItems = 0;

            return response;
        }

        public async Task<ResponseBase<PagedResult<LikesResponse>>> Get(GetLikesRequest getLikesRequest)
        {
            var response = new ResponseBase<PagedResult<LikesResponse>>(success: false, errors: new List<string>(), data: null);

            var result = await _likesRepository.Get(getLikesRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = new PagedResult<LikesResponse>();

            response.Data.Result = new List<LikesResponse>();
            result.ForEach(x => response.Data.Result.Add(new LikesResponse(x)));

            response.Data.TotalItems = 0;

            return response;
        }

        public async Task<ResponseBase<PagedResult<Domain.Comment>>> Get(GetCommentsRequest getCommentsRequest)
        {
            var response = new ResponseBase<PagedResult<Domain.Comment>>(success: false, errors: new List<string>(), data: null);

            var result = await _commentsRepository.Get(getCommentsRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = new PagedResult<Domain.Comment>();
            response.Data.Result = result;
            response.Data.TotalItems = 0;

            return response;
        }

        public async Task<ResponseBase<int>> Get(GetLikesCountRequest getLikesCountRequest)
        {
            var response = new ResponseBase<int>(success: false, errors: new List<string>(), data: 0);

            var result = await _likesRepository.Get(getLikesCountRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }

        public async Task<ResponseBase<int>> Get(GetCommentsCountRequest getCommentsRequest)
        {
            var response = new ResponseBase<int>(success: false, errors: new List<string>(), data: 0);

            var result = await _commentsRepository.Get(getCommentsRequest);

            if (result == null)
                return response;

            response.Success = true;
            response.Data = result;

            return response;
        }
    }
}
