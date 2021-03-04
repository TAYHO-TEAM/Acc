using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomFormContentCommand :CustomFormContentCommandSet, IRequest<MethodResult<CreateCustomFormContentCommandResponse>>
    {
        
    }

    public class CreateCustomFormContentCommandResponse : CustomFormContentCommandResponseDTO { }
}