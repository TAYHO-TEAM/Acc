using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;
using AutoMapper;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_Phat_NhomProfile : Profile 
    {
        public NS_Phat_NhomProfile()
        {
            CreateMap<NS_Phat_Nhom, CreateNS_Phat_NhomCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_Phat_Nhom, UpdateNS_Phat_NhomCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_Phat_Nhom, NS_Phat_NhomCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
