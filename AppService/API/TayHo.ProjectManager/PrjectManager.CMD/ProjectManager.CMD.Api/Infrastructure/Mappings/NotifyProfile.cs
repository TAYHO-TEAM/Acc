using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NotifyProfile : Profile 
    {
        public NotifyProfile()
        {
            CreateMap<Notify, CreateNotifyCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Notify, UpdateNotifyCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<Notify, NotifyCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
