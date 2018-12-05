using NuGet.Versioning;
using System.Collections.Generic;

namespace BaGet.Core.Protocol.Common.Models
{
    public class SearchResult
    {
        public string Id { get; set; }

        public NuGetVersion Version { get; set; }

        public string Description { get; set; }
        public IReadOnlyList<string> Authors { get; set; }
        public string IconUrl { get; set; }
        public string LicenseUrl { get; set; }
        public string ProjectUrl { get; set; }
        public string Summary { get; set; }
        public string[] Tags { get; set; }
        public string Title { get; set; }
        public long TotalDownloads { get; set; }

        public IReadOnlyList<SearchResultVersion> Versions { get; set; }
    }
}
