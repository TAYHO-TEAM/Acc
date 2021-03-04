using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomFormCommand :CustomFormCommandSet, IRequest<MethodResult<CreateCustomFormCommandResponse>>
    {
        
    }

    public class CreateCustomFormCommandResponse : CustomFormCommandResponseDTO { }
}