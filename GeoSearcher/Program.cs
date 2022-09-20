using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace GeoSearcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
               .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .ConfigureServices(s => s.AddAutofac())
                   .UseStartup<Startup>()
                   .Build();
    }
}