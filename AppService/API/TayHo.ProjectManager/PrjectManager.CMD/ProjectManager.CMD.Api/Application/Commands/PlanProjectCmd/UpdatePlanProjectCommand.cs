using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanProjectCommand : PlanProjectCommandSet,IRequest<MethodResult<UpdatePlanProjectCommandResponse>>
    {
       
    }

    public class UpdatePlanProjectCommandResponse : PlanProjectCommandResponseDTO
    {
    }
}
