using Base30.Core.Data;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Base30.SysAdmin.Domain
{
    public interface ISearchRepository : IRepository<Search>
    {
        Task<IEnumerable<SearchNoSql>?> GetAll();
        Search LoadById(Guid id);
        void Create(Search search);
        void SyncCreate(SearchNoSql searchNoSql);
        void Update(Search search);
        ReplaceOneResult? SyncUpdate(SearchNoSql searchNoSql, Expression<Func<SearchNoSql, bool>> filter);
        (SearchNoSql?, Expression<Func<SearchNoSql, bool>>) LoadByIdNoSqlToSyncUpdate(Guid searchId);
        SearchNoSql? LoadByIdNoSql(Guid id);
    }
}

