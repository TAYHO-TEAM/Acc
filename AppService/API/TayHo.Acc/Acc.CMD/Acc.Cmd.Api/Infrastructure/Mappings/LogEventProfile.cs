using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Domain.DomainObjects;
using AutoMapper;


namespace Acc.Cmd.Api.Infrastructure.Mappings
{
    public class LogEventProfile : Profile 
    {
        public LogEventProfile()
        {
            CreateMap<LogEvent, LogEventCommandResponseDTO>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
            CreateMap<LogEvent, CreateLogEventCommandResponse>().ForMember(x => x.Id, opt => opt.MapFrom(t => t.Id));
        }
    }
}
