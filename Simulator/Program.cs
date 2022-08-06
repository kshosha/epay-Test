using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Simulator
{
    class Program
    {
        private static IHostBuilder CreateHostBuilder()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IMainService, MainService>();
                });
            return hostBuilder;
        }
        static void Main(string[] args)
        {

            var host = CreateHostBuilder().Build();
            host.Services.GetService<IMainService>().ApplicationStart(args);
            
        }
    }
    public interface IMainService
    {
        void ApplicationStart(string[] args);
    }
    public class MainService : IMainService
    {
        
        public MainService()
        {
        }
        public void ApplicationStart(string[] args)
        {
            createCustomers obj = new createCustomers();
            obj.createcustomers();

        }
    }
}
