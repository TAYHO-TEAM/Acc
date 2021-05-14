using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomColumCommand : CustomColumCommandSet,IRequest<MethodResult<UpdateCustomColumCommandResponse>>
    {
       
    }

    public class UpdateCustomColumCommandResponse : CustomColumCommandResponseDTO
    {
    }
}