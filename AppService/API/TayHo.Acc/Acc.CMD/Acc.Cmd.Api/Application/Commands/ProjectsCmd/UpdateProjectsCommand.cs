using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateProjectsCommand : ProjectsCommandSet,IRequest<MethodResult<UpdateProjectsCommandResponse>>
    {
       
    }

    public class UpdateProjectsCommandResponse : ProjectsCommandResponseDTO
    {
    }
}