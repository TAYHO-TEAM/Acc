using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateGroupStagesCommand :GroupStagesCommandSet, IRequest<MethodResult<CreateGroupStagesCommandResponse>>
    {
        
    }

    public class CreateGroupStagesCommandResponse : GroupStagesCommandResponseDTO { }
}