using AutoMapper;
using Base30.SysAdmin.Domain;


namespace Base30.SysAdmin.Application.Queries.Menu
{
    public class MenuQueries : IMenuQueries
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuQueries(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MenuDto>> GetAll()
        {
            IEnumerable<MenuNoSql>? menuList = await _menuRepository.GetAll();
            IEnumerable<MenuDto> menuDto = _mapper.Map<IEnumerable<MenuDto>>(menuList);
            return menuDto;
        }

        public void Dispose()
        {
            _menuRepository?.Dispose();
        }
    }


}
