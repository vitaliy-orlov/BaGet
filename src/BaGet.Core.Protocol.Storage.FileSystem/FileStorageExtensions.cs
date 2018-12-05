using BaGet.Core.Protocol.Abstractions;
using BaGet.Core.Protocol.Storage.FileSystem.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaGet.Core.Protocol
{
    public static class FileStorageExtensions
    {
        public static IServiceCollection AddFileSystemStorage(this IServiceCollection services, string path)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddScoped<IStorageService>(s => new FileStorageService(path));
        }
    }
}
