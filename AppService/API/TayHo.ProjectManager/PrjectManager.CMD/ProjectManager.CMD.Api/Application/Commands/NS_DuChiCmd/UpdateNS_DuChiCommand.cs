using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_DuChiCommand : NS_DuChiCommandSet,IRequest<MethodResult<UpdateNS_DuChiCommandResponse>>
    {
       
    }

    public class UpdateNS_DuChiCommandResponse : NS_DuChiCommandResponseDTO
    {
    }
}