using BaGet.Core.Protocol.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Abstractions.Repositories
{
    public interface ISearchRepository
    {
        Task IndexAsync(Package package);

        Task<IReadOnlyList<SearchResult>> SearchAsync(string query, int skip = 0, int take = 20);

        Task<IReadOnlyList<string>> AutocompleteAsync(string query, int skip = 0, int take = 20);
    }
}
