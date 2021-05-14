using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_TamUng_TheoDoiProfile : Profile
    {
        public NS_TamUng_TheoDoiProfile()
        {
            CreateMap<NS_TamUng_TheoDoi, CreateNS_TamUng_TheoDoiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_TamUng_TheoDoi, UpdateNS_TamUng_TheoDoiCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_TamUng_TheoDoi, NS_TamUng_TheoDoiCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
