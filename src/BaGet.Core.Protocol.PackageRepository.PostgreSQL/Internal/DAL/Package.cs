using LinqToDB.Mapping;

namespace BaGet.Core.Protocol.Repository.PostgreSQL.Internal.DAL
{
    internal class Package
    {
        [Column("id"), PrimaryKey   ] public string Id            { get; set; } // varchar(128)
        [Column("version"), NotNull ] public string VersionString { get; set; } // varchar(64)
    }
}
