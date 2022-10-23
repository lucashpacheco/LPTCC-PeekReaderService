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
    public class CommentsRepository : ICommentsRepository
    {
        public readonly CommentContext _commentsContext;
        public CommentsRepository(IOptions<ConfigDb> options)
        {
            _commentsContext = new CommentContext(options);
        }

        public async Task<List<Domain.Comment>> Get(GetCommentsRequest getCommentsRequest)
        {
            var result = await _commentsContext.Comments.Find(x => x.PeekId == getCommentsRequest.PeekId)
                .Limit(getCommentsRequest.PageInformation.PageSize)
                .ToListAsync();
            
            if (result.Any())
            {
                return result.FirstOrDefault().Comments.ToList();
            }
            return null;
        }

        public async Task<int> Get(GetCommentsCountRequest getCommentsCountRequest)
        {
            var result = await _commentsContext.Comments.Find(x => x.PeekId == getCommentsCountRequest.PeekId).ToListAsync();

            if (result.Any())
            {
                return result.FirstOrDefault().Comments.ToList().Count();
            }
            return 0;
        }
    }
}
