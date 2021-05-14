using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanRegisterCommand : PlanRegisterCommandSet,IRequest<MethodResult<UpdatePlanRegisterCommandResponse>>
    {
       
    }

    public class UpdatePlanRegisterCommandResponse : PlanRegisterCommandResponseDTO
    {
    }
}