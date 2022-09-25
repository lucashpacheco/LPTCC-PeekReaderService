using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeekReaderService.Models.Consults;
using PeekReaderService.Repository.Contexts;
using PeekReaderService.Service.Interfaces;
using PeekWriterService.API.Config;
using PeekWriterService.Models.Domain;

namespace PeekReaderService.Repository.Repositories
{
    public class PeekRepository : IPeekRepository
    {
        public readonly PeekContext _peekContext;
        public PeekRepository(IOptions<ConfigDb> options)
        {
            _peekContext = new PeekContext(options);
        }

        public async Task<PeekDocument> Get(GetPeeksRequest getPeeksRequest)
        {
            var result = await _peekContext.Peek.FindAsync(x => x.Id == getPeeksRequest.PeekId);

            return result.FirstOrDefault();
        }
    }
}
