using Base30.Authentication.Application.Commands.AspNetUsers.Commands;

namespace Base30.Authentication.Application.Commands.AspNetUsers
{
    public interface IAspNetUsersExecuteCommand : IDisposable
    {
        Task<bool> Create(AspNetUsersCreateCommand message, CancellationToken cancellationToken);
        Task<bool> SyncNoSqlCreate(AspNetUsersSyncNoSqlCreateCommand message, CancellationToken cancellationToken);
    }
}

