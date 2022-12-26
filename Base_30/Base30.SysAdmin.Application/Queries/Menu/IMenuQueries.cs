using Base30.SysAdmin.Application.Queries.Search;

namespace Base30.SysAdmin.Application.Queries.Menu
{
    public interface IMenuQueries : IDisposable
    {
        Task<IEnumerable<MenuDto>> GetAll();        
    }
}
