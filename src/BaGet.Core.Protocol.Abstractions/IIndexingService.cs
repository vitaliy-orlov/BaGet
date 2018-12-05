using BaGet.Core.Protocol.Common.Enums;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Abstractions
{
    /// <summary>
    /// The service used to accept new packages.
    /// </summary>
    public interface IIndexingService
    {
        /// <summary>
        /// Attempt to index a new package.
        /// </summary>
        /// <param name="stream">The stream containing the package's content.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The result of the attempted indexing operation.</returns>
        Task<IndexingResultType> IndexAsync(Stream stream, CancellationToken cancellationToken);
    }
}