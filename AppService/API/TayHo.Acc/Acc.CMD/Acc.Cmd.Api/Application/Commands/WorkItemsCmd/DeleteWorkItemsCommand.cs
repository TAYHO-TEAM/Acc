using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteWorkItemsCommand : IRequest<MethodResult<DeleteWorkItemsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteWorkItemsCommandResponse
    {
        public DeleteWorkItemsCommandResponse(List<WorkItemsCommandResponseDTO> WorkItems)
        {
            _WorkItems = WorkItems;
        }

        public List<WorkItemsCommandResponseDTO> _WorkItems { get; }
    }
}