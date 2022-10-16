using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Peek.Framework.PeekServices.PeekReader.Consults;
using PeekReaderService.Models;
using PeekReaderService.Repository.Contexts;
using PeekReaderService.Service.Interfaces;
using Domain = Peek.Framework.PeekServices.Domain;


namespace PeekReaderService.Repository.Repositories
{
    public class PeekRepository : IPeekRepository
    {
        public readonly PeekContext _peekContext;
        public PeekRepository(IOptions<ConfigDb> options)
        {
            _peekContext = new PeekContext(options);
        }

        public async Task<List<Domain.Peek>> Get(GetPeeksRequest getPeeksRequest)
        {
            List<Domain.Peek> result;
            if (getPeeksRequest.UserId.Count > 1)
                result = await _peekContext.Peek.Find(x => getPeeksRequest.UserId.Contains(x.AuthorId))
                    .Limit(getPeeksRequest.PageInformation.PageSize)
                    .SortByDescending(c => c.CreatedDate)
                    .ToListAsync();
            else if (getPeeksRequest.UserId.Count == 1)
                result = await _peekContext.Peek.Find(x => x.Id == getPeeksRequest.UserId[0])
                    .Limit(getPeeksRequest.PageInformation.PageSize)
                    .SortByDescending(c => c.CreatedDate)
                    .ToListAsync();
            else
                result = await _peekContext.Peek.Find(new BsonDocument())
                    .Limit(getPeeksRequest.PageInformation.PageSize)
                    .SortByDescending(c => c.CreatedDate)
                    .ToListAsync();

            return result;
        }
    }
}
