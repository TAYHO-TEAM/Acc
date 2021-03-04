using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomFormBodyCommand : CustomFormBodyCommandSet,IRequest<MethodResult<UpdateCustomFormBodyCommandResponse>>
    {
       
    }

    public class UpdateCustomFormBodyCommandResponse : CustomFormBodyCommandResponseDTO
    {
    }
}