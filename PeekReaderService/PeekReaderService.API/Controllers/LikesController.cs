using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekReader.Consults;
using PeekReaderService.Models.Interfaces;
using NW = Newtonsoft.Json;

namespace PeekReaderService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikesController : BaseController
    {
        private readonly ILogger<PeekController> _logger;
        private readonly IConsultHandler _consultHandler;

        public LikesController(ILogger<PeekController> logger, IConsultHandler consultHandler)
        {
            _logger = logger;
            _consultHandler = consultHandler;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetLikesRequest getPeeksRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetLikesRequest received in SERVICE controller : {NW.JsonConvert.SerializeObject(getPeeksRequest)}");

            var result = await _consultHandler.Get(getPeeksRequest);

            return CustomResponse(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult> Get([FromQuery] GetLikesCountRequest getPeeksRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetLikesCountRequest received in SERVICE controller : {NW.JsonConvert.SerializeObject(getPeeksRequest)}");

            var result = await _consultHandler.Get(getPeeksRequest);

            return CustomResponse(result);
        }
    }
}
