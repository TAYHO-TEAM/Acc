using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateStagesCommand :StagesCommandSet, IRequest<MethodResult<CreateStagesCommandResponse>>
    {
        
    }

    public class CreateStagesCommandResponse : StagesCommandResponseDTO { }
}