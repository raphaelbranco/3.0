using AutoMapper;
using Base30.SysAdmin.Application.Queries.Menu;
using Base30.SysAdmin.Domain;

namespace Base30.SysAdmin.Application.AutoMapper
{
    public class MenuProfile: Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuNoSql, MenuDto>(MemberList.Source);
            
            var configuration = new MapperConfiguration(cfg =>
            {
                CreateMap<MenuNoSql, MenuDto>(MemberList.Source);                
            });
            configuration.AssertConfigurationIsValid();
        }
    }
}
