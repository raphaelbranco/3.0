using Base30.SysAdmin.Application.Commands.Menu.Commands;
using Base30.SysAdmin.Application.Events.Menu;
using Base30.SysAdmin.Domain;

namespace Base30.SysAdmin.Application.Commands.Menu
{
    public class MenuExecuteCommand : IMenuExecuteCommand
    {
        private readonly IMenuRepository _menuRepository;

        public  MenuExecuteCommand(IMenuRepository menuRepository) {
            _menuRepository = menuRepository;            
        }

        public async Task<bool> Create(MenuCreateCommand message, CancellationToken cancellationToken)
        {
            Domain.Menu menu = new(DateTime.Now, DateTime.Now, message.UserUpd, message.SysCustomer, true, message.Name, message.Description, message.Order, message.SourceMenu);
            _menuRepository.Create(menu);

            MenuCreatedEvent newMenuEvent = new(menu.Id, menu.Name ?? "", menu.SourceMenu, menu.SysCustomer, menu.Active, menu.Description, menu.Order);
            menu.AddEvent(newMenuEvent);

            return await CommitCommand(menu);
        }

        public async Task<bool> Update(MenuUpdateCommand message, CancellationToken cancellationToken)
        {
            Domain.Menu? menu = _menuRepository.LoadById(message.Id);

            if (menu == null) return false;

            menu.UpdateData(message.Name ?? "", message.Description ?? "", message.Order, true, null);
            
            _menuRepository.Update(menu);

            MenuUpdatedEvent menuUpdatedEvent = new(menu.Id, menu.Name ?? "", "update");
            menu.AddEvent(menuUpdatedEvent);

            return await CommitCommand(menu);
        }

        private async Task<bool> CommitCommand(Domain.Menu menu)
        {
            bool sucess = await _menuRepository.UnitOfWork.Commit() == false;
            if (!sucess)
            {
                MenuFailedEvent newMenuFailedEvent = new("Erro ao criar menu no BD");
                menu.AddEvent(newMenuFailedEvent);
            }

            return sucess;
        }

        public Task<bool> SyncCreate(MenuSyncNoSqlCreateCommand message, CancellationToken cancellationToken)
        {
            Domain.MenuNoSql menu = new(message.Id, message.SysCustomer, true, message.Name, message.Description, message.Order, message.SourceMenu);
            _menuRepository.SyncCreate(menu);

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _menuRepository?.Dispose();
        }
    }
}
