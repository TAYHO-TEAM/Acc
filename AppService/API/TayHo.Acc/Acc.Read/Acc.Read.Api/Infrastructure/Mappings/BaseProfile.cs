using Acc.Read.Api.ViewModels.BaseClasses;
using Acc.Read.Sql.Parameters;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
    public class BaseProfile : Profile
    {
        public BaseProfile()
        {
            CreateMap<BaseRequestViewModel, RequestBaseFilterParam>();
            CreateMap<BaseRequestParentViewModel, RequestParentBaseFilterParam>();
            CreateMap<BaseRequestViewModel, RequestHasAccountIdFilterParam>();
            CreateMap<BaseRequestParentViewModel, RequestHasAccountIdFilterParam>();
        }
    }
}
