using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SampleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = new HostBuilder();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Log.Logger =  new LoggerConfiguration()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.AddSerilog();
                })
                .UseWindowsService();
        }
    }
}
