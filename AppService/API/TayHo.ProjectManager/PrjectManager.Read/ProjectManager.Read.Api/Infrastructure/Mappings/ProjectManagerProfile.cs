using AutoMapper;
using ProjectManager.Read.Api.ViewModels.DevExpressClasses;
using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class ProjectManagerProfile : Profile
    {
        public ProjectManagerProfile()
        {
            CreateMap<DevRequestLoadOptionsViewModel, DevLoadOptionsBase>();
        }
    }
}
