using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateAssignmentsCommand :AssignmentsCommandSet, IRequest<MethodResult<CreateAssignmentsCommandResponse>>
    {
        
    }

    public class CreateAssignmentsCommandResponse : AssignmentsCommandResponseDTO { }
}