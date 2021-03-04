using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanMasterCommand : PlanMasterCommandSet,IRequest<MethodResult<UpdatePlanMasterCommandResponse>>
    {
       
    }

    public class UpdatePlanMasterCommandResponse : PlanMasterCommandResponseDTO
    {
    }
}
