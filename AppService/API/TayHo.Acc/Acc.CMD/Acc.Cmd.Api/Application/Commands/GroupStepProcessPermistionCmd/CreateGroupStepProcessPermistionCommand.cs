using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupStepProcessPermistionCommand : GroupStepProcessPermistionCommandSet, IRequest<MethodResult<CreateGroupStepProcessPermistionCommandResponse>>
    {
       
    }

    public class CreateGroupStepProcessPermistionCommandResponse : GroupStepProcessPermistionCommandResponseDTO { }
}