using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateFunctionsCommand : FunctionsCommandSet,IRequest<MethodResult<UpdateFunctionsCommandResponse>>
    {
       
    }

    public class UpdateFunctionsCommandResponse : FunctionsCommandResponseDTO
    {
    }
}