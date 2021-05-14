using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class DocumentReleasedAccountProfile : Profile
    {
        public DocumentReleasedAccountProfile()
        {
            CreateMap<DocumentReleasedAccountDTO, DocumentReleasedAccountResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
