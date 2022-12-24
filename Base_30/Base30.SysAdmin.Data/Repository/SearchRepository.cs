using Base30.SysAdmin.Domain;
using Base30.Core.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Base30.SysAdmin.Data.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly SysAdminDBContext _context;
        private readonly SysAdminNoSQLContext _contextNoSql;

        public SearchRepository(SysAdminDBContext context, SysAdminNoSQLContext contextNoSql)
        {
            _context = context;
            _contextNoSql = contextNoSql;
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

        public ReplaceOneResult? SyncUpdate(Guid id, Search item)
        {
            IMongoCollection<SearchNoSql> search = _contextNoSql.SearchNoSql;

            Expression<Func<SearchNoSql, bool>> filter = x => x.Id.Equals(id);

            SearchNoSql searchItem = search.Find(filter).FirstOrDefault();

            if (searchItem == null) return null;
            searchItem.UpdateNoSql(item.UserUpd, item.Active, item.Name, item.Description);
            return search.ReplaceOne(filter, searchItem);
        }
        public Search? LoadById(Guid id)
        {
            Search? search = _context.Search?.AsNoTracking().Where(m => m.Id == id).SingleOrDefault();
            return search;
        }

        public async Task<IEnumerable<SearchNoSql>?> GetAll()
        {
            IEnumerable<SearchNoSql> searchNoSql = await _contextNoSql.SearchNoSql.Find(x => true).ToListAsync();

            return searchNoSql;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}

