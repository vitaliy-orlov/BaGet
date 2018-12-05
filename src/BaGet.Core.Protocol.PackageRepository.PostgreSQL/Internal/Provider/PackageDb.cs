using BaGet.Core.Protocol.Repository.PostgreSQL.Internal.DAL;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.PostgreSQL;

namespace BaGet.Core.Protocol.Repository.PostgreSQL.Internal.Provider
{
    internal class PackageDb : DataConnection
    {
        public PackageDb(string connectionString) : base(new PostgreSQLDataProvider(PostgreSQLVersion.v95), connectionString)
        {

        }

        public ITable<Package> Packages { get { return this.GetTable<Package>(); } }
    }
}
