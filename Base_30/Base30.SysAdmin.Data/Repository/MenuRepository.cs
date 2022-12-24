using Base30.SysAdmin.Domain;
using Base30.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Base30.SysAdmin.Data.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly SysAdminDBContext _context;
        private readonly SysAdminNoSQLContext _contextNoSql;

        public MenuRepository(SysAdminDBContext context, SysAdminNoSQLContext contextNoSql)
        {
            _context = context;
            _contextNoSql = contextNoSql;
        }

        public IUnitOfWork UnitOfWork => _context;
        public IUnitOfWorkNoSql UnitOfWorkNoSql => _contextNoSql;

        public void Create(Menu menu)
        {
            _context.Menu.Add(menu);
        }
        public async void SyncCreate(MenuNoSql menuNoSql)
        {
            await _contextNoSql.MenuNoSql.InsertOneAsync(menuNoSql);
        }

        public void Update(Menu menu)
        {
            _context.Menu.Update(menu);
        }

        public Menu? LoadById(Guid id)
        {
            Menu? menu = _context.Menu?.AsNoTracking().Where(m => m.Id == id).SingleOrDefault();
            return menu;
        }

        public async Task<IEnumerable<MenuNoSql>?> GetAll()
        {
            IEnumerable<MenuNoSql> menuNoSql = await _contextNoSql.MenuNoSql.Find(x => true).ToListAsync();

            return menuNoSql;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

       
    }
}
