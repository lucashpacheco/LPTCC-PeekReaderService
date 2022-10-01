using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peek.Framework.Common.Utils;
using Peek.Framework.PeekServices.PeekReader.Consults;
using PeekReaderService.Models.Interfaces;

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

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetPeeksRequest getPeeksRequest)
        {
            var result = await _consultHandler.Get(getPeeksRequest);

            return CustomResponse(result);

        }
    }
}
