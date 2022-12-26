using Base30.SysAdmin.Application.Commands.Search.Commands;
using Base30.SysAdmin.Application.Events.Search;
using Base30.SysAdmin.Domain;
using System.Linq.Expressions;

namespace Base30.SysAdmin.Application.Commands.Search
{
    public class SearchExecuteCommand : ISearchExecuteCommand
    {
        private readonly ISearchRepository _searchRepository;

        public SearchExecuteCommand(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<bool> Create(SearchCreateCommand message, CancellationToken cancellationToken)
        {

            Domain.Search search =
                                            new(
                                                message.InsDt,
                                                message.UpdDt,
                                                message.UserUpd,
                                                message.SysCustomer,
                                                message.Active,
                                                message.Name,
                                                message.Description
        );
            _searchRepository.Create(search);

            SearchCreatedEvent newSearchEvent = new(search.Id, search.UserUpd, search.SysCustomer, search.Active, search.Name, search.Description);
            search.AddEvent(newSearchEvent);

            return await CommitCommand(search);
        }

        public async Task<bool> Update(SearchUpdateCommand message, CancellationToken cancellationToken)
        {
            Domain.Search? search = _searchRepository.LoadById(message.Id);

            if (search == null) return false;

            search.Update(message.UserUpd, message.Active, message.Name, message.Description);

            _searchRepository.Update(search);

            SearchUpdatedEvent searchUpdatedEvent = new(search.Id, search.UserUpd, search.SysCustomer, search.Active, search.Name, search.Description);
            search.AddEvent(searchUpdatedEvent);

            return await CommitCommand(search);
        }

        public Task<bool> SyncNoSqlCreate(SearchSyncNoSqlCreateCommand message, CancellationToken cancellationToken)
        {
            Domain.SearchNoSql search = new(message.Id, message.InsDt, message.UpdDt, message.UserUpd, message.SysCustomer, message.Active, message.Name, message.Description);
            _searchRepository.SyncCreate(search);

            return Task.FromResult(true);
        }
        public Task<bool> SyncNoSqlUpdate(SearchSyncNoSqlUpdateCommand message, CancellationToken cancellationToken)
        {
            (SearchNoSql? searchNoSql, Expression<Func<SearchNoSql, bool>> filter) = _searchRepository.LoadByIdNoSqlToSyncUpdate(message.Id);

            if (searchNoSql == null) return Task.FromResult(false);

            searchNoSql.UpdateNoSql(message.UserUpd, message.Active, message.Name, message.Description);
            _searchRepository.SyncUpdate(searchNoSql, filter);

            return Task.FromResult(true);
        }
        private async Task<bool> CommitCommand(Domain.Search search)
        {
            bool sucess = await _searchRepository.UnitOfWork.Commit() == false;
            if (!sucess)
            {
                SearchFailedEvent newSearchFailedEvent = new("Erro ao criar ou atualizar Search no BD");
                search.AddEvent(newSearchFailedEvent);
            }

            return sucess;
        }

        public void Dispose()
        {
            _searchRepository?.Dispose();
        }

    }
}

