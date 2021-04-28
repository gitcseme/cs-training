using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieData.Contexts;
using MovieData.Entities;

namespace MovieChecker
{

    /**
        A background service
        Adds a new movie every 10 seconds interval
    */

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MovieContext dbContext;
        int i = 0;

        public Worker(ILogger<Worker> logger, MovieContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                
                var newMovie = new Movie { Name = $"Movie {++i}", Image = "https://images.indianexpress.com/2018/04/avengers-iron-man.jpg?w=350" };
                await dbContext.Movies.AddAsync(newMovie);
                await dbContext.SaveChangesAsync();

                Console.WriteLine($"Create new movie name {newMovie.Name}\n");
                
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
