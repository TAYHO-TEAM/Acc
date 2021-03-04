using AutoMapper;
using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.Parameters;


namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class BaseProfile : Profile
    {
        public BaseProfile() 
        {
            CreateMap<BaseRequestViewModel, RequestBaseFilterParam>();
            CreateMap<BaseRequestViewModel, RequestHasAccountIdFilterParam>();
            CreateMap<BaseTreeRequestViewModel, RequestTreeListBaseFilterParam>();
            CreateMap<BasePermitRequestViewModel, RequestHasAccountPermitFilterParam>();
        }
    }
}
