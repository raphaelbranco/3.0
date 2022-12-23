using Base30.Core.Data;

namespace Base30.SysAdmin.Domain
{
    public interface ISearchRepository : IRepository<Search>
    {
        Task<IEnumerable<SearchNoSql>?> GetAll();
        Search LoadById(Guid id);
        void Create(Search search);
        void SyncCreate(SearchNoSql searchNoSql);
        void Update(Search search);
        void SyncUpdate(SearchNoSql searchNoSql);
    }
}

