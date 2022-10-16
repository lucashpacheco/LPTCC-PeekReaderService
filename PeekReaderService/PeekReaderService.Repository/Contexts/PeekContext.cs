using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeekReaderService.Models;
using Domain = Peek.Framework.PeekServices.Domain;

namespace PeekReaderService.Repository.Contexts
{
    public class PeekContext
    {
        public readonly IMongoDatabase _mongoDatabase;
        public PeekContext(IOptions<ConfigDb> opcoes)
        {
            MongoClient mongoClient = new MongoClient(opcoes.Value.ConnectionString);

            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(opcoes.Value.Database);
            }
        }

        public IMongoCollection<Domain.Peek> Peek
        {
            get
            {
                return _mongoDatabase.GetCollection<Domain.Peek>("PeekDocument");
            }
        }
    }
}
