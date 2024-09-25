using branef.Domain.Interfaces.Repositories;
using branef.Domain.Models;
using MongoDB.Driver;

namespace branef.Infrastructure.Repositories.Query;

public class QueryRepository<T> : IQueryRepository<T> where T : Entity
{
    protected readonly IMongoDatabase _db;
    protected readonly IMongoCollection<T> _collection;

    public QueryRepository(MongoClient _mongoClient, string collectionName)
    {
        _db = _mongoClient.GetDatabase("branef");
        _collection = _db.GetCollection<T>(collectionName);
    }

    public async Task Create(T Entity, CancellationToken cancellationToken) => await _collection.InsertOneAsync(Entity, cancellationToken: cancellationToken);

    public async Task Update(T Entity, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", Entity.Id);
        await _collection.ReplaceOneAsync(filter, Entity, cancellationToken: cancellationToken);
    }

    public async Task Delete(T Entity, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", Entity.Id);
        await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<T?> FindAsync(Guid Id, CancellationToken cancellationToken)
    {
        var filter = Builders<T>.Filter.Eq("Id", Id);
        var model = await _collection.FindAsync(filter, cancellationToken: cancellationToken);
        return await model.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<T>?> GetAll(CancellationToken cancellationToken)
    {
        var models = await _collection.FindAsync(entity => true, cancellationToken: cancellationToken);
        return await models.ToListAsync(cancellationToken);
    }
}