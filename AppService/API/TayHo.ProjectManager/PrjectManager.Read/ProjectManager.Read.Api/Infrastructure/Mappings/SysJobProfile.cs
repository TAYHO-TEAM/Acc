using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class SysJobProfile : Profile
    {
        public SysJobProfile()
        {
            CreateMap<SysJobDTO, SysJobResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<SysJobDataBaseDTO, SysJobDataBaseResponseViewModel>().ForMember(target => target.name, m => m.MapFrom(source => source.name));
            CreateMap<SysJobStoreProcedureDTO, SysJobStoreProcedureResponseViewModel>().ForMember(target => target.name, m => m.MapFrom(source => source.name));
            CreateMap<SysJobParameterDTO, SysJobParameterResponseViewModel>().ForMember(target => target.ParameterName, m => m.MapFrom(source => source.ParameterName));
        }
    }
}
