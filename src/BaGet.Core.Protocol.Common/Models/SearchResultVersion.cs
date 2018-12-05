using NuGet.Versioning;
using System;

namespace BaGet.Core.Protocol.Common.Models
{
    public class SearchResultVersion
    {
        public SearchResultVersion(NuGetVersion version, long downloads)
        {
            Version = version ?? throw new ArgumentNullException(nameof(version));
            Downloads = downloads;
        }

        public NuGetVersion Version { get; }

        public long Downloads { get; }
    }
}
