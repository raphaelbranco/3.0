using AutoMapper;
using Base30.SysAdmin.Application.Queries.Search;
using Base30.SysAdmin.Domain;

namespace Base30.SysAdmin.Application.AutoMapper
{
    public class SearchProfile : Profile
    {
        public SearchProfile()
        {
            CreateMap<SearchNoSql, SearchDto>(MemberList.Source);

            var configuration = new MapperConfiguration(cfg =>
            {
                CreateMap<SearchNoSql, SearchDto>(MemberList.Source);
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}

