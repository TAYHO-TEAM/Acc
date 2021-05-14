using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class RequestRegistProfile : Profile
    {
        public RequestRegistProfile()
        {
            CreateMap<RequestRegistDTO, RequestRegistResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<RequestRegistDTO, ResponseRegistResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
            CreateMap<RequestRegistDetailDTO, RequestRegistResponseDetailViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
