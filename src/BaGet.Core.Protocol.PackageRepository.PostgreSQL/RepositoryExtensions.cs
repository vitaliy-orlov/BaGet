using BaGet.Core.Protocol.Abstractions;
using BaGet.Core.Protocol.Abstractions.Repositories;
using BaGet.Core.Protocol.Repository.PostgreSQL.Internal;
using BaGet.Core.Protocol.Repository.PostgreSQL.Internal.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BaGet.Core.Protocol.Repository.PostgreSQL
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddBaGetRepositories(this IServiceCollection services, string connectionString)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<PackageDb>(s => new PackageDb(connectionString));
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ISearchRepository, SearchRepository>();

            return services;
        }
    }
}
