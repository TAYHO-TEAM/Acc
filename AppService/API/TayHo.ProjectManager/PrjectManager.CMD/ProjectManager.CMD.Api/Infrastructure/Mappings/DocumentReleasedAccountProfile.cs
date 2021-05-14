using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class DocumentReleasedAccountProfile: Profile
    {
        public DocumentReleasedAccountProfile()
        {
            //CreateMap<DocumentReleasedAccount, CreateDocumentReleasedAccountCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<DocumentReleasedAccount, UpdateDocumentReleasedAccountCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<DocumentReleasedAccount, DocumentReleasedAccountCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
