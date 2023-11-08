using System.Diagnostics;
using GameStore.Api.Endpoints;
using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository: IGamesRepository
{
     // demo list of games for in-memory testing (before DB is available)
    private readonly List <Game> games = new()
    {
        new Game()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 19.99M, // to make it explicitly decimal type
            ReleaseDate = new DateTime(1991, 2, 1),
            ImageUri = "https://placehold.co/100"  // to place an image 100x100
        },
        new Game()
        {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 59.99M, // to make it explicitly decimal type
            ReleaseDate = new DateTime(2010, 9, 30),
            ImageUri = "https://placehold.co/100"  // to place an image 100x100
        },
        new Game()
        {
            Id = 3,
            Name = "FIFA 23",
            Genre = "Sports",
            Price = 69.99M, // to make it explicitly decimal type
            ReleaseDate = new DateTime(2022, 9, 27),
            ImageUri = "https://placehold.co/100"  // to place an image 100x100
        }
    };

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);  //when no DB or HTTP requests (is faster)
    }

    public async Task<Game?> GetAsync(int id)
    {
        return await Task.FromResult(games.Find(game => game.Id == id));
    }

    public async Task CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
        await Task.CompletedTask;  //use when no return is needed
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
        await Task.CompletedTask;  //use when no return is needed
    }

    public async Task DeleteAsync(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
        await Task.CompletedTask;  //use when no return is needed
    }
}
