using branef.Domain.Models;
using MongoDB.Driver;

namespace branef.Infrastructure.Repositories.Query;

public class EmpresaQueryRepository(MongoClient _mongoClient) : QueryRepository<Empresa>(_mongoClient, "Empresas")
{
}