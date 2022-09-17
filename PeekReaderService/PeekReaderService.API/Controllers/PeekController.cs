using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PeekReaderService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeekController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PeekController> _logger;

        public PeekController(ILogger<PeekController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
           
        }
    }
}
