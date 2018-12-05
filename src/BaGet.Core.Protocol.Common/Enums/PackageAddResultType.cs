namespace BaGet.Core.Protocol.Common.Enums
{
    /// <summary>
    /// The result of attempting to add the package to the database.
    /// See <see cref="IPackageService.AddAsync(Package)"/>
    /// </summary>
    public enum PackageAddResultType
    {
        /// <summary>
        /// Failed to add the package as it already exists.
        /// </summary>
        PackageAlreadyExists,

        /// <summary>
        /// The package was added successfully.
        /// </summary>
        Success
    }
}
