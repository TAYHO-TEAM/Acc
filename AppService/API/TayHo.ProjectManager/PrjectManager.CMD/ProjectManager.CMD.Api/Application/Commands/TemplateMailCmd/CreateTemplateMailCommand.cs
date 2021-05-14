using MediatR;
using Services.Common.DomainObjects;
using System;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateTemplateMailCommand : TemplateMailCommandSet, IRequest<MethodResult<CreateTemplateMailCommandResponse>>
    {
       
    }

    public class CreateTemplateMailCommandResponse : TemplateMailCommandResponseDTO { }
}
