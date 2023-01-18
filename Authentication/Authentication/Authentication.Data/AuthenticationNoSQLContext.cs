using Base30.Authentication.Domain;
using Base30.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Authentication.Data
{
    public class AuthenticationNoSQLContext : IDisposable, IUnitOfWorkNoSql
    {
        private IMongoDatabase? _database;
        private IMongoClient? _clientNoSql;

        public AuthenticationNoSQLContext(IOptions<NoSqlSettings> settings)
        {
            _clientNoSql = new MongoClient(settings.Value.ConnectionString);
            if (_clientNoSql != null)
                _database = _clientNoSql.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<AspNetUsersNoSql> AspNetUsersNoSql
        {
            get
            {
                return _database!.GetCollection<AspNetUsersNoSql>("AspNetUsers");
            }
        }
        public bool Commit(ReplaceOneResult result)
        {
            bool sucess = result.IsAcknowledged && result.ModifiedCount > 0;
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
