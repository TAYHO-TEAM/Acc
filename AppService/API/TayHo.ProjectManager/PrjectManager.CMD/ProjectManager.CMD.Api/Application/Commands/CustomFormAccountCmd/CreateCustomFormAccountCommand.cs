using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomFormAccountCommand : CustomFormAccountCommandSet, IRequest<MethodResult<CreateCustomFormAccountCommandResponse>>
    {
       
    }

    public class CreateCustomFormAccountCommandResponse : CustomFormAccountCommandResponseDTO { }
}
