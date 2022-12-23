using Base30.SysAdmin.Application.Commands.Search.Commands;
using Base30.SysAdmin.Application.Events.Search;
using Base30.SysAdmin.Domain;

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
        message.Active,
        message.Name,
        message.Description
        );
            _searchRepository.Create(search);

            SearchCreatedEvent newSearchEvent = new(menu.Id, menu.Name ?? "", menu.SourceMenu, menu.SysCustomer, menu.Active, menu.Description, menu.Order);
            search.AddEvent(newSearchEvent);

            return await CommitCommand(search);
        }

    }
}