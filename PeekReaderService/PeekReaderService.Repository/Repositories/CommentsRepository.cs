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
    public class CommentsRepository : ICommentsRepository
    {
        public readonly CommentContext _commentsContext;
        public CommentsRepository(IOptions<ConfigDb> options)
        {
            _commentsContext = new CommentContext(options);
        }

        public async Task<CommentsDocument> Get(GetCommentsRequest getCommentsRequest)
        {
            var result = await _commentsContext.Comments.FindAsync(x => x.PeekId == getCommentsRequest.PeekId);

            return result.FirstOrDefault();
        }

        public async Task<int> Get(GetCommentsCountRequest getCommentsCountRequest)
        {
            var result = await _commentsContext.Comments.FindAsync(x => x.PeekId == getCommentsCountRequest.PeekId);

            return result.FirstOrDefault().Comments.ToList().Count();
        }
    }
}
