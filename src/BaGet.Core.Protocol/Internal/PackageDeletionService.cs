using BaGet.Core.Protocol.Abstractions;
using BaGet.Core.Protocol.Common.Enums;
using BaGet.Core.Protocol.Common.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NuGet.Versioning;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Internal
{
    internal class PackageDeletionService : IPackageDeletionService
    {
        private readonly IPackageRepository _packages;
        private readonly IPackageStorageService _storage;
        private readonly PackageDeleteOption _options;
        private readonly ILogger<PackageDeletionService> _logger;

        public PackageDeletionService(
            IPackageRepository packages,
            IPackageStorageService storage,
            IOptionsSnapshot<PackageDeleteOption> options,
            ILogger<PackageDeletionService> logger)
        {
            _packages = packages ?? throw new ArgumentNullException(nameof(packages));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> TryDeletePackageAsync(string id, NuGetVersion version, CancellationToken cancellationToken)
        {
            switch (_options.PackageDeletionBehavior)
            {
                case PackageDeletionBehaviorType.Unlist:
                    return await TryUnlistPackageAsync(id, version);

                case PackageDeletionBehaviorType.HardDelete:
                    return await TryHardDeletePackageAsync(id, version, cancellationToken);
                default:
                    throw new InvalidOperationException($"Unknown deletion behavior '{_options.PackageDeletionBehavior}'");
            }
        }

        private async Task<bool> TryUnlistPackageAsync(string id, NuGetVersion version)
        {
            _logger.LogInformation("Unlisting package {PackageId} {PackageVersion}...", id, version);

            if (!await _packages.UnlistPackageAsync(id, version))
            {
                _logger.LogWarning("Could not find package {PackageId} {PackageVersion}", id, version);

                return false;
            }

            _logger.LogInformation("Unlisted package {PackageId} {PackageVersion}", id, version);

            return true;
        }

        private async Task<bool> TryHardDeletePackageAsync(string id, NuGetVersion version, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Hard deleting package {PackageId} {PackageVersion} from the database...",
                id,
                version);

            var found = await _packages.HardDeletePackageAsync(id, version);
            if (!found)
            {
                _logger.LogWarning(
                    "Could not find package {PackageId} {PackageVersion} in the database",
                    id,
                    version);
            }

            // Delete the package from storage. This is necessary even if the package isn't
            // in the database to ensure that the storage is consistent with the database.
            _logger.LogInformation("Hard deleting package {PackageId} {PackageVersion} from storage...",
                id,
                version);

            await _storage.DeleteAsync(id, version, cancellationToken);

            _logger.LogInformation(
                "Hard deleted package {PackageId} {PackageVersion} from storage",
                id,
                version);

            return found;
        }
    }
}
