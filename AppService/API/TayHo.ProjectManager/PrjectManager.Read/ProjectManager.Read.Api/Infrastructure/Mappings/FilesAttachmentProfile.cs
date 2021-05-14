using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class FilesAttachmentProfile : Profile
    {
        public FilesAttachmentProfile()
        {
            CreateMap<FilesAttachmentDTO, FilesAttachmentResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
