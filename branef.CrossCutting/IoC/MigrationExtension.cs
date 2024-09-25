using branef.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace branef.CrossCutting.IoC;

public static class MigrationExtension
{
    /// <summary>
    /// Aplica os migrations de forma automática
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static async Task ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using BranefContext dbContext = scope.ServiceProvider.GetRequiredService<BranefContext>();

        if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
            await dbContext.Database.MigrateAsync();
    }
}