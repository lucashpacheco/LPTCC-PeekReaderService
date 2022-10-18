using System.Linq;
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
            var result = await _likesContext.Likes.Find(x => x.PeekId == getLikesRequest.PeekId)
                .Limit(getLikesRequest.PageInformation.PageSize)
                .ToListAsync();

            return result.FirstOrDefault();
        }

        public async Task<int> Get(GetLikesCountRequest getLikesCountRequest)
        {
            var result = await _likesContext.Likes.FindAsync(x => x.PeekId == getLikesCountRequest.PeekId);

            return result.FirstOrDefault().Likes.ToList().Count();
        }


    }
}
