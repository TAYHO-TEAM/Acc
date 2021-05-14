using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupStepProcessPermistionCommand : GroupStepProcessPermistionCommandSet,IRequest<MethodResult<UpdateGroupStepProcessPermistionCommandResponse>>
    {
       
    }

    public class UpdateGroupStepProcessPermistionCommandResponse : GroupStepProcessPermistionCommandResponseDTO
    {
    }
}