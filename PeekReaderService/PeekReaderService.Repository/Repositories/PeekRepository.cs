using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Peek.Framework.PeekServices.PeekReader.Consults;
using PeekReaderService.Models;
using PeekReaderService.Repository.Contexts;
using PeekReaderService.Service;
using PeekReaderService.Service.Interfaces;
using Domain = Peek.Framework.PeekServices.Domain;
using NW = Newtonsoft.Json;

namespace PeekReaderService.Repository.Repositories
{
    public class PeekRepository : IPeekRepository
    {
        public readonly PeekContext _peekContext;
        private readonly ILogger<PeekRepository> _logger;

        public PeekRepository(ILogger<PeekRepository> logger, IOptions<ConfigDb> options)
        {
            _peekContext = new PeekContext(options);
            _logger = logger;

        }

        public async Task<List<Domain.Peek>> Get(GetPeeksRequest getPeeksRequest)
        {
            _logger.Log(LogLevel.Information, $"[ConsultHandler] - GetPeeksRequest received in repository : {NW.JsonConvert.SerializeObject(getPeeksRequest)}");
            List<Domain.Peek> result;
            if (getPeeksRequest.UserId.Count > 1)
                result = await _peekContext.Peek.Find(x => getPeeksRequest.UserId.Contains(x.AuthorId))
                    .Skip(getPeeksRequest.PageInformation.Offset)
                    .Limit(getPeeksRequest.PageInformation.PageSize)
                    .SortByDescending(c => c.CreatedDate)
                    .ToListAsync();
            else if (getPeeksRequest.UserId.Count == 1)
                result = await _peekContext.Peek.Find(x => x.Id == getPeeksRequest.UserId[0])
                    .Skip(getPeeksRequest.PageInformation.Offset)
                    .Limit(getPeeksRequest.PageInformation.PageSize)
                    .SortByDescending(c => c.CreatedDate)
                    .ToListAsync();
            else
                result = await _peekContext.Peek.Find(new BsonDocument())
                    .Skip(getPeeksRequest.PageInformation.Offset)
                    .Limit(getPeeksRequest.PageInformation.PageSize)
                    .SortByDescending(c => c.CreatedDate)
                    .ToListAsync();

            return result;
        }
    }
}
