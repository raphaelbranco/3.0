using Base30.Core.Communication.Mediator;
using Base30.Core.Messages;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.SysAdmin.Application.Commands.Menu.Commands;
using MediatR;

namespace Base30.SysAdmin.Application.Commands.Menu
{
    public class MenuCommandHandler :
            IRequestHandler<MenuCreateCommand, bool>,
            IRequestHandler<MenuUpdateCommand, bool>,
            IRequestHandler<MenuSyncNoSqlCreateCommand, bool>
    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly IMenuExecuteCommand _menuExecuteCommand;

        public MenuCommandHandler(IMediatoRHandler mediatoRHandler, IMenuExecuteCommand menuExecuteCommand)
        {
            _mediatoRHandler = mediatoRHandler;
            _menuExecuteCommand = menuExecuteCommand;
        }

        public async Task<bool> Handle(MenuCreateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _menuExecuteCommand.Create(message, cancellationToken);
        }

        public async Task<bool> Handle(MenuSyncNoSqlCreateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _menuExecuteCommand.SyncCreate(message, cancellationToken);
        }

        public async Task<bool> Handle(MenuUpdateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _menuExecuteCommand.Update(message, cancellationToken);
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
