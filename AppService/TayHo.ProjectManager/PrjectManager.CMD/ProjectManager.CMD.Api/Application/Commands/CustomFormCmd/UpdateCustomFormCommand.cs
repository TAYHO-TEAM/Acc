using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomFormCommand : CustomFormCommandSet,IRequest<MethodResult<UpdateCustomFormCommandResponse>>
    {
       
    }

    public class UpdateCustomFormCommandResponse : CustomFormCommandResponseDTO
    {
    }
}