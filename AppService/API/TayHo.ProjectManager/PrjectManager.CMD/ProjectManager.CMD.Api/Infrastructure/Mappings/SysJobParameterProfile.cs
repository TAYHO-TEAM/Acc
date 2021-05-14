using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class SysJobParameterProfile : Profile 
    {
        public SysJobParameterProfile()
        {
            CreateMap<SysJobParameter, CreateSysJobParameterCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<SysJobParameter, UpdateSysJobParameterCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<SysJobParameter, SysJobParameterCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
