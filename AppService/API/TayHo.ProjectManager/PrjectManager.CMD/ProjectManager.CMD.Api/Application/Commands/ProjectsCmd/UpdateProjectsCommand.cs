using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateProjectsCommand : ProjectsCommandSet,IRequest<MethodResult<UpdateProjectsCommandResponse>>
    {
       
    }

    public class UpdateProjectsCommandResponse : ProjectsCommandResponseDTO
    {
    }
}