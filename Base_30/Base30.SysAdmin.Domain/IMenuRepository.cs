using Base30.Core.Data;

namespace Base30.SysAdmin.Domain
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<IEnumerable<MenuNoSql>?> GetAll();
        Menu? LoadById(Guid id);
        void Create(Menu menu);
        void SyncCreate(MenuNoSql menuNoSql);
        void Update(Menu menu);
    }
}