using System;
using System.Linq;
using System.IO;
using CommandLine;
using FunApp.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{typeof(Program).Namespace} ({string.Join(" ", args)}) starts working...");
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider(true);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                serviceProvider = serviceScope.ServiceProvider;
                SandboxCode(serviceProvider);
            }
        }

        private static void SandboxCode(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<FunAppContext>();
            Console.WriteLine(db.Users.Count());
            // TODO: Code here
        }

        private static void ConfigureServices(ServiceCollection serviceCollection)
        {

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            serviceCollection.AddDbContext<FunAppContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
