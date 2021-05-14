using AutoMapper;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Domain.DomainObjects;


namespace ProjectManager.CMD.Api.Infrastructure.Mappings
{
    public class DocumentReleasedLogProfile: Profile
    {
        public DocumentReleasedLogProfile()
        {
            CreateMap<DocumentReleasedLog, CreateDocumentReleasedLogCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<DocumentReleasedLog, UpdateDocumentReleasedLogCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<DocumentReleasedLog, DocumentReleasedLogCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
