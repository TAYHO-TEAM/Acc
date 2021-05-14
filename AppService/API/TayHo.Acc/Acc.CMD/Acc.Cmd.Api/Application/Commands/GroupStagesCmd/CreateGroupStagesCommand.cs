using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupStagesCommand : GroupStagesCommandSet, IRequest<MethodResult<CreateGroupStagesCommandResponse>>
    {
       
    }

    public class CreateGroupStagesCommandResponse : GroupStagesCommandResponseDTO { }
}