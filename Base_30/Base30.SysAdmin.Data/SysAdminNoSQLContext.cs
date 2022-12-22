using Base30.SysAdmin.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Base30.SysAdmin.Data
{
    public class SysAdminNoSQLContext : IDisposable
    {
        private IMongoDatabase? _database;
        private IMongoClient? _menuNoSql;

        public SysAdminNoSQLContext(IOptions<NoSqlSettings> settings)
        {
            _menuNoSql = new MongoClient(settings.Value.ConnectionString);
            if (_menuNoSql != null)
                _database = _menuNoSql.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<MenuNoSql> MenuNoSql
        {
            get
            {
                return _database!.GetCollection<MenuNoSql>("Menu");
            }
        }

        public void Dispose()
        {
            _menuNoSql = null;
            _database = null;
        }
    }

    public class NoSqlSettings
    {
        public string? ConnectionString;
        public string? Database;
    }

}
