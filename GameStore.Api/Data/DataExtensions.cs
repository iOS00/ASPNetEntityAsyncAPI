using GameStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static async Task InitializeDbAsync(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();  //apply any missing migrations on DB (incl.Initial)
    }

    public static IServiceCollection AddRepositories(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        var connString = configuration.GetConnectionString("GameStoreContext");

        //AddSqlServer is extension from Entity for .AddScoped, just for DB
        services.AddSqlServer<GameStoreContext>(connString)
                .AddScoped<IGamesRepository, EntityFrameworkGamesRepository>(); //use Scoded lifetime
        return services;
    }
}
