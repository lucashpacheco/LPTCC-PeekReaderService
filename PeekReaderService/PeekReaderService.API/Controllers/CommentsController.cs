using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeekReaderService.Models.Common.Responses;
using PeekReaderService.Models.Consults;
using PeekReaderService.Models.Interfaces;
using PeekWriterService.Models.Domain;

namespace PeekReaderService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<PeekController> _logger;
        private readonly IConsultHandler _consultHandler;

        public CommentsController(ILogger<PeekController> logger, IConsultHandler consultHandler)
        {
            _logger = logger;
            _consultHandler = consultHandler;
        }

        [HttpGet]
        public async Task<ResponseBase<CommentsDocument>> Get(GetCommentsRequest getPeeksRequest)
        {
            var result = await _consultHandler.Get(getPeeksRequest);

            return result;
           
        }
    }
}
