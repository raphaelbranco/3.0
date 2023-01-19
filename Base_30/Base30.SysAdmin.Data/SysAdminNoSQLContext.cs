using Base30.SysAdmin.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Base30.Core.Data;

namespace Base30.SysAdmin.Data
{
    public class SysAdminNoSQLContext : IDisposable, IUnitOfWorkNoSql
    {
        private IMongoDatabase? _database;
        private IMongoClient? _clientNoSql;

        public SysAdminNoSQLContext(IOptions<NoSqlSettings> settings)
        {
            _clientNoSql = new MongoClient(settings.Value.ConnectionString);
            if (_clientNoSql != null)
                _database = _clientNoSql.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<MenuNoSql> MenuNoSql
        {
            get
            {
                return _database!.GetCollection<MenuNoSql>("Menu");
            }
        }


        public bool Commit(ReplaceOneResult result)
        {
            bool sucess = result.IsAcknowledged && result.ModifiedCount > 0;
            //if (sucess) await _mediatoRHandler.PublishEvents(this);

            return sucess;
        }

        public void Dispose()
        {
            _clientNoSql = null;
            _database = null;
        }
    }

    public class NoSqlSettings
    {
        public string? ConnectionString;
        public string? Database;
    }

}
