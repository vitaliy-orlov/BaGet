using BaGet.Core.Protocol.Abstractions;
using BaGet.Core.Protocol.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaGet.Core.Protocol
{
    public static class ProtocolExtensions
    {
        public static IServiceCollection AddBaGetServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IIndexingService, IndexingService>();
            services.AddScoped<IPackageDeletionService, PackageDeletionService>();
            services.AddScoped<IPackageStorageService, PackageStorageService>();

            return services;
        }
    }
}
