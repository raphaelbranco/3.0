using Authentication.Application.Commands.Users.Command;
using Base30.Authentication.Application.Commands.AspNetUsers.Commands;

namespace Base30.Authentication.Application.Commands.AspNetUsers
{
    public interface IAspNetUsersExecuteCommand : IDisposable
    {
        Task<bool> Create(AspNetUsersCreateCommand message, CancellationToken cancellationToken);
        Task<bool> SyncNoSqlCreate(AspNetUsersSyncNoSqlCreateCommand message, CancellationToken cancellationToken);
        Task<bool> Login(LoginCommand message, CancellationToken cancellationToken);
        Task<bool> LogOut(LogOutCommand message, CancellationToken cancellationToken);
        
    }
}

