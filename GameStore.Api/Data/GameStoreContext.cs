using System.Reflection;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public class GameStoreContext: DbContext
{
    public GameStoreContext(DbContextOptions<GameStoreContext> options) 
        : base(options) //send options to base class
    {
    }

    public DbSet<Game> Games => Set<Game>();  //define default empty set

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
