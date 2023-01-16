using AutoMapper;
using Base30.Authentication.Domain;


namespace Base30.Authentication.Application.Queries.AspNetUsers
{
    public class AspNetUsersQueries : IAspNetUsersQueries
    {
        private readonly IAspNetUsersRepository _aspnetusersRepository;
        private readonly IMapper _mapper;

        public AspNetUsersQueries(IAspNetUsersRepository aspnetusersRepository, IMapper mapper)
        {
            _aspnetusersRepository = aspnetusersRepository;
            _mapper = mapper;
        }


        public AspNetUsersDto? LoadByIdNoSql(Guid id)
        {
            AspNetUsersNoSql? aspnetusersNoSql = _aspnetusersRepository.LoadByIdNoSql(id);
            AspNetUsersDto aspnetusersDto = _mapper.Map<AspNetUsersDto>(aspnetusersNoSql);
            return aspnetusersDto;
        }
        public void Dispose()
        {
            _aspnetusersRepository?.Dispose();
        }
    }
}

