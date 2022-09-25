using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeekWriterService.API.Config;
using PeekWriterService.Models.Domain;

namespace PeekReaderService.Repository.Contexts
{
    public class LikeContext
    {
        public readonly IMongoDatabase _mongoDatabase;
        public LikeContext(IOptions<ConfigDb> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<LikesDocument> Likes
        {
            get
            {
                return _mongoDatabase.GetCollection<LikesDocument>("PeekDocument");
            }
        }
    }
}
