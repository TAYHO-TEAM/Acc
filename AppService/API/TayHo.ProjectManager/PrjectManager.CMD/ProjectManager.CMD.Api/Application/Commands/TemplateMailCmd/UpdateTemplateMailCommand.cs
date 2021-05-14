using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateTemplateMailCommand : TemplateMailCommandSet,IRequest<MethodResult<UpdateTemplateMailCommandResponse>>
    {
       
    }

    public class UpdateTemplateMailCommandResponse : TemplateMailCommandResponseDTO
    {
    }
}
