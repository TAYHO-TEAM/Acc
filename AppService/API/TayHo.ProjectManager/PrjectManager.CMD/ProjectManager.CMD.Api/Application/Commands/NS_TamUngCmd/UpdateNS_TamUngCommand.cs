using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_TamUngCommand : NS_TamUngCommandSet,IRequest<MethodResult<UpdateNS_TamUngCommandResponse>>
    {
       
    }

    public class UpdateNS_TamUngCommandResponse : NS_TamUngCommandResponseDTO
    {
    }
}