using Microsoft.Extensions.DependencyInjection;
using OninoCamp.Infrastructure.Enums;
using OninoCamp.Infrastructure.Services.Storage;
using OninoCamp.Infrastructure.Services.Storage.Azure;
using OninoCamp.Infrastructure.Services.Storage.Local;
using OninoCamp.Infrastructure.Services.Token;
using OnionCamp.Application.Abstractions.Storage;
using OnionCamp.Application.Abstractions.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OninoCamp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStorageService, StorageService>();
            serviceCollection.AddScoped<ITokenHandler, TokenHandler>();
        }

        public static void AddStorage<T>(this IServiceCollection serviceCollection)  where T : Storage, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection serviceCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    serviceCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:
                    serviceCollection.AddScoped<IStorage, AzureStorage>();
                    break;
                case StorageType.AWS:
                    break;
                default:
                    break;
            }
        }
    }
}
