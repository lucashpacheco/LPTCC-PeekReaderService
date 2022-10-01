using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using PeekReaderService.Models;
using PeekReaderService.Repository.Contexts;
using PeekReaderService.Service.Interfaces;

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
            var result = await _peekContext.Peek.FindAsync(x => x.AuthorId == getPeeksRequest.UserId);

            return result.FirstOrDefault();
        }
    }
}
