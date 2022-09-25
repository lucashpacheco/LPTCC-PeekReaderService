using System;
using System.Threading.Tasks;
using PeekReaderService.Models.Consults;
using PeekWriterService.Models.Domain;

namespace PeekReaderService.Service.Interfaces
{
    public interface ICommentsRepository
    {
        Task<CommentsDocument> Get(GetCommentsRequest commentsDocument);
    }
}
