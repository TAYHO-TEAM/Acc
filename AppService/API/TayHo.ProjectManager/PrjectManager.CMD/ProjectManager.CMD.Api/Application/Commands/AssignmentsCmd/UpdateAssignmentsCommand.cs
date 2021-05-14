using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateAssignmentsCommand : AssignmentsCommandSet,IRequest<MethodResult<UpdateAssignmentsCommandResponse>>
    {
       
    }

    public class UpdateAssignmentsCommandResponse : AssignmentsCommandResponseDTO
    {
    }
}