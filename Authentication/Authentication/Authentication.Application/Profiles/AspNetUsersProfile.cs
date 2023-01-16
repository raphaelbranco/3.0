using AutoMapper;
using Base30.Authentication.Application.Queries.AspNetUsers;
using Base30.Authentication.Domain;
using Microsoft.AspNetCore.Identity;

namespace Base30.Authentication.Application.AutoMapper
{
    public class AspNetUsersProfile : Profile
    {
        public AspNetUsersProfile()
        {
            CreateMap<AspNetUsersNoSql, AspNetUsersDto>(MemberList.Source);
            CreateMap<AspNetUsersNoSql, IdentityUser<Guid>>();

            var configuration = new MapperConfiguration(cfg =>
            {
                CreateMap<AspNetUsersNoSql, AspNetUsersDto>(MemberList.Source);
                CreateMap<AspNetUsersNoSql, IdentityUser<Guid>>();
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}

