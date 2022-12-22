using Base30.SysAdmin.Application.Commands.Menu.Commands;

namespace Base30.SysAdmin.Application.Commands.Menu
{
    public interface IMenuExecuteCommand : IDisposable
    {
        Task<bool> Create(MenuCreateCommand message, CancellationToken cancellationToken);
        Task<bool> SyncCreate(MenuSyncNoSqlCreateCommand message, CancellationToken cancellationToken);

        Task<bool> Update(MenuUpdateCommand message, CancellationToken cancellationToken);
        
    }
}
