using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteAssignmentsCommand : IRequest<MethodResult<DeleteAssignmentsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteAssignmentsCommandResponse
    {
        public DeleteAssignmentsCommandResponse(List<AssignmentsCommandResponseDTO> Assignments)
        {
            assignments = Assignments;
        }

        public List<AssignmentsCommandResponseDTO> assignments { get; }
    }
}