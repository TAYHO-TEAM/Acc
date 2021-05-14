using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class DocumentReleasedLogProfile : Profile
    {
        public DocumentReleasedLogProfile()
        {
            CreateMap<DocumentReleasedLogDTO, DocumentReleasedLogResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<DocumentReleasedLogDetailDTO, DocumentReleasedLogDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
