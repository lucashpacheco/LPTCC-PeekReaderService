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
    }
}
