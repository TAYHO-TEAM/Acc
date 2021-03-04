using MediatR;
using Services.Common.DomainObjects;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomFormAccountCommand : CustomFormAccountCommandSet,IRequest<MethodResult<UpdateCustomFormAccountCommandResponse>>
    {
       
    }

    public class UpdateCustomFormAccountCommandResponse : CustomFormAccountCommandResponseDTO
    {
    }
}
