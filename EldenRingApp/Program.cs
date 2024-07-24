using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EldenRingApp.Data;
using EldenRingApp.Repositories.Interfaces;
using EldenRingApp.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

namespace EldenRingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<EldenRingContext>();
                context.Database.Migrate();
            }

            var app = host.Services.GetRequiredService<App>();
            app.Run();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<EldenRingContext>();
                    services.AddScoped<ICharacterRepository, CharacterRepository>();
                    services.AddTransient<App>();
                });
    }

    public class App
    {
        private readonly ICharacterRepository _characterRepository;

        public App(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public void Run()
        {
            // Implement interaction logic here (add, retrieve, update, delete characters)
        }
    }
}