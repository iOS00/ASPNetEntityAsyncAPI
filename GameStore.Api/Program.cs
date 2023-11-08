using GameStore.Api.Data;
using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

await app.Services.InitializeDbAsync(); //extension defined to migrate on each app run

app.MapGamesEndpoints();

app.Run();
