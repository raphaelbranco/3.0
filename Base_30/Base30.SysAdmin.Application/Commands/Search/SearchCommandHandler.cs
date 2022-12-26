using Base30.Core.Communication.Mediator;
using Base30.Core.Messages;
using Base30.Core.Messages.CommonMessages.Notifications;
using Base30.SysAdmin.Application.Commands.Search.Commands;
using MediatR;

namespace Base30.SysAdmin.Application.Commands.Search
{
    public class SearchCommandHandler :
            IRequestHandler<SearchCreateCommand, bool>,
            IRequestHandler<SearchSyncNoSqlCreateCommand, bool>,
            IRequestHandler<SearchUpdateCommand, bool>,
            IRequestHandler<SearchSyncNoSqlUpdateCommand, bool>

    {
        private readonly IMediatoRHandler _mediatoRHandler;
        private readonly ISearchExecuteCommand _searchExecuteCommand;

        public SearchCommandHandler(IMediatoRHandler mediatoRHandler, ISearchExecuteCommand searchExecuteCommand)
        {
            _mediatoRHandler = mediatoRHandler;
            _searchExecuteCommand = searchExecuteCommand;
        }

        public async Task<bool> Handle(SearchCreateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _searchExecuteCommand.Create(message, cancellationToken);
        }
        public async Task<bool> Handle(SearchSyncNoSqlCreateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _searchExecuteCommand.SyncNoSqlCreate(message, cancellationToken);
        }
        public async Task<bool> Handle(SearchUpdateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _searchExecuteCommand.Update(message, cancellationToken);
        }
        public async Task<bool> Handle(SearchSyncNoSqlUpdateCommand message, CancellationToken cancellationToken)
        {
            if (!ValidateCommand(message)) return false;

            return await _searchExecuteCommand.SyncNoSqlUpdate(message, cancellationToken);
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

