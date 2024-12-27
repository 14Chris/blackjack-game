using BlackjackGame;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => { services.AddSingleton<Game>(); });
var app = builder.Build();
app.Services.GetRequiredService<Game>().PlayGame();
Console.WriteLine("Done!");