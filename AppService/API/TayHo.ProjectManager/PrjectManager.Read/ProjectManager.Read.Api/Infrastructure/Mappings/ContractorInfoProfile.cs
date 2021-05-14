using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;


namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class ContractorInfoProfile : Profile
    {
        public ContractorInfoProfile()
        {
            CreateMap<ContractorInfoDTO, ContractorInfoResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
