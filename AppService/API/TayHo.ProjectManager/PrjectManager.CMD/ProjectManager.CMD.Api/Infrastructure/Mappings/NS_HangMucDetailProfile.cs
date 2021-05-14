using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_HangMucDetailProfile : Profile
    {
        public NS_HangMucDetailProfile()
        {
            CreateMap<NS_HangMucDetail, CreateNS_HangMucDetailCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_HangMucDetail, UpdateNS_HangMucDetailCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_HangMucDetail, NS_HangMucDetailCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
