using Base30.Core.Communication.Mediator;
using Base30.Core.Messages;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.Authentication.Application.Commands.AspNetUsers;
using Base30.Authentication.Application.Commands.AspNetUsers.Commands;
using MediatR;
using Authentication.Application.Commands.Users.Command;

namespace Base30.Authentication.Application.Commands.AspNetUsers
{
    public class AspNetUsersCommandHandler :
            IRequestHandler<AspNetUsersCreateCommand, bool>,
            IRequestHandler<AspNetUsersSyncNoSqlCreateCommand, bool>,
            IRequestHandler<LoginCommand, bool>,
            IRequestHandler<LogOutCommand, bool>

    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly IAspNetUsersExecuteCommand _aspnetusersExecuteCommand;

        public AspNetUsersCommandHandler(IMediatoRHandler mediatoRHandler, IAspNetUsersExecuteCommand aspnetusersExecuteCommand)
        {
            _mediatoRHandler = mediatoRHandler;
            _aspnetusersExecuteCommand = aspnetusersExecuteCommand;
        }

        public async Task<bool> Handle(AspNetUsersCreateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _aspnetusersExecuteCommand.Create(message, cancellationToken);
        }
        public async Task<bool> Handle(AspNetUsersSyncNoSqlCreateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _aspnetusersExecuteCommand.SyncNoSqlCreate(message, cancellationToken);
        }

        public async Task<bool> Handle(LoginCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _aspnetusersExecuteCommand.Login(message, cancellationToken);
        }
        public async Task<bool> Handle(LogOutCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _aspnetusersExecuteCommand.LogOut(message, cancellationToken);
        }

        private bool ValidateCommand(Command message)
        {
            if (message.EhValido()) return true;

            if (message.ValidationResult == null) return false;

            foreach (var error in message.ValidationResult!.Errors)
            {
                DomainNotification errDomainNot = new(message.MessageType, error.ErrorMessage);
                _mediatoRHandler.PublishNotification(errDomainNot);
            }

            return false;
        }
    }
}

