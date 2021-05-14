using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class ResponseRegistReplyProfile : Profile
    {
        public ResponseRegistReplyProfile()
        {
            CreateMap<ResponseRegistReplyDTO, ResponseRegistReplyResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
