using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteProjectsCommand : IRequest<MethodResult<DeleteProjectsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteProjectsCommandResponse
    {
        public DeleteProjectsCommandResponse(List<ProjectsCommandResponseDTO> Projects)
        {
            _Projects = Projects;
        }

        public List<ProjectsCommandResponseDTO> _Projects { get; }
    }
}