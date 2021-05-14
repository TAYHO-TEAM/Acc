using MediatR;
using Services.Common.DomainObjects;

namespace Acc.Cmd.Api.Application.Commands
{
    public class UpdateWorkItemsCommand : WorkItemsCommandSet,IRequest<MethodResult<UpdateWorkItemsCommandResponse>>
    {
       
    }

    public class UpdateWorkItemsCommandResponse : WorkItemsCommandResponseDTO
    {
    }
}