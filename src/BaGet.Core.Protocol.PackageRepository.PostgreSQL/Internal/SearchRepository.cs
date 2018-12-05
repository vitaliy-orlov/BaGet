using BaGet.Core.Protocol.Abstractions.Repositories;
using BaGet.Core.Protocol.Common.Models;
using BaGet.Core.Protocol.Repository.PostgreSQL.Internal.Provider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaGet.Core.Protocol.Repository.PostgreSQL.Internal
{
    internal class SearchRepository : ISearchRepository
    {
        private readonly PackageDb _db;

        public SearchRepository(PackageDb db)
        {
            _db = db;
        }

        public Task<IReadOnlyList<string>> AutocompleteAsync(string query, int skip = 0, int take = 20)
        {
            throw new System.NotImplementedException();
        }

        public Task IndexAsync(Package package)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<SearchResult>> SearchAsync(string query, int skip = 0, int take = 20)
        {
            throw new System.NotImplementedException();
        }
    }
}
