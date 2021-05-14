using MediatR;
using Services.Common.DomainObjects;
using System.Collections.Generic;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteOperationProcessCommand : IRequest<MethodResult<DeleteOperationProcessCommandResponse>>
    {
        public List<int> Ids { get; set; }
    }

    public class DeleteOperationProcessCommandResponse
    {
        public DeleteOperationProcessCommandResponse(List<OperationProcessCommandResponseDTO> OperationProcess)
        {
            _OperationProcess = OperationProcess;
        }

        public List<OperationProcessCommandResponseDTO> _OperationProcess { get; }
    }
}