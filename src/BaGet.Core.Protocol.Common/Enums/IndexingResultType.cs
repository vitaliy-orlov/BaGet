namespace BaGet.Core.Protocol.Common.Enums
{
    /// <summary>
    /// The result of attempting to index a package.
    /// See <see cref="IIndexingService.IndexAsync(Stream, CancellationToken)"/>.
    /// </summary>
    public enum IndexingResultType
    {
        /// <summary>
        /// The package is malformed. This may also happen if BaGet is in a corrupted state.
        /// </summary>
        InvalidPackage,

        /// <summary>
        /// The package has already been indexed.
        /// </summary>
        PackageAlreadyExists,

        /// <summary>
        /// The package has been indexed successfully.
        /// </summary>
        Success,
    }
}
