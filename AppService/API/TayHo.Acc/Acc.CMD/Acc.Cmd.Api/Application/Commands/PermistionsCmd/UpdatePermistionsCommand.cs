using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdatePermistionsCommand : PermistionsCommandSet,IRequest<MethodResult<UpdatePermistionsCommandResponse>>
    {
       
    }

    public class UpdatePermistionsCommandResponse : PermistionsCommandResponseDTO
    {
    }
}