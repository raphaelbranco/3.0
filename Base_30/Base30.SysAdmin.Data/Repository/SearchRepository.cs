using Base30.SysAdmin.Domain;
using Base30.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace Base30.SysAdmin.Data.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly SysAdminDBContext _context;
        private readonly SysAdminNoSQLContext _contextNoSql;

        public SearchRepository(SysAdminDBContext context, IOptions<NoSqlSettings> settingsNoSql)
        {
            _context = context;
            _contextNoSql = new SysAdminNoSQLContext(settingsNoSql);
        }

        public IUnitOfWork UnitOfWork => _context;
        
        public IUnitOfWorkNoSql UnitOfWorkNoSql => _contextNoSql;

        public void Create(Search search)
        {
            _context.Search.Add(search);
        }

        public async void SyncCreate(SearchNoSql searchNoSql)
        {
            await _contextNoSql.SearchNoSql.InsertOneAsync(searchNoSql);
        }

        public void Update(Search search)
        {
            _context.Search.Update(search);
        }

        public ReplaceOneResult? SyncUpdate(SearchNoSql searchNoSql, Expression<Func<SearchNoSql, bool>> filter)
        {
            IMongoCollection<SearchNoSql> searchC = _contextNoSql.SearchNoSql;
            return searchC.ReplaceOne(filter, searchNoSql);
        }
        public async Task<IEnumerable<SearchNoSql>?> GetAll()
        {
            IEnumerable<SearchNoSql> searchNoSql = await _contextNoSql.SearchNoSql.Find(x => true).ToListAsync();

            return searchNoSql;
        }

        public Search? LoadById(Guid id)
        {
            Search? search = _context.Search?.AsNoTracking().Where(m => m.Id == id).SingleOrDefault();
            return search;
        }

        public (SearchNoSql?, Expression<Func<SearchNoSql, bool>>) LoadByIdNoSqlToSyncUpdate(Guid searchId)
        {
            IMongoCollection<SearchNoSql> search = _contextNoSql.SearchNoSql;
            Expression<Func<SearchNoSql, bool>> filter = x => x.SearchId.Equals(searchId);
            SearchNoSql? searchItem = search.Find(filter).FirstOrDefault();

            return (searchItem, filter);
        }

        public SearchNoSql? LoadByIdNoSql(Guid id)
        {
            Task<SearchNoSql>? searchNosqlTask = _contextNoSql.SearchNoSql?.Find(item => item.SearchId == id).FirstOrDefaultAsync();
            SearchNoSql? searchNosql = searchNosqlTask?.Result;

            return searchNosql;
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}

