using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class RequestRegistProfile: Profile
    {
        public RequestRegistProfile()
        {
            CreateMap<RequestRegist, CreateRequestRegistCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<RequestRegist, RequestRegistCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<RequestRegist, UpdateRequestRegistCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
