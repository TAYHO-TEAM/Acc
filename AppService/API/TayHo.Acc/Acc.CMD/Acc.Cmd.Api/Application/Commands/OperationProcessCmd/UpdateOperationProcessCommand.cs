using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateOperationProcessCommand : OperationProcessCommandSet,IRequest<MethodResult<UpdateOperationProcessCommandResponse>>
    {
       
    }

    public class UpdateOperationProcessCommandResponse : OperationProcessCommandResponseDTO
    {
    }
}