using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekReader.Consults;
using Peek.Framework.UserService.Consults;
using PeekReaderService.Models.Interfaces;
using NW = Newtonsoft.Json;

namespace PeekReaderService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeekController : BaseController
    {
        private readonly ILogger<PeekController> _logger;
        private readonly IConsultHandler _consultHandler;

        public PeekController(ILogger<PeekController> logger, IConsultHandler consultHandler)
        {
            _logger = logger;
            _consultHandler = consultHandler;
        }

        [HttpPost]
        public async Task<ActionResult> Get([FromBody] GetPeeksRequest getPeeksRequest)
        {
            _logger.Log(LogLevel.Information, $"[RequestReceived] - GetPeeksRequest received in SERVICE controller : {NW.JsonConvert.SerializeObject(getPeeksRequest)}");

            var result = await _consultHandler.Get(getPeeksRequest);

            return CustomResponse(result);

        }
    }
}
