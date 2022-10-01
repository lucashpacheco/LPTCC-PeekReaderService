using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Peek.Framework.PeekServices.Documents;
using PeekReaderService.Models;

namespace PeekReaderService.Repository.Contexts
{
    public class CommentContext
    {
        public readonly IMongoDatabase _mongoDatabase;
        public CommentContext(IOptions<ConfigDb> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<CommentsDocument> Comments
        {
            get
            {
                return _mongoDatabase.GetCollection<CommentsDocument>("CommentsDocument");
            }
        }
    }
}
