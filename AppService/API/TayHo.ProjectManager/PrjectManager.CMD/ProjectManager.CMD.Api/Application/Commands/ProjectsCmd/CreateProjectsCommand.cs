using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateProjectsCommand : ProjectsCommandSet, IRequest<MethodResult<CreateProjectsCommandResponse>>
    {
       
    }

    public class CreateProjectsCommandResponse : ProjectsCommandResponseDTO { }
}