using BaGet.Core.Protocol.Abstractions;
using BaGet.Core.Protocol.Common.Enums;
using BaGet.Core.Protocol.Common.Models;
using BaGet.Core.Protocol.Repository.PostgreSQL.Internal.Provider;
using LinqToDB;
using NuGet.Versioning;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Repository.PostgreSQL.Internal
{
    internal class PackageRepository : IPackageRepository
    {
        private readonly PackageDb _db;

        public PackageRepository(PackageDb db)
        {
            _db = db;
        }

        public Task<PackageAddResultType> AddAsync(Package package)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddDownloadAsync(string id, NuGetVersion version)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> ExistsAsync(string id, NuGetVersion version = null)
        {
            var query = _db.Packages.Where(x => x.Id == id);

            if (version != null)
            {
                query = query.Where(x => x.VersionString == version.ToNormalizedString());
            }

            return query.AnyAsync();
        }

        public Task<IReadOnlyList<Package>> FindAsync(string id, bool includeUnlisted = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<Package> FindOrNullAsync(string id, NuGetVersion version, bool includeUnlisted = false)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> HardDeletePackageAsync(string id, NuGetVersion version)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RelistPackageAsync(string id, NuGetVersion version)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UnlistPackageAsync(string id, NuGetVersion version)
        {
            throw new System.NotImplementedException();
        }
    }
}
