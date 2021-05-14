using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteActionsCommand : IRequest<MethodResult<DeleteActionsCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteActionsCommandResponse
    {
        public DeleteActionsCommandResponse(List<ActionsCommandResponseDTO> Actions)
        {
            _Actions = Actions;
        }

        public List<ActionsCommandResponseDTO> _Actions { get; }
    }
}