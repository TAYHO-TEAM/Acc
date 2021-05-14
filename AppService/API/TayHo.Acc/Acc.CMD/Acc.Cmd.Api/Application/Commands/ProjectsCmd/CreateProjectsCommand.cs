using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateProjectsCommand : ProjectsCommandSet, IRequest<MethodResult<CreateProjectsCommandResponse>>
    {
       
    }

    public class CreateProjectsCommandResponse : ProjectsCommandResponseDTO { }
}