using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_Phat_TheoDoiProfile : Profile
    {
        public NS_Phat_TheoDoiProfile()
        {
            CreateMap<NS_Phat_TheoDoi, CreateNS_Phat_TheoDoiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_Phat_TheoDoi, UpdateNS_Phat_TheoDoiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_Phat_TheoDoi, NS_Phat_TheoDoiCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
