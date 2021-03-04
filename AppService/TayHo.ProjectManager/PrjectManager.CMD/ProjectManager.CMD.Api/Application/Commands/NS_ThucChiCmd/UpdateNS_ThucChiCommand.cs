using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_ThucChiCommand : NS_ThucChiCommandSet,IRequest<MethodResult<UpdateNS_ThucChiCommandResponse>>
    {
       
    }

    public class UpdateNS_ThucChiCommandResponse : NS_ThucChiCommandResponseDTO
    {
    }
}