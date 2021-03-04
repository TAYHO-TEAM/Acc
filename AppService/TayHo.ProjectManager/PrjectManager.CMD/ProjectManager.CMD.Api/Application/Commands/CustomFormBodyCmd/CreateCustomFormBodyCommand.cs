using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomFormBodyCommand :CustomFormBodyCommandSet, IRequest<MethodResult<CreateCustomFormBodyCommandResponse>>
    {
        
    }

    public class CreateCustomFormBodyCommandResponse : CustomFormBodyCommandResponseDTO { }
}