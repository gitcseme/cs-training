using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieData.Contexts;

namespace MovieChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    string connectionString = "Server=DESKTOP-M8Q0094;Database=WorkerMovieDB;Trusted_Connection=True;MultipleActiveResultSets=true";

                    builder.RegisterType<MovieContext>()
                        .WithParameter("connectionString", connectionString)
                        .InstancePerLifetimeScope();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
