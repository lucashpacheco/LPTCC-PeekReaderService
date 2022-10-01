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
    public class LikesRepository : ILikesRepository
    {
        public readonly LikeContext _likesContext;
        public LikesRepository(IOptions<ConfigDb> options)
        {
            _likesContext = new LikeContext(options);
        }

        public async Task<LikesDocument> Get(GetLikesRequest getLikesRequest)
        {
            var result = await _likesContext.Likes.FindAsync(x => x.PeekId == getLikesRequest.PeekId);

            return result.FirstOrDefault();
        }


    }
}
