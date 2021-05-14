using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NotifyConfigLogProfile : Profile 
    {
        public NotifyConfigLogProfile()
        {
            CreateMap<NotifyConfigLog, CreateNotifyConfigLogCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NotifyConfigLog, UpdateNotifyConfigLogCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NotifyConfigLog, NotifyConfigLogCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
