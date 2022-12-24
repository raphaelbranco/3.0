using Base30.Core.Data;
using MongoDB.Driver;

namespace Base30.SysAdmin.Domain
{
    public interface ISearchRepository : IRepository<Search>
    {
        Task<IEnumerable<SearchNoSql>?> GetAll();
        Search LoadById(Guid id);
        void Create(Search search);
        void SyncCreate(SearchNoSql searchNoSql);
        void Update(Search search);
        ReplaceOneResult? SyncUpdate(Guid id, Search item);
    }
}

