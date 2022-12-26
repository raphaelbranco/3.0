namespace Base30.SysAdmin.Application.Queries.Search
{
    public interface ISearchQueries : IDisposable
    {
        Task<IEnumerable<SearchDto>> GetAllNoSql();
        SearchDto? LoadByIdNoSql(Guid id);
    }
}

