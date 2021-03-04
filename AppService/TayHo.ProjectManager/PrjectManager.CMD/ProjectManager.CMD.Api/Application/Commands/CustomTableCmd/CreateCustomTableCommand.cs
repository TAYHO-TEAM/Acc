using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomTableCommand :CustomTableCommandSet, IRequest<MethodResult<CreateCustomTableCommandResponse>>
    {
        
    }

    public class CreateCustomTableCommandResponse : CustomTableCommandResponseDTO { }
}