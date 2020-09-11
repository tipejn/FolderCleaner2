using FolderCleaner2.Console.BL;
using FolderCleaner2.Console.Configurations;
using FolderCleaner2.Console.Interfaces;
using FolderCleaner2.Console.Repositories;
using FolderCleaner2.Console.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FolderCleaner2.Console
{
    class Program
    {
        private static ServiceProvider _serviceProvider;
        static void Main(string[] args)
        {
            RegisterServices();
            var scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<FolderCleanerApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();
            services.Configure<FolderCleanerSettings>(configuration.GetSection("FolderCleanerSettings"));
            services.AddSingleton<IRepository, SettingsRepository>();
            services.AddSingleton<IFileValidator, ExtensionValidator>();
            services.AddSingleton<IFileValidator, LastAccessTimeValidator>();
            services.AddSingleton<IItemsGetter, ItemsGetter>();
            services.AddSingleton<IItemsProcessor, ItemsProcessor>();
            services.AddSingleton<ICleanManager, CleanManager>();
            services.AddSingleton<FolderCleanerApplication>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
