using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteTemplateMailCommand : IRequest<MethodResult<DeleteTemplateMailCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteTemplateMailCommandResponse
    {
        public DeleteTemplateMailCommandResponse(List<TemplateMailCommandResponseDTO> TemplateMail)
        {
            _TemplateMail = TemplateMail;
        }

        public List<TemplateMailCommandResponseDTO> _TemplateMail { get; }
    }
}
