using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using branef.Domain.Interfaces.Repositories;
using branef.Domain.Models;
using branef.Infrastructure.Data;
using branef.Infrastructure.Repositories;
using MongoDB.Driver;
using branef.Infrastructure.Repositories.Query;

namespace branef.CrossCutting.IoC;

public static class DependencyInjection
{

    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("sqlserver");
        services.AddDbContext<BranefContext>(options => options.UseSqlServer(connectionString));

        services.AddSingleton(sp =>
        {
            var config = sp.GetRequiredService<IConfiguration>();
            var connectionString = config.GetConnectionString("mongo");
            return new MongoClient(connectionString);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepository<Empresa>, Repository<Empresa>>();
        services.AddScoped<IQueryRepository<Empresa>, EmpresaQueryRepository>();
        // services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));



        var handlers = AppDomain.CurrentDomain.Load("branef.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

        return services;
    }
}