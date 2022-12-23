using Base30.SysAdmin.Application.Commands.Search.Commands;

namespace Base30.SysAdmin.Application.Commands.Search
{
    public interface ISearchExecuteCommand : IDisposable
    {
        Task<bool> Create(SearchCreateCommand message, CancellationToken cancellationToken);
        Task<bool> SyncNoSqlCreate(SearchSyncNoSqlCreateCommand message, CancellationToken cancellationToken);
        Task<bool> Update(SearchUpdateCommand message, CancellationToken cancellationToken);
        Task<bool> SyncNoSqlUpdate(SearchSyncNoSqlUpdateCommand message, CancellationToken cancellationToken);

    }
}

