using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Peek.Framework.PeekServices.Documents;
using Peek.Framework.PeekServices.PeekReader.Consults;
using PeekReaderService.Models;
using PeekReaderService.Repository.Contexts;
using PeekReaderService.Service.Interfaces;
using Domain = Peek.Framework.PeekServices.Domain;


namespace PeekReaderService.Repository.Repositories
{
    public class LikesRepository : ILikesRepository
    {
        public readonly LikeContext _likesContext;
        public LikesRepository(IOptions<ConfigDb> options)
        {
            _likesContext = new LikeContext(options);
        }

        public async Task<List<Domain.Like>> Get(GetLikesRequest getLikesRequest)
        {
            var result = await _likesContext.Likes.Find(x => getLikesRequest.PeeksIds.Contains((Guid)x.PeekId))
                .Skip(getLikesRequest.PageInformation.Offset)
                .Limit(getLikesRequest.PageInformation.PageSize)
                .ToListAsync();

            if (result.Any())
            {
                return result.FirstOrDefault().Likes;

            }

            return null;
        }

        public async Task<int> Get(GetLikesCountRequest getLikesCountRequest)
        {
            var result = await _likesContext.Likes.Find(x => getLikesCountRequest.PeeksIds.Contains((Guid)x.PeekId))
                .ToListAsync();

            if (result.Any())
            {
                return result.FirstOrDefault().Likes.ToList().Count();

            }

            return 0;
        }


    }
}
