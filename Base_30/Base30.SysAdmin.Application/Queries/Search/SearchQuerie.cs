using AutoMapper;
using Base30.SysAdmin.Domain;


namespace Base30.SysAdmin.Application.Queries.Search
{
    public class SearchQueries : ISearchQueries
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IMapper _mapper;

        public SearchQueries(ISearchRepository searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchDto>> GetAllNoSql()
        {
            IEnumerable<SearchNoSql>? searchList = await _searchRepository.GetAll();
            IEnumerable<SearchDto> searchDto = _mapper.Map<IEnumerable<SearchDto>>(searchList);
            return searchDto;
        }

        public SearchDto? LoadByIdNoSql(Guid id)
        {
            SearchNoSql? searchNoSql = _searchRepository.LoadByIdNoSql(id);
            SearchDto searchDto = _mapper.Map<SearchDto>(searchNoSql);
            return searchDto;
        }
        public void Dispose()
        {
            _searchRepository?.Dispose();
        }
    }
}

