using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class NS_GoiThauProfile : Profile
    {
        public NS_GoiThauProfile()
        {
            CreateMap<NS_GoiThau, CreateNS_GoiThauCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_GoiThau, UpdateNS_GoiThauCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<NS_GoiThau, NS_GoiThauCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
