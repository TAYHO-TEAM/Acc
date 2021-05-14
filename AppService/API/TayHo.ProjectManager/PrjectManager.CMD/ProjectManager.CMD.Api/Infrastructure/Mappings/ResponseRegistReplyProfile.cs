using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class ResponseRegistReplyProfile: Profile
    {
        public ResponseRegistReplyProfile()
        {
            CreateMap<ResponseRegistReply, CreateResponseRegistReplyCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<ResponseRegistReply, ResponseRegistReplyCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<ResponseRegistReply, UpdateResponseRegistReplyCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
