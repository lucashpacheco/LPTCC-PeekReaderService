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
