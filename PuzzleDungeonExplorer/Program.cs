using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PuzzleDungeonExplorer.Data;
using PuzzleDungeonExplorer.Repositories;
using PuzzleDungeonExplorer.Services;
using System.IO;

namespace PuzzleDungeonExplorer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var gameService = host.Services.GetRequiredService<GameService>();
            gameService.StartGame();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<PuzzleDungeonContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));

                    services.AddScoped<IDungeonRepository, DungeonRepository>();
                    services.AddScoped<IRoomRepository, RoomRepository>();
                    services.AddScoped<IPuzzleRepository, PuzzleRepository>();
                    services.AddScoped<ITrapRepository, TrapRepository>();
                    services.AddScoped<IPlayerRepository, PlayerRepository>();

                    services.AddScoped<GameService>();
                });
    }
}